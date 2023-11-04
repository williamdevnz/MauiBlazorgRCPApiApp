using Microsoft.EntityFrameworkCore;
using DataView2.Core.Models;

namespace MAUIBlazorCFService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Persona> Personas => Set<Persona>();
}