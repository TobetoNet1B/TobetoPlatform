using Core.Application.Responses;

namespace Application.Features.Certificates.Commands.Create;

public class CreatedCertificateResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? FileType { get; set; }
    public Guid StudentId { get; set; }
}