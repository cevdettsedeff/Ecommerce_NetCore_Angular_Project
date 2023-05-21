using ECommerceAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity //IRepository'de olduğu gibi T'nin reference type yani class olacağının garantisini veriyoruz ve ayrıca geybyıd metodu için base entity diyoruz (şartı daraltıyoruz).
    {
        // Veritabanındaki Ekleme, silme gibi işlemleri burada yazacağız.

        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> models);
        bool Remove(T model); // Silme metodu burada async değildir.
        bool RemoveRange(List<T> models); // Birden fazla veriyi silmek için Range kullanırız.
        Task<bool> RemoveAsync(string id);
        bool Update(T model);
        Task<int> SaveAsync(); //Kaydetme işlemi için gereklidir.


        // Ekleme, silme gibi işlemler başarılı olduğunda bize true değer döndürecektir.
    }
}
