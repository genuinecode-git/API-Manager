using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using ApiGateway.Models;
using Dapper;
using MediatR;
using ApiGateway.Models;

namespace ApiGateway.Features.ApiQuery;

public class GetApiByIdQueryHandler : IRequestHandler<GetApiByIdQuery, Api>
{
    private readonly IDbConnection _dbConnection;

    public GetApiByIdQueryHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Api> Handle(GetApiByIdQuery request, CancellationToken cancellationToken)
    {
        const string sql = "SELECT * FROM Apis WHERE Id = @ApiId";
        return await _dbConnection.QueryFirstOrDefaultAsync<Api>(sql, new { ApiId = request.ApiId });
    }
}