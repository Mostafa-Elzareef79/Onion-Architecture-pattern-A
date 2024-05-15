using Employee.Application.Interfaces;
using Employee.Domain.Entitties;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.features.Commands
{
    public class AddEmployeeCommand:IRequest<int>
    {
        public string Name { get; set; }
  
        public class AddEmployeeCommandHandeler : IRequestHandler<AddEmployeeCommand, int>
        {
            private readonly IEmployeeDbContext context;
            public AddEmployeeCommandHandeler(IEmployeeDbContext context)
            {
                this.context  = context;  
                
            }
            public async Task<int> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
            {
                var prod=new ClassOfEmployee();
                prod.Name = request.Name;
              

                 context.employees.Add(prod);
                await context.SaveChanges();
                return prod.Id;
               
            }
        }
       

        }
    }

