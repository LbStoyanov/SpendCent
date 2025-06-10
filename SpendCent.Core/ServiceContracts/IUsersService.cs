

using SpendCent.Core.DTOs;

namespace SpendCent.Core.ServiceContracts;

public interface IUsersService
{
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);   

    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
}

