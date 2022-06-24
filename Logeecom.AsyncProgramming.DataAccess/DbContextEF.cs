using Logeecom.AsyncProgramming.Domain;
using Microsoft.EntityFrameworkCore;

namespace Logeecom.AsyncProgramming.DataAccess
{
    public class DbContextEF : DbContext
    {
        public DbContextEF(DbContextOptions<DbContextEF> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                .HasOne(x => x.Genre)
                .WithMany(x => x.Films)
                .HasForeignKey(x => x.GenreId)
                .HasPrincipalKey(x => x.Id);

            modelBuilder.Entity<Film>()
                .HasOne(x => x.Award)
                .WithMany(x => x.Films)
                .HasForeignKey(x => x.AwardId)
                .HasPrincipalKey(x => x.Id);

            modelBuilder.Entity<Film>()
                .HasOne(x => x.Director)
                .WithMany(x => x.Films)
                .HasForeignKey(x => x.DirectorId)
                .HasPrincipalKey(x => x.Id);

            modelBuilder.Entity<Film>()
                .HasMany(x => x.Actors)
                .WithMany(x => x.Films)
                .UsingEntity(x => x.ToTable("Acts"));

            modelBuilder.Entity<Film>().Navigation(x => x.Genre).AutoInclude();
            modelBuilder.Entity<Film>().Navigation(x => x.Actors).AutoInclude();
            modelBuilder.Entity<Film>().Navigation(x => x.Award).AutoInclude();
            modelBuilder.Entity<Film>().Navigation(x => x.Director).AutoInclude();
        }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Award> Awards { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Film> Films { get; set; }

        public DbSet<Genre> Genres { get; set; }
    }
}