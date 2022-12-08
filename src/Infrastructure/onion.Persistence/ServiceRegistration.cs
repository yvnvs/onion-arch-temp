using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using onion.Application.Interfaces.Repository;
using onion.Persistence.Context;
using onion.Persistence.Repository;

namespace onion.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("memoryDb"));
            services.AddTransient<IProductRepository, ProductRepository>();
        }

        //public static void AddPersistenceServices(this IServiceCollection serviceCollection)
        //{
        //    serviceCollection.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("memoryDb"));
        //    serviceCollection.AddTransient<IProductRepository, ProductRepository>();
        //}
    }
}
