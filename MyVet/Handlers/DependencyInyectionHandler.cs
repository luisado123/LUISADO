using Infraestructure.Core.Data;
using Infraestructure.Core.Repository;
using Infraestructure.Core.Repository.Interface;
using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interface;
using Microsoft.Extensions.DependencyInjection;
using MyVet.Domain.Services;
using MyVet.Domain.Services.Interface;

namespace MyVet.Handlers
{
    public static class DependencyInyectionHandler
    {

        
        public static void DependencyInyectionConfig(IServiceCollection services)
        {
            
            services.AddScoped<UnitOfWork, UnitOfWork>();

            //Infraestructure
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            //esto es lo mismo que creamos en el startup,ahora solo bastara con inyectar  esta dependencia en 
            //Startup.cs
            services.AddTransient<SeedDb>();

            //Domain,es decir los servicios
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IRolServices, RolServices>();
            services.AddTransient<IPetServices,PetServices>();
            services.AddTransient<IDateServices, DateServices>();
        }
    }
}
