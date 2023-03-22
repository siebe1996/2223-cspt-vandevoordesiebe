using Globals.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SwimmingClubContext : IdentityDbContext<
        Member, 
        Role, 
        Guid, 
        IdentityUserClaim<Guid>, 
        MemberRole, 
        IdentityUserLogin<Guid>,
        IdentityRoleClaim<Guid>,
        IdentityUserToken<Guid>
        >
    {
        public SwimmingClubContext() { }
        public SwimmingClubContext(DbContextOptions<SwimmingClubContext> options) : base(options) { }
        public DbSet<Member> Members { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<MemberRole> MemberRoles { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Swimmer> Swimmers { get; set; }
        public DbSet<SwimmingPool> SwimmingPools { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => new {e.FirstName, e.LastName})
                .IsUnique();

                // Each User can have many UserClaims
                entity.HasMany(e => e.Claims)
                    .WithOne()
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                entity.HasMany(e => e.Logins)
                    .WithOne()
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                entity.HasMany(e => e.Tokens)
                    .WithOne()
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                entity.HasMany(e => e.MemberRoles)
                    .WithOne()
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasMany(e => e.MemberRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
            });

            modelBuilder.Entity<MemberRole>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.RoleId });

                entity.HasOne(x => x.Member)
                .WithMany(x => x.MemberRoles)
                .HasForeignKey(x => x.MemberId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Role)
                .WithMany(x => x.MemberRoles)
                .HasForeignKey(x => x.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Coach>(entity =>
            {
                //entity.HasKey(e => e.Id);
                entity.HasMany(e => e.Workouts)
                .WithOne(e => e.Coach)
                .HasForeignKey(e => e.Id)
                .IsRequired();
            });

            modelBuilder.Entity<Swimmer>(entity =>
            {
                //entity.HasKey(e => e.Id);
                entity.HasMany(e => e.Results)
                .WithOne(e => e.Swimmer)
                .HasForeignKey(e => e.SwimmerId)
                .IsRequired();
            });

            modelBuilder.Entity<SwimmingPool>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Name)
                .IsUnique();

                entity.HasMany(e => e.Workouts)
                .WithOne(e => e.SwimmingPool)
                .HasForeignKey(e => e.SwimmingPoolId)
                .IsRequired();
            });

            modelBuilder.Entity<Workout>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(x => x.Coach)
                .WithMany(x => x.Workouts)
                .HasForeignKey(x => x.CoachId)
                .IsRequired();

                entity.HasOne(x => x.SwimmingPool)
                .WithMany(x => x.Workouts)
                .HasForeignKey(x => x.SwimmingPoolId)
                .IsRequired();

                entity.HasMany(e => e.Attendences)
                .WithOne(e => e.Workout)
                .HasForeignKey(e => e.WorkoutId)
                .IsRequired();
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasKey(e => new { e.SwimmerId, e.WorkoutId });

                entity.HasOne(x => x.Swimmer)
                .WithMany(x => x.Attendences)
                .HasForeignKey(x => x.SwimmerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Workout)
                .WithMany(x => x.Attendences)
                .HasForeignKey(x => x.WorkoutId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(x => x.SwimmingPool)
                .WithMany(x => x.Races)
                .HasForeignKey(x => x.SwimmingPoolId)
                .IsRequired();

                entity.HasMany(e => e.Results)
                .WithOne(e => e.Race)
                .HasForeignKey(e => e.RaceId)
                .IsRequired();
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(e => new { e.SwimmerId, e.RaceId });

                entity.HasOne(x => x.Swimmer)
                .WithMany(x => x.Results)
                .HasForeignKey(x => x.SwimmerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Race)
                .WithMany(x => x.Results)
                .HasForeignKey(x => x.RaceId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
