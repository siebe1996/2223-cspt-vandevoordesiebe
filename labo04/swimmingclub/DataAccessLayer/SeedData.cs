using Globals.Entities;
using Globals.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new SwimmingClubContext(serviceProvider.GetRequiredService<DbContextOptions<SwimmingClubContext>>());
            using UserManager<Member> _userManager = serviceProvider.GetRequiredService<UserManager<Member>>();
            using RoleManager<Role>_roleManager = serviceProvider.GetService<RoleManager<Role>>();
            SeedRoles(context, _roleManager);
            SeedCoaches(context, _userManager);
        }

        private static void SeedRoles(SwimmingClubContext context, RoleManager<Role> _roleManager)
        {
            if (!context.Roles.Any()) 
            { 
                foreach (string line in File.ReadLines(@"Data\\Swimmingclubrollen.txt"))
                {
                    if (line.Contains(';'))
                    {
                        string[] rolDetails = line.Split(';');
                        _ = _roleManager.CreateAsync(new Role { Name = rolDetails[0], Description = rolDetails[1] }).Result;
                    }
                }
            }
        }

        private static void SeedCoaches(SwimmingClubContext context, UserManager<Member> _userManager)
        {
            if (!context.Coaches.Any())
            {
                foreach (string line in File.ReadLines(@"Data\\SwimmingClubCoaches.txt"))
                {
                    if (line.Contains(';'))
                    {
                        string[] coachDetails = line.Split(';');

                        Coach coach = new()
                        {
                            FirstName = coachDetails[0],
                            LastName = coachDetails[1],
                            Gender = (Gender)Enum.Parse(typeof(Gender), coachDetails[2]),
                            DateOfBirth = DateTime.Parse(coachDetails[3]),
                            Email = coachDetails[4],
                            UserName = coachDetails[5],
                            Level = (Level)Enum.Parse(typeof(Level), coachDetails[6])
                        };
                        _ = _userManager.CreateAsync(coach, "Azerty123!").Result;
                        _ = _userManager.AddToRoleAsync(coach, "Coach").Result;
                    }
                }
            }
        }
    }
}
