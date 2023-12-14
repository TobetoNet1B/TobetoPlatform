using Core.Application.Responses;

namespace Application.Features.StudentAppeals.Commands.Create;

public class CreatedStudentAppealResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid AppealId { get; set; }
    public Guid StudentId { get; set; }
    public bool IsApproved { get; set; }
}