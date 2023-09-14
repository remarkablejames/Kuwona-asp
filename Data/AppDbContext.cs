using Microsoft.EntityFrameworkCore;
using Kuwona.Models;

namespace Kuwona.Data;

public class AppDbContext: DbContext
{
    protected readonly IConfiguration Configuration;
    
    public AppDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // connect to postgres database using connection string from appsettings.json
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
    }
    
    public DbSet<Kuwona.Models.Idea> Idea { get; set; } = default!;
    
    
    
}