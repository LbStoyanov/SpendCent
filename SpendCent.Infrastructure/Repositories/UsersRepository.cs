using Dapper;
using SpendCent.Core.DTOs;
using SpendCent.Core.Entities;
using SpendCent.Core.RepositoryContracts;
using SpendCent.Infrastructure.DbContext;

namespace SpendCent.Infrastructure.Repositories;

internal class UsersRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;

    public UsersRepository(DapperDbContext context)
    {
        _dbContext = context;
    }

    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserID = Guid.NewGuid();


        //SQL Query to insert user into the database.

        string query
            = "INSERT INTO public.\"Users\" (\"UserID\", \"Email\", \"PersonName\",\"Gender\", \"Password\") " +
            "VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";



        int rowsCount = await _dbContext.DbConnection.ExecuteAsync(query, user);

        if (rowsCount > 0)
        {
            return user;
        }


        return null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        var parameters = new {Email = email, Password = password};


        string query =
              "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";


        var user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query,parameters);

        return user;
    }
}

