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

            // внедрение зависимости для доступа к БД с использованием EF
            string connectionString = builder.Configuration.GetConnectionString("MsSqlConnection");


            services.AddDbContext<InspectionsDbContext>(options => options.UseSqlServer(connectionString));


            // добавление кэширования
            services.AddMemoryCache();
            // добавление поддержки сессии
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddTransient<IInspectionService, InspectionService>(); // добавляем сервис IInspectionService

            //Использование MVC
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

            // добавляем поддержку статических файлов
            app.UseStaticFiles();

            // добавляем поддержку сессий
            app.UseSession();

            // добавляем компонент middleware по инициализации базы данных и производим инициализацию базы
            app.UseDbInitializer();

            // добавляем компонент middleware для реализации кэширования и записывем данные в кэш
            app.UseOperatinCache("Inspections 10");

            //Маршрутизация
            app.UseRouting();
            // устанавливаем сопоставление маршрутов с контроллерами 
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
