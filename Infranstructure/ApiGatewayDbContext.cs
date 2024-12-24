namespace ApiGateway.Infranstructure;

using Microsoft.EntityFrameworkCore;
using ApiGateway.Models;
using System;
using ApiGateway.Models;

public class ApiGatewayDbContext : DbContext
{
    public DbSet<Api> Apis { get; set; }
    public DbSet<Client> Clients { get; set; }

    public ApiGatewayDbContext(DbContextOptions<ApiGatewayDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Api>().HasKey(a => a.Id);
        modelBuilder.Entity<Client>().HasKey(c => c.Id);
    }
}
