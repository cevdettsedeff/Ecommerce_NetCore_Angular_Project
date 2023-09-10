using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using file = ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Persistence.Repositories
{
    public class FileWriteRepository : WriteRepository<file.File>, IFileWriteRepository
    {
        public FileWriteRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
