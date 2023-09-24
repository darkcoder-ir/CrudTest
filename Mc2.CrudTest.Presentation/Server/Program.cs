using Mc2.Crud.Persistanse.DbContexts;
using Mc2.CrudTest.Core.Application;
using Mc2.CrudTest.Core.Application.Abstracation.DbContext;
using Mc2.CrudTest.Core.Domain;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddMediatR(new MediatRServiceConfiguration() {
            //MediatR Config
            });
            builder.Services.AddDomainLayer();
            builder.Services.AddApplicationLayer();
            builder.Services.AddDbContext<ApplicationWriteDbContext>(options =>
                    options
                    .UseSqlServer("DataBase=. ......................") //ConnectionString
                    .EnableSensitiveDataLogging(true)
                );
            builder. Services.AddScoped<IApplicationWriteDbContext>(provider => provider.GetService<ApplicationWriteDbContext>() ?? throw new Exception("Could not get DB context."));
            builder. Services.AddScoped<IApplicationReadDbFacade, ApplicationReadDbFacade>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                // Perform additional initialization of the domain layer.
                serviceProvider.WireUpDomainEventHandlers();

                try
                {

                    var applicationDbContext = serviceProvider.GetRequiredService<ApplicationWriteDbContext>();
                    applicationDbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating or initializing the database.");
                }
            }
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
            

            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}