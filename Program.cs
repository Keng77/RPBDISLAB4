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

            // ��������� ����������� ��� ������� � �� � �������������� EF
            string connectionString = builder.Configuration.GetConnectionString("MsSqlConnection");
            services.AddDbContext<InspectionsDbContext>(options => options.UseSqlServer(connectionString));

            // ���������� �����������
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
            // ���������� ��������� ������
            services.AddDistributedMemoryCache();
            services.AddSession();

            // ����������� ��������
            services.AddTransient<IViewModelService, HomeModelService>();

            // ������������� MVC
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

            // ��������� ��������� ����������� ������
            app.UseStaticFiles();

            // ��������� ��������� ������
            app.UseSession();

            // ������������� ���� ������
            app.UseDbInitializer();

            // �����������
            app.UseOperatinCache("Inspections 10");

            // ��������� �������������
            app.UseRouting();

            app.UseResponseCaching(); // ��������� ResponseCaching Middleware

            // ������������� ������������� ��������� � �������������
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
