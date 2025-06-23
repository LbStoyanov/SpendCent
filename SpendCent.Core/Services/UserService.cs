using AutoMapper;
using SpendCent.Core.DTOs;
using SpendCent.Core.Entities;
using SpendCent.Core.RepositoryContracts;
using SpendCent.Core.ServiceContracts;

namespace SpendCent.Core.Services;

internal class UserService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public UserService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        var user = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token" };
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        var newUser = await _usersRepository.AddUser(new ApplicationUser()
        {
            PersonName = registerRequest.PersonName,
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            Gender = registerRequest.Gender.ToString(),
        });

        if (newUser == null) return null;

        return _mapper.Map<AuthenticationResponse>(newUser) with { Success = true, Token = "token"};
    }
}

