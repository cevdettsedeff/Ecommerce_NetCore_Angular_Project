using ECommerceAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities
{
    public class File : BaseEntity
    {
        //Not mapped sayesinde baseEntity'den gelen updatedDate'i kullanmayacağız.
        [NotMapped]
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }

        public string Storage { get; set; } 
        public string FileName { get; set; }
        public string Path { get; set; }

    }
}
