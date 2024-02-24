using Application.Features.Experiences.Queries.GetById;
using Application.Features.StudentForeignLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.StudentForeignLanguages.Queries.GetById;

public class GetByIdStudentForeignLanguageQuery : IRequest<List<GetByIdStudentForeignLanguageResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdStudentForeignLanguageQueryHandler : IRequestHandler<GetByIdStudentForeignLanguageQuery, List<GetByIdStudentForeignLanguageResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IStudentForeignLanguageRepository _studentForeignLanguageRepository;
        private readonly StudentForeignLanguageBusinessRules _studentForeignLanguageBusinessRules;

        public GetByIdStudentForeignLanguageQueryHandler(IMapper mapper, IStudentForeignLanguageRepository studentForeignLanguageRepository, StudentForeignLanguageBusinessRules studentForeignLanguageBusinessRules)
        {
            _mapper = mapper;
            _studentForeignLanguageRepository = studentForeignLanguageRepository;
            _studentForeignLanguageBusinessRules = studentForeignLanguageBusinessRules;
        }

        public async Task<List<GetByIdStudentForeignLanguageResponse>> Handle(GetByIdStudentForeignLanguageQuery request, CancellationToken cancellationToken)
        {
            //StudentForeignLanguage? studentForeignLanguage = await _studentForeignLanguageRepository.GetAsync(predicate: sfl => sfl.Id == request.Id, cancellationToken: cancellationToken);
            //await _studentForeignLanguageBusinessRules.StudentForeignLanguageShouldExistWhenSelected(studentForeignLanguage);

            //GetByIdStudentForeignLanguageResponse response = _mapper.Map<GetByIdStudentForeignLanguageResponse>(studentForeignLanguage);
            //return response;
            var studentForeignLanguage = await _studentForeignLanguageRepository.GetListAsync(predicate: ssm => ssm.StudentId == request.Id, 
                include: m => m.Include(s => s.ForeignLanguage).Include(s=>s.ForeignLanguageLevel)
                  , cancellationToken: cancellationToken);

            ForeignLanguageDto foreignLanguageDto = studentForeignLanguage.Items.Select(ssm => _mapper.Map<ForeignLanguageDto>(ssm.ForeignLanguage)).FirstOrDefault();
            ForeignLanguageLevelDto foreignLanguageLevelDto = studentForeignLanguage.Items.Select(ssm => _mapper.Map<ForeignLanguageLevelDto>(ssm.ForeignLanguageLevel)).FirstOrDefault();

            List<GetByIdStudentForeignLanguageResponse> response = _mapper.Map<List<GetByIdStudentForeignLanguageResponse>>(studentForeignLanguage.Items);
            return response;
        }
    }
}