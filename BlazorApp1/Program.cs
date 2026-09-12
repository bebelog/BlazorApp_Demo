using BlazorApp_Demo.Components;
using eShop.DataStore.HardCode;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.SearchProductScreen;

namespace BlazorApp_Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddTransient<IProductRepository, ProductRepository>();
            builder.Services.AddTransient<ISearchProduct, SearchProduct>();
            builder.Services.AddTransient<IViewProduct, ViewProduct>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>() .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
