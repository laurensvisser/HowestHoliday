using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HowestHoliday.Models;

namespace HowestHoliday.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Request> Request { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Request>(entity =>
            {
                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Manager)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.MotivationManager)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.MotivationRequestor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Requestor)
                    .IsRequired()
                    .HasMaxLength(256);
            });
        }
    }
}
