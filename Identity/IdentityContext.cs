using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using App.Admin.Models;
using Microsoft.AspNetCore.Identity;

namespace MarminaAttendance.Identity
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<ApplicationUser>()
           .Property(e => e.Photo)
           .IsRequired(false);

           

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                   
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = hasher.HashPassword(null, "12345678"),
                },
                new ApplicationUser
                {
                   
                    UserName = "staff",
                    NormalizedUserName = "STAFF",
                    PasswordHash = hasher.HashPassword(null, "12345678"),
                }
            );

           
        }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<RoomDetails> RoomDetails { get; set; }
        public virtual DbSet<RoomImages> RoomImages { get; set; }
        public virtual DbSet<Testimony> Testimonies { get; set; }
        public virtual DbSet<CMS> Cmses { get; set; }


    }

   
}
