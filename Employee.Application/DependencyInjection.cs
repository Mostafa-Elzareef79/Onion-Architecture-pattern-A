using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection servise)
        {
          //make register for every mediaR exepxt made alot of mediatR for every handel and command or queries
            servise.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
