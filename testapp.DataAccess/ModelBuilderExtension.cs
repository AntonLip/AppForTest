﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using testapp.Models.DbModels;

namespace testapp.DataAccess
{
    public static class ModelBuilderExtension
    {
        static Guid userId = Guid.NewGuid();
        static Guid roleId = Guid.NewGuid();
        static Guid groupId = Guid.NewGuid();
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedGroup(modelBuilder);
            SeedRoles(modelBuilder);
            SeedUsers(modelBuilder);
            SeedUserRoles(modelBuilder);
        }

        private static void SeedGroup(ModelBuilder modelBuilder)
        {
            Group group = new Group
            {
                Id = groupId,
                Name = "444"
            };
            modelBuilder.Entity<Group>().HasData(group);
            Group groupLectural = new Group
            {
                Id = Guid.NewGuid(),
                Name = "Преподаватели"
            };
            modelBuilder.Entity<Group>().HasData(groupLectural);
        }
        private static void SeedUsers(ModelBuilder builder)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Id = userId.ToString(),
                UserName = "Admin",
                FirstName = "Admin",
                LastName = "Admin",
                GroupId = groupId,
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                ConcurrencyStamp = "avadvd",
                Email = "admin@gmail.com",
                LockoutEnabled = false,
                TwoFactorEnabled = false,
                SecurityStamp = "avebgdfvs",
                PhoneNumber = "1234567890"
            };
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            var str = passwordHasher.HashPassword(user, "2732011Qw!");
            user.PasswordHash = str;
            builder.Entity<ApplicationUser>().HasData(user);
        }
        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = roleId.ToString(),
                    Name = "Admin",
                    ConcurrencyStamp = "1",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Курсант",
                    ConcurrencyStamp = "2",
                    NormalizedName = "КУРСАНТ"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Преподаватель",
                    ConcurrencyStamp = "2",
                    NormalizedName = "ПРЕПОДАВАТЕЛЬ"
                });
        }
        private static void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = roleId.ToString(),
                    UserId = userId.ToString()
                });
        }
    }
}
