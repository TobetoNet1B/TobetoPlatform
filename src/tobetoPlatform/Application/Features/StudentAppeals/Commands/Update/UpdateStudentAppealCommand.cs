using Application.Features.StudentAppeals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentAppeals.Commands.Update;

public class UpdateStudentAppealCommand : IRequest<UpdatedStudentAppealResponse>
{
    public Guid Id { get; set; }
    public Guid AppealId { get; set; }
    public Guid StudentId { get; set; }
    public bool IsApproved { get; set; }

    public class UpdateStudentAppealCommandHandler : IRequestHandler<UpdateStudentAppealCommand, UpdatedStudentAppealResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentAppealRepository _studentAppealRepository;
        private readonly StudentAppealBusinessRules _studentAppealBusinessRules;

        public UpdateStudentAppealCommandHandler(IMapper mapper, IStudentAppealRepository studentAppealRepository,
                                         StudentAppealBusinessRules studentAppealBusinessRules)
        {
            _mapper = mapper;
            _studentAppealRepository = studentAppealRepository;
            _studentAppealBusinessRules = studentAppealBusinessRules;
        }

        public async Task<UpdatedStudentAppealResponse> Handle(UpdateStudentAppealCommand request, CancellationToken cancellationToken)
        {
            StudentAppeal? studentAppeal = await _studentAppealRepository.GetAsync(predicate: sa => sa.Id == request.Id, cancellationToken: cancellationToken);
            await _studentAppealBusinessRules.StudentAppealShouldExistWhenSelected(studentAppeal);
            studentAppeal = _mapper.Map(request, studentAppeal);

            await _studentAppealRepository.UpdateAsync(studentAppeal!);

            UpdatedStudentAppealResponse response = _mapper.Map<UpdatedStudentAppealResponse>(studentAppeal);
            return response;
        }
    }
}