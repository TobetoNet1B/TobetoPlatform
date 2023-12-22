using Application.Features.Students.Rules;
using Application.Services.Repositories;
using Application.Services.UsersService;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Students.Commands.Create;

public class CreateStudentCommand : IRequest<CreatedStudentResponse>
{
    public string? IdentityNumber { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
    public string? About { get; set; }
    public string? ImgUrl { get; set; }

    public int? UserId { get; set; }

    //public string FirstName { get; set; }
    //public string LastName { get; set; }
    //public string Email { get; set; }
    //public string Password { get; set; }

    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, CreatedStudentResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly StudentBusinessRules _studentBusinessRules;

        public CreateStudentCommandHandler(IUserService userService, IMapper mapper, IStudentRepository studentRepository, StudentBusinessRules studentBusinessRules)
        {
            _userService = userService;
            _mapper = mapper;
            _studentRepository = studentRepository;
            _studentBusinessRules = studentBusinessRules;
        }

        public async Task<CreatedStudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            //UserAddDto userAddDto = new UserAddDto();
            //userAddDto.FirstName = request.FirstName;
            //userAddDto.LastName = request.LastName;
            //userAddDto.Email = request.Email;
            //userAddDto.Password = request.Password;

            //UserAddDto user = _mapper.Map<UserAddDto>(request);
            //await _userService.AddAsync(user);


            Student student = _mapper.Map<Student>(request);

            await _studentRepository.AddAsync(student);

            CreatedStudentResponse response = _mapper.Map<CreatedStudentResponse>(student);
            return response;
        }
    }
}