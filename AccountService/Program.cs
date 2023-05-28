using AccountService.Data.Data;
using AccountService.Data.Repository;
using AccountService.Data.Repository.GenericRepository;
using AccountService.Domain;
using AccountService.Domain.Services.User.Abstract;
using AccountService.Domain.Services.User.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using static AccountService.Domain.Commands.User.UserAddCommand;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddApplicationServices();
        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        builder.Services.AddDbContext<AccountAppDbContext>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserAddressRepository, UserAddressRepository>();

        builder.Services.AddControllers();
        builder.Services.AddScoped<IUserService, UserService>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}