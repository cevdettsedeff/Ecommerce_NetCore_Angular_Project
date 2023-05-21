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
        IQueryable<T> GetAll(bool tracking = true); //list kullanırsak(IEnumerable) memory'yi kullanır. Best practices açısından IQueryable kullan. Ayrıca tracking işlemini daha sonra kapatmak için tracking parametresi oluşturuyoruz.
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true); //Where şartı için bu metodu kullanacağız. Çoğul için queryable kullanıyoruz. Ayrıca tracking işlemini daha sonra kapatmak için tracking parametresi oluşturuyoruz.
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true); //Where şartını tekil kulllanıyoruz. Ayrıca tracking işlemini daha sonra kapatmak için tracking parametresi oluşturuyoruz.
        Task<T> GetByIdAsync(string id, bool tracking = true); //id'ye göre getirme işlemi yapıyoruz. Ayrıca tracking işlemini daha sonra kapatmak için tracking parametresi oluşturuyoruz.

        // Read işlemlerinde genel olarak bu 4 metod kullanılır. Son iki metodu async kullanıyoruz.

        //Ef core üzerinde yapılan her işlem track edilir.
        //Read işlemlerinde tracking mekanizmasının çalışması gereksizdir. Bunun için read işlemlerinde track edilmez.
        // Yapılan değişiklikler tracking mekanizması kapalıysa(false ise) veritabanına kaydedilmez. 
    }
}
