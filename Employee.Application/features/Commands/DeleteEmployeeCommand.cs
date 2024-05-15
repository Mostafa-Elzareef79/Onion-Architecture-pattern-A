using Employee.Application.Interfaces;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.features.Commands
{
  
    public class DeleteEmployeeCommand:IRequest<int>
    {
        public int Id { get; set; }
    }
    public class DeleteEmployeeCommandHandeler : IRequestHandler<DeleteEmployeeCommand, int>
    {
        private readonly IEmployeeDbContext context;
        public DeleteEmployeeCommandHandeler(IEmployeeDbContext context)
        {
            this.context = context;

        }
        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
           var prod= context.employees.SingleOrDefault(x=>x.Id == request.Id);
            if (prod != null)
            {
               context.employees.Remove(prod);
                await context.SaveChanges();
                return prod.Id;
            }
            return 0;
        }
    }
}
