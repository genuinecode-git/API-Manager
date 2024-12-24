using System;
using System.Threading;
using System.Threading.Tasks;
using ApiGateway.Infranstructure;
using ApiGateway.Models;
using MediatR;

namespace ApiGateway.Features.ApiRegistration;
public class CreateApiCommandHandler : IRequestHandler<CreateApiCommand, Guid>
{
    private readonly ApiGatewayDbContext _context;

    public CreateApiCommandHandler(ApiGatewayDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateApiCommand request, CancellationToken cancellationToken)
    {
        var api = new Api
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            BaseUrl = request.BaseUrl,
            OwnerId = request.OwnerId,
            RateLimit = request.RateLimit
        };

        await _context.Apis.AddAsync(api, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return api.Id;
    }
}