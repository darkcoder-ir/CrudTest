
using Mc2.Crud.Persistanse.DbContext;
using Mc2.CrudTest.Core.Application;
using Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;
using Mc2.CrudTest.Core.Domain;
using Mc2.CrudTest.Persistanse;
using Mc2.CrudTest.Presentation.Server.midlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Mc2.CrudTest.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Add services to the container.
            //builder.Services.AddDbContext<MyAppContext>(options =>
            //    options
            //        .UseSqlServer("Server =.; DataBase = Local; UID = app; PWD = app; Trusted_Connection = True; TrustServerCertificate = True") //ConnectionString

            //);
            builder.Services.AddDomainLayer();
            builder.Services.AddScoped<IDbContext, MyAppContext>();
            builder.Services.AddScoped<IWriteCustomerRepository>(provider => provider.GetService<WriteCustomerRepository>() ?? throw new Exception("Could not get DB context."));
            //builder.Services.AddAutoMapper(typeof(Program));
    
            builder.Services.AddApplicationLayer();
            builder.Services.AddPersistenceLayer();
  
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            app.UseExceptionHandleMiddleware();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.MapControllers();
            app.MapFallbackToFile("index.html");
      
            app.Run();
        }




}
}