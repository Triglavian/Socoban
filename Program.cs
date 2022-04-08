using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Socoban
{
	class Program
	{
		static void Main(string[] args)
		{
			Rendering rendering = new Rendering();
			while (true)
			{
				rendering.Draw(i);
				Thread.Sleep(2000);
			}
		}
	}
}
