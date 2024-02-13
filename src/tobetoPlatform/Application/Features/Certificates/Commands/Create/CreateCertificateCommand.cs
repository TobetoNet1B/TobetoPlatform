using Application.Features.Certificates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Certificates.Commands.Create;

public class CreateCertificateCommand : IRequest<CreatedCertificateResponse>
{
    public string? Name { get; set; }
    public string? FileType { get; set; }
    public string? FileUrl { get; set; }
    public Guid StudentId { get; set; }

    public class CreateCertificateCommandHandler : IRequestHandler<CreateCertificateCommand, CreatedCertificateResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICertificateRepository _certificateRepository;
        private readonly CertificateBusinessRules _certificateBusinessRules;

        public CreateCertificateCommandHandler(IMapper mapper, ICertificateRepository certificateRepository,
                                         CertificateBusinessRules certificateBusinessRules)
        {
            _mapper = mapper;
            _certificateRepository = certificateRepository;
            _certificateBusinessRules = certificateBusinessRules;
        }

        public async Task<CreatedCertificateResponse> Handle(CreateCertificateCommand request, CancellationToken cancellationToken)
        {
            

            Certificate certificate = _mapper.Map<Certificate>(request);
            await _certificateBusinessRules.CertificateNameCanNotBeDuplicationWhenInserted(request.StudentId, certificate);
            await _certificateRepository.AddAsync(certificate);

            CreatedCertificateResponse response = _mapper.Map<CreatedCertificateResponse>(certificate);
            return response;
        }
    }
}