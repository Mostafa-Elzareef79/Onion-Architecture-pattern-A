using Employee.Application.Interfaces;
using Employee.Domain.Entitties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persestance.Context
{
    public class EmployeeDbContext : DbContext, IEmployeeDbContext
    {
        public EmployeeDbContext( DbContextOptions options):base(options)
        {
            
        }
        public DbSet<ClassOfEmployee> employees { get ; set ; }

        async Task<int> IEmployeeDbContext.SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
