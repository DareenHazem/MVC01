using DemoSession1.CustomMiddlewares;

namespace DemoSession1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // ----------- Custom Middleware -----------
            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Hello 1");
            //    await next(context);
            //    Console.WriteLine("Bye 1");
            //});

            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Hello 2");
            //    await next(context);
            //    Console.WriteLine("Bye 2");
            //});

            //app.Run();


            app.UseMiddleware<RequestTimingMiddleware>();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllers();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id:int?}")
                .WithStaticAssets();

            //app.MapControllerRoute(
            //    name: "Member",
            //    pattern: "Player/{action=Index}",
            //    defaults: new 
            //    { 
            //        Controller = "Members",
            //        action="index"
            //    });

            app.Run();
        }
    }
}
