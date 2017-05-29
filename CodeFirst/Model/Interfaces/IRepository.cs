using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
	public interface IRepository<T>
	{
		IEnumerable<T> Get();
		T Add(T ob);
		T Delete(int id);
	}
}
