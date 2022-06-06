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
           base.OnModelCreating(builder);
        }

      

    }
}