using Application.Features.StudentAppeals.Constants;
using Application.Features.StudentAppeals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentAppeals.Commands.Delete;

public class DeleteStudentAppealCommand : IRequest<DeletedStudentAppealResponse>
{
    public Guid Id { get; set; }

    public class DeleteStudentAppealCommandHandler : IRequestHandler<DeleteStudentAppealCommand, DeletedStudentAppealResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentAppealRepository _studentAppealRepository;
        private readonly StudentAppealBusinessRules _studentAppealBusinessRules;

        public DeleteStudentAppealCommandHandler(IMapper mapper, IStudentAppealRepository studentAppealRepository,
                                         StudentAppealBusinessRules studentAppealBusinessRules)
        {
            _mapper = mapper;
            _studentAppealRepository = studentAppealRepository;
            _studentAppealBusinessRules = studentAppealBusinessRules;
        }

        public async Task<DeletedStudentAppealResponse> Handle(DeleteStudentAppealCommand request, CancellationToken cancellationToken)
        {
            StudentAppeal? studentAppeal = await _studentAppealRepository.GetAsync(predicate: sa => sa.Id == request.Id, cancellationToken: cancellationToken);
            await _studentAppealBusinessRules.StudentAppealShouldExistWhenSelected(studentAppeal);

            await _studentAppealRepository.DeleteAsync(studentAppeal!);

            DeletedStudentAppealResponse response = _mapper.Map<DeletedStudentAppealResponse>(studentAppeal);
            return response;
        }
    }
}