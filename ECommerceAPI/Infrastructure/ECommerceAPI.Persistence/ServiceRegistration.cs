using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence
{
    public static class ServiceRegistration
    {
        // Burası bizim IoC konteynırımızdır.
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            //Singleton yaşam döngüsünde nesne bir defa oluşturulur ve hep kullanılır.
            //Scoped yaşam döngüsünde gelen isteğe tek bir nesne döner ve sonunda expose edilir.
            //Transient yaşam döngüsünde ise bir nesne bir defa kullanılır ve expose edilir. Yeni talep gelirse tekrardan yeni bir nesne oluşturulur.

            //Buradaki örnekte scoped kullanmak en doğrusudur. Zaten DbContext default olarak Scoped yaşam döngüsündedir.
        }
    }
}
