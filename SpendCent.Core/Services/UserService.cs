using SpendCent.Core.DTOs;
using SpendCent.Core.Entities;
using SpendCent.Core.RepositoryContracts;
using SpendCent.Core.ServiceContracts;

namespace SpendCent.Core.Services;

internal class UserService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UserService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        var user = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return null;
        }

        return new AuthenticationResponse(user.UserID, user.Email, user.PersonName, user.Gender, "token", Success: true);
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

        return new AuthenticationResponse(newUser.UserID, newUser.Email, newUser.PersonName,newUser.Gender, "token",Success: true);
    }
}

