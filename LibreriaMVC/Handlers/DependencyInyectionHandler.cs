using Common.Utils.RestServices;
using Common.Utils.RestServices.Interface;

using Microsoft.Extensions.DependencyInjection;
using MyVet.Domain.Services;
using MyVet.Domain.Services.Interface;

namespace MyVet.Handlers
{
    public static class DependencyInyectionHandler
    {

        
        public static void DependencyInyectionConfig(IServiceCollection services)
        {
            
            

          

           // services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
          

            //Domain,es decir los servicios
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IRolServices, RolServices>();
           
       
            services.AddTransient<IBooksServices, BooksServices>();
            services.AddTransient<IAutoresServices, AutoresServices>();
           services.AddTransient<IEditorialServices, EditorialServices>();

            //Rest Services---consumibles
            services.AddTransient<IRestServices, RestServices>();
        }
    }
}
