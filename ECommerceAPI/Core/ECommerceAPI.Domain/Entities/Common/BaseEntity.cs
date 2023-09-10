using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        virtual public DateTime UpdatedDate { get; set; }// tüm entitylerde kullanmak istemediğimiz için virtual kullanıyoruz.  
        
        // Interceptor kullanarak bu değerleri otomatik olarak araya girip dolduracağız. 
    }
}
