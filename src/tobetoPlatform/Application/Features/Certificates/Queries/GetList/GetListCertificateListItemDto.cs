using Core.Application.Dtos;

namespace Application.Features.Certificates.Queries.GetList;

public class GetListCertificateListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? FileType { get; set; }
    public string? FileUrl { get; set; }
    public Guid StudentId { get; set; }
}