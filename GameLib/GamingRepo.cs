using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class GamingRepo: IGaming<Game>
    {
        private static int _nextId = 1;
        private List<Game> _games = new List<Game>();
        public GamingRepo() { }
        public Game Add(Game game)
        {
            game.Id = _nextId++;
            _games.Add(game);
            return game;
        }
        public IEnumerable<Game> Get()
        {
            IEnumerable<Game> games = new List<Game>(_games);
            return games;
        }

        public Game? Get(int id)
        {
            return _games.FirstOrDefault(g => g.Id == id);
        }

        public Game? Delete(int id)
        {
            Game? game = Get(id);
            if (game != null)
            {
                _games.Remove(game);   
            }
            return game;
        }
        public Game? Update(int id, Game updatedGame)
        {
            Game? game = Get(id);
            if (game != null)
            {
                game.Title = updatedGame.Title;
                game.Genre = updatedGame.Genre;
                game.ReleaseYear = updatedGame.ReleaseYear;
            }
            return game;
        }
    }
}
