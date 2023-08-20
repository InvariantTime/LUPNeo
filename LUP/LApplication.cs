using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP
{
	public sealed class LApplication
	{
		public static LApplication? Current { get; private set; }

		internal LApplication()
		{
		}

		
		public void Run()
		{
		}
	}
}
