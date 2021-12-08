using InfraDotNet.Domain.Repositories;
using InfraDotNet.ProjectTest.DomainTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraDotNet.ProjectTest.DomainTest.Repositories
{
    public interface IStudentRepository : IBaseRepositoryInfraDotNet<Student,string>
    {
    }
}
