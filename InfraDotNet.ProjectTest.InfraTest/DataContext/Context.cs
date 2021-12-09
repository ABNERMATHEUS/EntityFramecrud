using InfraDotNet.ProjectTest.DomainTest.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraDotNet.ProjectTest.InfraTest.DataContext
{
    public class Context : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}
