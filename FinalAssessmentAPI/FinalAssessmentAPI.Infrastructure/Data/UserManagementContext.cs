using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using FinalAssessmentAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalAssessmentAPI.Infrastructure.Data
{
    public class UserManagementContext : DbContext
    {
        public UserManagementContext(DbContextOptions<UserManagementContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Email).HasConversion<byte[]>();
                entity.Property(e => e.Phone).HasConversion<byte[]>();
            });
        }
    }
}
