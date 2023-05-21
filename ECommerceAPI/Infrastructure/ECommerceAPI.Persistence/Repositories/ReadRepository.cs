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

        public IQueryable<T> GetAll() => Table; // Direkt olarak table getirirsek bütün verileri getirmiş oluruz.
        

        public async Task<T> GetByIdAsync(string id) => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id)); //Reflection yerine BaseEntity işaretleyici türünden istifade ederek BaseEntity içinde olan Id ile parametre olarak gelen id'yi sorguluyoruz.
        

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method) => await Table.FirstOrDefaultAsync(method);
        

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method) => Table.Where(method);
        
    }
}
