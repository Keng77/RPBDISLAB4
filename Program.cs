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
            // ���������� ��������� ������
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddTransient<IInspectionService, InspectionService>(); // ��������� ������ IInspectionService

            //������������� MVC
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

            // ��������� ��������� middleware �� ������������� ���� ������ � ���������� ������������� ����
            app.UseDbInitializer();

            // ��������� ��������� middleware ��� ���������� ����������� � ��������� ������ � ���
            app.UseOperatinCache("Inspections 10");

            //�������������
            app.UseRouting();
            // ������������� ������������� ��������� � ������������� 
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
