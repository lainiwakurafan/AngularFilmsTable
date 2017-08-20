
using Microsoft.EntityFrameworkCore;
using static FilmsApp.Controllers.FilmsController;

public class FilmsDbContext: DbContext
{
    public DbSet<Film> Films { get; set; }

    public FilmsDbContext(DbContextOptions<FilmsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}