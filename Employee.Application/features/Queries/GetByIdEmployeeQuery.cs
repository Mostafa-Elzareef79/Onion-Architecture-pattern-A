using Employee.Application.Interfaces;
using Employee.Domain.Entitties;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.features.Queries
{
    public class GetByIdEmployeeQuery:IRequest<ClassOfEmployee>
    {
        public int Id { get; set; }
        public class GetByIdEmployeeQueryHandeler : IRequestHandler<GetByIdEmployeeQuery, ClassOfEmployee>
        {
            private readonly IEmployeeDbContext context;
            public GetByIdEmployeeQueryHandeler(IEmployeeDbContext context)
            {
                this.context = context;

            }
            public async Task<ClassOfEmployee> Handle(GetByIdEmployeeQuery request, CancellationToken cancellationToken)
            {
               var emp=context.employees.SingleOrDefault(x=>x.Id==request.Id);
                return emp;
            }
        }
    }
}
