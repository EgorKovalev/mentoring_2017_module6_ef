using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
	public interface IRepository<T>
	{
		IEnumerable<T> Get { get; }
		T Save(T ob);
		T Delete(int id);
	}
}
