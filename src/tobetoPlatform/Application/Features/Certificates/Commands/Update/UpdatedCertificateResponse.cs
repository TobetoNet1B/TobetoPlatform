using Core.Application.Responses;

namespace Application.Features.Certificates.Commands.Update;

public class UpdatedCertificateResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? FileType { get; set; }
    public string? FileUrl { get; set; }
    public Guid StudentId { get; set; }
}