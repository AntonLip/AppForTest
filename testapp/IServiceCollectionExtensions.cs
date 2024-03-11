using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using testapp.DataAccess;
using testapp.Models.DbModels;
using testapp.Models.Interfaces.Repository;
using testapp.Models.Interfaces.Service;
using testapp.Services;

namespace testapp
{
    public static class IServiceCollectionExtensions
    {
        public static void AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
             services.AddDbContext<AppDbContext>(options =>
                  options.UseSqlServer(GetConnectionString(configuration, env)));

            // добавление сервисов Idenity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IResultThemeRepository, ResultThemeRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IThemeRepository, ThemeRepository>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IDisciplineRepository, DisciplineRepository>();
            services.AddTransient<IResultRepository, ResultRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IDisciplineService, DisciplineService>();
            services.AddTransient<IResultService, ResultService>();
            services.AddTransient<ITestService, TestService>();
        }

        private static string GetConnectionString(IConfiguration configuration, IWebHostEnvironment env)
        {             
            if(env.IsProduction())
            {
                var server = Environment.GetEnvironmentVariable("CONN_STR_SERVER");
                var port = Environment.GetEnvironmentVariable("CONN_STR_PORT");
                var user = Environment.GetEnvironmentVariable("CONN_STR_USER");
                var password = Environment.GetEnvironmentVariable("CONN_STR_USER_PASSWORD");
                Console.WriteLine($"Server={server},{port};Database=Test;User Id={user};Password={password};TrustServerCertificate=true");
                return $"Server={server},{port};Database=Test;User Id={user};Password={password};TrustServerCertificate=true";
            }

            var dbServer = configuration["DbSettings:DbServer"];
            var dbPort = configuration["DbSettings:DbPort"];
            var dbUser = configuration["DbSettings:DbUser"];
            var dbPassword = configuration["DbSettings:DbPassword"];
            var database = configuration["DbSettings:Database"];
            return $"Server={dbServer},{dbPort};Database={database};User Id={dbUser};Password={dbPassword};TrustServerCertificate=true";

        }
    }
}
