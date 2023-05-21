using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity // T'nin reference type yani class olacağının garantisini veriyoruz ve ayrıca geybyıd metodu için base entity diyoruz (şartı daraltıyoruz).
    {
        private readonly ECommerceAPIDbContext _context;

        public ReadRepository(ECommerceAPIDbContext context)
        {
            _context = context;
        }

        // 

        public DbSet<T> Table => _context.Set<T>(); // Dbset T türünde entity alacaktır. T yerine hangi entity gelirse o entity'e ait tabloyu bizlere verecektir.

        public IQueryable<T> GetAll(bool tracking = true) // Direkt olarak table getirirsek bütün verileri getirmiş oluruz.
        {
            var query = Table.AsQueryable();
            //Burada tracking işlemini kapatarak gereksiz bir maliyetten kurtuluyoruz.
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }  

        public async Task<T> GetByIdAsync(string id, bool tracking = true)        // => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        {
            var query = Table.AsQueryable();
            if(!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            //await query.FindAsync(Guid.Parse(id)); -> Burada bunu kullanamayız. Çünkü query de FindAsync metodu yoktur. Bu yüzden marker kullanarak baseEntity üzerinden bulma işlemini gerçekleştiririz.

        }
        //Reflection yerine BaseEntity işaretleyici (marker) türünden istifade ederek BaseEntity içinde olan Id ile parametre olarak gelen id'yi sorguluyoruz.

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        } 

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
           var query = Table.Where(method);
            if(!tracking)
                query = query.AsNoTracking();
            return query;
        }
        
        // Yapılan değişiklikler tracking mekanizması kapalıysa(false ise) veritabanına kaydedilmez. 
    }
}
