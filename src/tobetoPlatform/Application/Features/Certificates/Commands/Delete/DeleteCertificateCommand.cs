using Application.Features.Certificates.Constants;
using Application.Features.Certificates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Certificates.Commands.Delete;

public class DeleteCertificateCommand : IRequest<DeletedCertificateResponse>
{
    public Guid Id { get; set; }

    public class DeleteCertificateCommandHandler : IRequestHandler<DeleteCertificateCommand, DeletedCertificateResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICertificateRepository _certificateRepository;
        private readonly CertificateBusinessRules _certificateBusinessRules;
        private readonly CloudinaryService _cloudinaryService;

        public DeleteCertificateCommandHandler(IMapper mapper, ICertificateRepository certificateRepository,
                                         CertificateBusinessRules certificateBusinessRules, CloudinaryService cloudinaryService)
        {
            _mapper = mapper;
            _certificateRepository = certificateRepository;
            _certificateBusinessRules = certificateBusinessRules;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<DeletedCertificateResponse> Handle(DeleteCertificateCommand request, CancellationToken cancellationToken)
        {
            Certificate? certificate = await _certificateRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);

            bool deletionResult = await _cloudinaryService.DeleteImageAsync(ExtractPublicId(certificate.FileUrl));
            if (!deletionResult)
            {
                throw new Exception("Cloudinary'den sertifika silinemedi.");
            }

            await _certificateBusinessRules.CertificateShouldExistWhenSelected(certificate);

            await _certificateRepository.DeleteAsync(certificate!);

            DeletedCertificateResponse response = _mapper.Map<DeletedCertificateResponse>(certificate);
            return response;
        }
    }

    public static string ExtractPublicId(string fileUrl)
    {
        var segments = fileUrl.Split('/');
        var lastSegment = segments[^1];
        var fileName = lastSegment.Split('.')[0];
        return fileName;
    }
}