using Microsoft.EntityFrameworkCore;
using Security_Principles_Web_API.Models;
using System.Data.Common;

namespace Security_Principles_Web_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<SecurityPrinciple> SecurityPrinciples { get; set; }
        public DbSet<vGroupMembers> VGroups { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupMember>()
                .HasKey(gm => new { gm.groupId, gm.securityPrincipleId });

            modelBuilder.Entity<SecurityPrinciple>()
                .HasIndex(sp => sp.displayName).IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder
               .Entity<vGroupMembers>()
               .ToView("vGroupMembers")
               .HasKey(t => new { t.groupId, t.memberId });
        }
    }
}
