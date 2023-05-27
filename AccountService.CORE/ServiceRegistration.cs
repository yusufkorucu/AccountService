using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AccountService.Domain
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            collection.AddAutoMapper(Assembly.GetExecutingAssembly());

        }
    }
}
