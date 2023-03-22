using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Extensions
{
    public static class PortalServiceCollectionExtensions
    {
        public static IServiceCollection AddPortalServices(this IServiceCollection services, IConfiguration config) 
        {
            services.AddScoped<IRoleRepository, RoleRepository>();
            //services.AddScoped<IMemberRepository, MemberRepository>();
            //services.AddScoped<IRoleMemberRepository, RoleMemberRepository>();
            services.AddScoped<ICoachRepository, CoachRepository>();
            services.AddScoped<ISwimmerRepository, SwimmerRepository>();
            services.AddScoped<ISwimmingPoolRepository, SwimmingPoolRepository>();
            services.AddScoped<IWorkoutRepository, WorkoutRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IRaceRepository, RaceRepository>();
            services.AddScoped<IResultRepository, ResultRepository>();

            return services;
        }
    }
}
