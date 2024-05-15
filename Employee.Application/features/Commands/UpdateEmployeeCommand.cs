using Employee.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.features.Commands
{
    public class UpdateEmployeeCommand:IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public class UpdateEmployeeCommandHandeler : IRequestHandler<UpdateEmployeeCommand, int>
        {
            private readonly IEmployeeDbContext context;
            public UpdateEmployeeCommandHandeler(IEmployeeDbContext context)
            {
                this.context = context;

            }

            public  async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
            {
              var prod=context.employees.SingleOrDefault(x=>x.Id==request.Id);  
                prod.Name=request.Name;

                context.employees.Update(prod);
                return request.Id;
            }
        }
    }
}
