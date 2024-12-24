using ApiGateway.Models;
using MediatR;

namespace ApiGateway.Features.ApiQuery;

public class GetApiByIdQuery : IRequest<Api>
{
    public Guid ApiId { get; set; }
}