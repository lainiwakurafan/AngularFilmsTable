using Microsoft.EntityFrameworkCore;
using static AngularFilmsTable.Controllers.SampleDataController;

public class FilmsDbContext: DbContext
{
    public DbSet<Film> Films { get; set; }

        public FilmsDbContext(DbContextOptions<FilmsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var service = this.GetService<CustomService>();

            base.OnModelCreating(modelBuilder);
        }
}