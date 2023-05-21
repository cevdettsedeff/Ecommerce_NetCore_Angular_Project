using ECommerceAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity //IRepository'de olduğu gibi T'nin reference type yani class olacağının garantisini veriyoruz ve ayrıca geybyıd metodu için base entity diyoruz (şartı daraltıyoruz).
    {
        // Veritabanındaki Select işlemlerini burada yazacağız.
        IQueryable<T> GetAll(); //list kullanırsak(IEnumerable) memory'yi kullanır. Best pratices açısından IQueryable kullan.
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method); //Where şartı için bu metodu kullanacağız. Çoğul için queryable kullanıyoruz.
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method); //Where şartını tekil kulllanıyoruz.
        Task<T> GetByIdAsync(string id); //id'ye göre getirme işlemi yapıyoruz.

        // Read işlemlerinde genel olarak bu 4 metod kullanılır. Son iki metodu async kullanıyoruz.

    }
}
