using Microsoft.EntityFrameworkCore;
using API.DAL.Entities;

namespace API.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<StadiumTickets> StadiumTicketss { get; set; }
        public DbSet<Entrance> Entrances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StadiumTickets>()
           .HasIndex(t => t.Id)
           .IsUnique();

          modelBuilder.Entity<Entrance>()
         .HasIndex(t => t.Id)
         .IsUnique();


        }
    }
}