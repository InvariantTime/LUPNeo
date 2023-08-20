using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.DependencyInjection
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class ServiceConfigureAttribute : Attribute
	{
	}
}
