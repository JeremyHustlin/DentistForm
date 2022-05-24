using DentistBookingForm.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace DentistBookingForm.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
            //
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<AvailableTimeSlot> AvailableTimeSlots { get; set; }
        public DbSet<Procedure> Procedures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Doctor>().HasData(new Doctor()
            {
                Id = "71c70f75-a2e5-4d67-a96d-65b60d6798b8",
                Email = "example@example.com"
            });

           

           base.OnModelCreating(builder);
        }
    }
}