using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public interface IGaming
    {
        Game Add(Game game);
        IEnumerable<Game> Get();
        Game? Get(int id);
        Game? Delete(int id);
        Game? Update(int id, Game updatedGame);
    }
}
