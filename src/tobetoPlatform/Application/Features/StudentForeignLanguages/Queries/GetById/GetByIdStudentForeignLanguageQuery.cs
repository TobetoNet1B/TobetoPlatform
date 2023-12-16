using Application.Features.StudentForeignLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentForeignLanguages.Queries.GetById;

public class GetByIdStudentForeignLanguageQuery : IRequest<GetByIdStudentForeignLanguageResponse>
{
    public Guid Id { get; set; }

    public class GetByIdStudentForeignLanguageQueryHandler : IRequestHandler<GetByIdStudentForeignLanguageQuery, GetByIdStudentForeignLanguageResponse>
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

        public async Task<GetByIdStudentForeignLanguageResponse> Handle(GetByIdStudentForeignLanguageQuery request, CancellationToken cancellationToken)
        {
            StudentForeignLanguage? studentForeignLanguage = await _studentForeignLanguageRepository.GetAsync(predicate: sfl => sfl.Id == request.Id, cancellationToken: cancellationToken);
            await _studentForeignLanguageBusinessRules.StudentForeignLanguageShouldExistWhenSelected(studentForeignLanguage);

            GetByIdStudentForeignLanguageResponse response = _mapper.Map<GetByIdStudentForeignLanguageResponse>(studentForeignLanguage);
            return response;
        }
    }
}