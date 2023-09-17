using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using App.Admin.Models;
using Microsoft.AspNetCore.Identity;
using App.Admin.ViewModels;

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



			// Seed roles
			builder.Entity<IdentityRole>().HasData(
				new IdentityRole
				{
					Id = "1",
					Name = "Admin",
					NormalizedName = "ADMIN"
				},
				new IdentityRole
				{
					Id = "2",
					Name = "RootAdmin",
					NormalizedName = "ROOTADMIN"
				}
			);

			// Seed users and assign roles
			var hasher = new PasswordHasher<ApplicationUser>();
			builder.Entity<ApplicationUser>().HasData(
				new ApplicationUser
				{
					Id = "1",
					UserName = "admin",
					NormalizedUserName = "ADMIN",
					Email = "admin@sanabat.com",
					NormalizedEmail = "ADMIN@SANABAT.COM",
					EmailConfirmed = true,
					PasswordHash = hasher.HashPassword(null, "P@ssword123")
				},
				new ApplicationUser
				{
					Id = "2",
					UserName = "root",
					NormalizedUserName = "Root",
					Email = "root@sanabat.com",
					NormalizedEmail = "ROOT@SANABAT.COM",
					EmailConfirmed = true,
					PasswordHash = hasher.HashPassword(null, "P@ssword123")
				}
			);

			// Assign roles to users
			builder.Entity<IdentityUserRole<string>>().HasData(
				new IdentityUserRole<string>
				{
					RoleId = "1", 
					UserId = "1"  
				},
				new IdentityUserRole<string>
				{
					RoleId = "2", 
					UserId = "2"  
				}
			);

			builder.Entity<Admin>().HasData(
				new Admin
				{
					Id = 1,
					IsRoot = false,
					CreatedDate = default,
					UserId = "1"
				},
				new Admin
				{
					Id = 2,
					IsRoot = true,
					CreatedDate = default,
					UserId = "2",
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
        public DbSet<App.Admin.ViewModels.CoverText>? CoverText { get; set; }


    }

   
}
