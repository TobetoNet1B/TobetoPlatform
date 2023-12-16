using Application.Features.StudentForeignLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentForeignLanguages.Commands.Create;

public class CreateStudentForeignLanguageCommand : IRequest<CreatedStudentForeignLanguageResponse>
{
    public Guid StudentId { get; set; }
    public Guid ForeignLanguageId { get; set; }
    public Guid ForeignLanguageLevelId { get; set; }

    public class CreateStudentForeignLanguageCommandHandler : IRequestHandler<CreateStudentForeignLanguageCommand, CreatedStudentForeignLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentForeignLanguageRepository _studentForeignLanguageRepository;
        private readonly StudentForeignLanguageBusinessRules _studentForeignLanguageBusinessRules;

        public CreateStudentForeignLanguageCommandHandler(IMapper mapper, IStudentForeignLanguageRepository studentForeignLanguageRepository,
                                         StudentForeignLanguageBusinessRules studentForeignLanguageBusinessRules)
        {
            _mapper = mapper;
            _studentForeignLanguageRepository = studentForeignLanguageRepository;
            _studentForeignLanguageBusinessRules = studentForeignLanguageBusinessRules;
        }

        public async Task<CreatedStudentForeignLanguageResponse> Handle(CreateStudentForeignLanguageCommand request, CancellationToken cancellationToken)
        {
            StudentForeignLanguage studentForeignLanguage = _mapper.Map<StudentForeignLanguage>(request);

            await _studentForeignLanguageRepository.AddAsync(studentForeignLanguage);

            CreatedStudentForeignLanguageResponse response = _mapper.Map<CreatedStudentForeignLanguageResponse>(studentForeignLanguage);
            return response;
        }
    }
}