
using Microsoft.EntityFrameworkCore;
using online_pricing_calculator_api.Application.Services;
using online_pricing_calculator_api.Domain.Interfaces;
using online_pricing_calculator_api.Infrastructure.Data;
using online_pricing_calculator_api.Infrastructure.Repositories;

namespace online_pricing_calculator_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    policy =>
                    {
                        policy
                            .WithOrigins("http://localhost:3000")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });


            // Add services to the container.
            builder.Services.AddScoped<IItemRepository, ItemRepository>();
            builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();

            builder.Services.AddSingleton<DiscountEngine>();
            builder.Services.AddScoped<PricingService>();

            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseCors("AllowReactApp");
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
