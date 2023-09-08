using LUP.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP
{
    public static class ServicesExtension
    {
        public static void Configure<T>(this IServiceCollection services, Action<T> config)
        {
        }


        public static void AddProcessor<T>(T processor) where T : IApplicationStage
        {
            AddProcessor(processor, _ => { });
        }


        public static void AddProcessor<T>(T processor, Action<ProcessorConfiguration<T>> configAction) where T : IApplicationStage
        {

        }
    }
}
