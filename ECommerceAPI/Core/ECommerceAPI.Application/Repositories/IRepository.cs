using ECommerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Repositories
{
    //Repository Design Pattern temelinde Solid'e aykırıdır.
    //Bu yüzden IReadRepository ve IWriteRepository isimli iki arayüz daha tanımlıyoruz. (Solid'i daha az ezmek için)
    public interface IRepository<T> where T : BaseEntity //IRepository'e vereceğimiz T Entity'sinin class olma garantisini veriyoruz ve ayrıca geybyıd metodu için base entity diyoruz (şartı daraltıyoruz).
    {
        // Buraya evrensel olan işlemleri tanımlıyoruz.

        DbSet<T> Table { get; }
    }
}
