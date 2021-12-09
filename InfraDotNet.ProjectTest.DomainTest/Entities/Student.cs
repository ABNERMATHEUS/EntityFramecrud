
using InfraDotNet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraDotNet.ProjectTest.DomainTest.Entities
{
    public class Student : BaseEntityInfraDotNet<string>
    {
        public Student(string name) : base()
        {
            this.Id = Guid.NewGuid().ToString();
            Name = name;
        }
        public string Name { get; set; }
    }
}
