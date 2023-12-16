using Application.Features.StudentForeignLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentForeignLanguages.Commands.Update;

public class UpdateStudentForeignLanguageCommand : IRequest<UpdatedStudentForeignLanguageResponse>
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ForeignLanguageId { get; set; }
    public Guid ForeignLanguageLevelId { get; set; }

    public class UpdateStudentForeignLanguageCommandHandler : IRequestHandler<UpdateStudentForeignLanguageCommand, UpdatedStudentForeignLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentForeignLanguageRepository _studentForeignLanguageRepository;
        private readonly StudentForeignLanguageBusinessRules _studentForeignLanguageBusinessRules;

        public UpdateStudentForeignLanguageCommandHandler(IMapper mapper, IStudentForeignLanguageRepository studentForeignLanguageRepository,
                                         StudentForeignLanguageBusinessRules studentForeignLanguageBusinessRules)
        {
            _mapper = mapper;
            _studentForeignLanguageRepository = studentForeignLanguageRepository;
            _studentForeignLanguageBusinessRules = studentForeignLanguageBusinessRules;
        }

        public async Task<UpdatedStudentForeignLanguageResponse> Handle(UpdateStudentForeignLanguageCommand request, CancellationToken cancellationToken)
        {
            StudentForeignLanguage? studentForeignLanguage = await _studentForeignLanguageRepository.GetAsync(predicate: sfl => sfl.Id == request.Id, cancellationToken: cancellationToken);
            await _studentForeignLanguageBusinessRules.StudentForeignLanguageShouldExistWhenSelected(studentForeignLanguage);
            studentForeignLanguage = _mapper.Map(request, studentForeignLanguage);

            await _studentForeignLanguageRepository.UpdateAsync(studentForeignLanguage!);

            UpdatedStudentForeignLanguageResponse response = _mapper.Map<UpdatedStudentForeignLanguageResponse>(studentForeignLanguage);
            return response;
        }
    }
}