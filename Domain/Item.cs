using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class Item
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public virtual User User { get; set; }
		public virtual Project Project { get; set; }
	}
}
