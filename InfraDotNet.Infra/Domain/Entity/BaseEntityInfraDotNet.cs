using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraDotNet.Domain.Entity
{
    public abstract class BaseEntityInfraDotNet<TPrimaryKey> where TPrimaryKey : IComparable<TPrimaryKey>
    {

        protected BaseEntityInfraDotNet()
        {            
        }

        protected BaseEntityInfraDotNet(TPrimaryKey id)
        {
            Id = id;
        }

        [Key]
        public TPrimaryKey Id { get; set; }       
        
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set;}

    }
}
