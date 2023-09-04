using LUP.DependencyInjection.CallSites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.DependencyInjection.Factories
{
    public interface IServiceFactory
    {
        object? CreateService(InstanceCallsite callsite, IServiceScope scope);
    }
}
