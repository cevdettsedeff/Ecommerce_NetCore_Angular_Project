using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Contexts
{
    public class ECommerceAPIDbContext : DbContext
    {
        public ECommerceAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) // bu metodun oluşturulma sebebi Interceptor oluşturmaktır.
        {
            // ChangeTracker entityler üzerinden yapılan değişikliklerin ya da yeni eklenen verinin yakalanmasını saplayan property'dir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.
            var datas = ChangeTracker.Entries<BaseEntity>(); //Sürece giren tüm baseEntityleri yakalarız.

           foreach(var data in datas)
            {
                _ = data.State switch //switchten gelen veriyi bir değişkene atamamak için _(discard) özelliğini kullanıyoruz.
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow
                };
            }
            
           // Herhangi bir veri kaydederken ya da eklerken SaveChangesAsync metodu tetiklenecek ve foreach içindeki scope'a girerek eklemeyse CreatedDate, güncellemeyse UpdatedDate değerini anlık olarak alacak. Bu sayede bizim ek olarak veri girmemize gerek kalmayacak.
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
