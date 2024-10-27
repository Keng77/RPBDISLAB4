using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RPBDISlLab4.Data;
using RPBDISlLab4.Middleware;
using RPBDISlLab4.Services;

namespace RPBDISlLab4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            IServiceCollection services = builder.Services;

            // Внедрение зависимости для доступа к БД с использованием EF
            string connectionString = builder.Configuration.GetConnectionString("MsSqlConnection");
            services.AddDbContext<InspectionsDbContext>(options => options.UseSqlServer(connectionString));

            // Добавление кэширования
            services.AddMemoryCache();
            services.AddResponseCaching();
            services.AddControllers(options =>
            {
                options.CacheProfiles.Add("Default",
                    new CacheProfile()
                    {
                        Duration = 2 * 16 + 240
                    });
            });
            // Добавление поддержки сессии
            services.AddDistributedMemoryCache();
            services.AddSession();

            // Регистрация сервисов
            services.AddTransient<IViewModelService, HomeModelService>();

            // Использование MVC
            services.AddControllersWithViews();

            WebApplication app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Добавляем поддержку статических файлов
            app.UseStaticFiles();

            // Добавляем поддержку сессий
            app.UseSession();

            // Инициализация базы данных
            app.UseDbInitializer();

            // Кэширование
            app.UseOperatinCache("Inspections 10");

            // Настройка маршрутизации
            app.UseRouting();

            app.UseResponseCaching(); // Включение ResponseCaching Middleware

            // Устанавливаем сопоставление маршрутов с контроллерами
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
