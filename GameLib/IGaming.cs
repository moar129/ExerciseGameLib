using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public interface IGaming<T>
    {
        T Add(T game);
        IEnumerable<T> Get();
        T? Get(int id);
        T? Delete(int id);
        T? Update(int id, T updatedGame);
    }
}
