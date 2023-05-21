using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity  // T'nin reference type yani class olacağının garantisini veriyoruz ve ayrıca geybyıd metodu için base entity diyoruz (şartı daraltıyoruz). Aslında burda gerek yok ama garantiye alıyoruz.
    {
        private readonly ECommerceAPIDbContext _context;

        public WriteRepository(ECommerceAPIDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>(); // Dbset T türünde entity alacaktır. T yerine hangi entity gelirse o entity'e ait tabloyu bizlere verecektir.

        public async Task<bool> AddAsync(T model)
        {
          EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added; // bu işlem sayesinde sonuç olarak true yada false dönecektir.
        }

        public async Task<bool> AddRangeAsync(List<T> models)
        {
           await Table.AddRangeAsync(models);
            return true;
        }

        public bool Remove(T model)
        {
           EntityEntry entityEntry = Table.Remove(model); //Silme işlemi için bunu yapmamız yeterli.
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<T> models)
        {
            Table.RemoveRange(models);
            return true;
        }

        public async Task<bool> RemoveAsync(string id)
        {
           T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id)); // önce silinmesi için veriyi bulmamız gerekiyor.
            return Remove(model); // Kendi fonksiyonumuzu çağırıyoruz. (Daha profosyonelce)
        }

        public bool Update(T model)
        {
           EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified; // Güncelleme işleminin sonucu true yada false döner.
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    }
}
