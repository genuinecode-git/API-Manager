using System;

namespace ApiGateway.Models;
public class Api
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string BaseUrl { get; set; }
    public string OwnerId { get; set; }
    public int RateLimit { get; set; }
}
