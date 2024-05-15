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
    public class GetAllEmployeesQuary:IRequest<ICollection<ClassOfEmployee>>
    {
        public class GetAllEmployeesQuaryHandeler : IRequestHandler<GetAllEmployeesQuary, ICollection<ClassOfEmployee>>
        {    private readonly IEmployeeDbContext context;
            public GetAllEmployeesQuaryHandeler(IEmployeeDbContext context)
            {
                this.context = context;

            }
        
public async Task<ICollection<ClassOfEmployee>> Handle(GetAllEmployeesQuary request, CancellationToken cancellationToken)
            {
               var emplys=context.employees.ToList();
                 return emplys;
            }
        }
        }
    }


