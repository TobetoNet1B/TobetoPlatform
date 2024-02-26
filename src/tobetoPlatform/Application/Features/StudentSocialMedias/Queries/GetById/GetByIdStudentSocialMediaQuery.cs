using Application.Features.StudentClassrooms.Queries.GetById;
using Application.Features.Students.Queries.GetById;
using Application.Features.StudentSocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.StudentSocialMedias.Queries.GetById;

public class GetByIdStudentSocialMediaQuery : IRequest<GetByIdStudentSocialMediaResponse>
{
    public Guid Id { get; set; }

    public class GetByIdStudentSocialMediaQueryHandler : IRequestHandler<GetByIdStudentSocialMediaQuery, GetByIdStudentSocialMediaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentSocialMediaRepository _studentSocialMediaRepository;
        private readonly StudentSocialMediaBusinessRules _studentSocialMediaBusinessRules;

        public GetByIdStudentSocialMediaQueryHandler(IMapper mapper, IStudentSocialMediaRepository studentSocialMediaRepository, StudentSocialMediaBusinessRules studentSocialMediaBusinessRules)
        {
            _mapper = mapper;
            _studentSocialMediaRepository = studentSocialMediaRepository;
            _studentSocialMediaBusinessRules = studentSocialMediaBusinessRules;
        }

        public async Task<GetByIdStudentSocialMediaResponse> Handle(GetByIdStudentSocialMediaQuery request, CancellationToken cancellationToken)
        {
            IPaginate<StudentSocialMedia> studentSocialMedia = await _studentSocialMediaRepository.GetListAsync(predicate: ssm => ssm.StudentId == request.Id, include: m => m.Include(s => s.SocialMedia)
                    , cancellationToken: cancellationToken);
            //await _studentSocialMediaBusinessRules.StudentSocialMediaShouldExistWhenSelected(studentSocialMedia);
            List<SocialMediaDto> socialMediaDtos = studentSocialMedia.Items.Select(ssm => _mapper.Map<SocialMediaDto>(ssm.SocialMedia)).ToList();

            GetByIdStudentSocialMediaResponse response = new GetByIdStudentSocialMediaResponse
            {
                
                StudentId = request.Id,
                SocialMedia = socialMediaDtos
            };
            return response;
        }
    }
}