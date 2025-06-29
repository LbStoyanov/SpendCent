﻿using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace SpendCent.Infrastructure.DbContext;

public class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _connection;

    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        string connectionString = _configuration.GetConnectionString("PostgresConnection");

        // Initialize your Dapper connection here using the connection string

        _connection =  new NpgsqlConnection(connectionString);
    }


    public IDbConnection DbConnection => _connection;
}

