using GameStore.Frontend.Clients;
using GameStore.Frontend.Components;
using GameStore.Frontend.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Frontend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Configure DbContext
            builder.Services.AddDbContext<GenreDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));  // no need

            var gameStoreApiUrl = builder.Configuration["GameStoreApiUrl"] ??
                throw new Exception("GameStoreApiUrl is not set");

            // Register HTTP clients
            builder.Services.AddHttpClient<GamesClient>(client =>
                client.BaseAddress = new Uri(gameStoreApiUrl));

            builder.Services.AddHttpClient<GenresClient>(client =>
                client.BaseAddress = new Uri(gameStoreApiUrl));

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

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
