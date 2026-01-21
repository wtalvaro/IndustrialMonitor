using IndustrialMonitor.Models;
using Microsoft.EntityFrameworkCore;

namespace IndustrialMonitor.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Maquina> Maquinas { get; set; } = default!;
}
