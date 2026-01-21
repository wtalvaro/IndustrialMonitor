using IndustrialMonitor.Models;
using Microsoft.EntityFrameworkCore;

namespace IndustrialMonitor.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Maquina> Maquinas { get; set; }
}
