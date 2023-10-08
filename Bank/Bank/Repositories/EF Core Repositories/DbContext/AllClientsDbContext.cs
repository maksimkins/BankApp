
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Repositories.EF_Core_Repositories.DbContext;

using Bank.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

public class AllClientsDbContext : DbContext 
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<DebtorClient> DebtorClients { get; set; }
    public DbSet<LoanClient> LoanClients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(connectionString: "Server=localhost;Database=Bank;Integrated Security=SSPI;TrustServerCertificate=True");//User Id=admin;Password=admin;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>()
            .HasIndex(u => u.Login)
            .IsUnique();


        modelBuilder.Entity<LoanClient>()
            .HasIndex(u => u.ClientId)
            .IsUnique();

        modelBuilder.Entity<DebtorClient>()
            .HasIndex(u => u.LoanClientId)
            .IsUnique();


        modelBuilder.Entity<DebtorClient>()
            .HasIndex(u => u.ClientId)
            .IsUnique();

        base.OnModelCreating(modelBuilder);
    }
}
