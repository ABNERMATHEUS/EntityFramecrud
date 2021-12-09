using InfraDotNet.Infra.Repository;
using InfraDotNet.ProjectTest.DomainTest.Entities;
using InfraDotNet.ProjectTest.DomainTest.Repositories;
using InfraDotNet.ProjectTest.InfraTest.DataContext;
using Microsoft.EntityFrameworkCore;

namespace InfraDotNet.ProjectTest.InfraTest.Repositories
{
    public class StudentRepository : BaseRepositoryInfraDotNet<Student,string>, IStudentRepository
    {
        public StudentRepository(Context dbContext) : base(dbContext)
        {
        }
    }
}
