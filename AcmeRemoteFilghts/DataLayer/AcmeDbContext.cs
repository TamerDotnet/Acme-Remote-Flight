using AcmeRemoteFilghts.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AcmeRemoteFilghts.DataLayer
{
    public class AcmeDbContext: DbContext
    {

        public DbSet<City> Cities { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public AcmeDbContext(DbContextOptions<AcmeDbContext> options)
                   : base(options)
        {
        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            } 
       
        }
         
    }
   
}
