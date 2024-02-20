using Application.Features.Auth.Commands.EnableEmailAuthenticator;
using Application.Features.Auth.Rules;
using Application.Services.Addresses;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Application.Services.Students;
using Core.Application.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<RegisteredResponse>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }
    public string IpAddress { get; set; }

    public RegisterCommand()
    {
        UserForRegisterDto = null!;
        IpAddress = string.Empty;
    }

    public RegisterCommand(UserForRegisterDto userForRegisterDto, string ipAddress)
    {
        UserForRegisterDto = userForRegisterDto;
        IpAddress = ipAddress;
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredResponse>
    {
        private readonly IStudentsService _studentsManager;
        private readonly IAddressesService _addressManager;
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IMediator _mediator;

        public RegisterCommandHandler(IAddressesService addressesService,IStudentsService studentsManager, IUserRepository userRepository, IAuthService authService, AuthBusinessRules authBusinessRules, IMediator mediator)
        {
            _addressManager = addressesService;
            _studentsManager = studentsManager;
            _userRepository = userRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
            _mediator = mediator;
        }


        public async Task<RegisteredResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);

            HashingHelper.CreatePasswordHash(
                request.UserForRegisterDto.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            User newUser =
                new()
                {
                    Email = request.UserForRegisterDto.Email,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };
            User createdUser = await _userRepository.AddAsync(newUser);

            Student newStudent = new Student
            {
                UserId = createdUser.Id,
            };

            await _studentsManager.AddAsync(newStudent);

            Address newAddress = new Address
            {
                StudentId = newStudent.Id,
            };

            
            await _addressManager.AddAsync(newAddress);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

            Core.Security.Entities.RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
            Core.Security.Entities.RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);




            //var enableEmailCommand = new EnableEmailAuthenticatorCommand(createdUser.Id, "http://localhost:5278");
            //await _mediator.Send(enableEmailCommand);




            RegisteredResponse registeredResponse = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
            return registeredResponse;
        }
    }
}
