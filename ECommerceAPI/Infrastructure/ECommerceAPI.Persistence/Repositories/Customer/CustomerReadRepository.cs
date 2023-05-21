using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository //İnterface bunun soyut yapılanmasdıdır. ReadRepository<Customer> 'ı ICustomer sayesinde kullanıyoruz.
    {
        public CustomerReadRepository(ECommerceAPIDbContext context) : base(context)
        {

        }
    }
}
