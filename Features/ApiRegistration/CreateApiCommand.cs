using System;
using MediatR;
namespace ApiGateway.Features.ApiRegistration;

public class CreateApiCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string BaseUrl { get; set; }
    public string OwnerId { get; set; }
    public int RateLimit { get; set; }
}