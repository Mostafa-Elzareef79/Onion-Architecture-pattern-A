using Employee.Domain.Entitties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Employee.Application.Interfaces
{
    public interface IEmployeeDbContext
    {
      public  DbSet<ClassOfEmployee> employees { get; set; }
      public  Task<int> SaveChanges();
    }
}
