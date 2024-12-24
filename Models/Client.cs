using System;
using System.Collections.Generic;

namespace ApiGateway.Models;

public class Client
{
    public Guid Id { get; set; }
    public string ClientId { get; set; }
    public string Secret { get; set; }
    public List<Guid> ApiAccess { get; set; } = new();
}
