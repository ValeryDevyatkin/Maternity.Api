using Maternity.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Maternity.Persistence.Context;

public class MaternityDbContext : DbContext
{
    public MaternityDbContext(DbContextOptions<MaternityDbContext> options) : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
}