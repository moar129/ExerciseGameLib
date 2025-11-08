namespace GameLib
{
    public class Game
    {
        private string _title;
        private string _genre;
        private int _releaseYear;
        public int Id { get; set; }
        public string Title 
        {
            get 
            {
                return _title;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentNullException("Title cannot be null");
                }
                if (value.Length < 2 ) {
                    throw new ArgumentException("Must be at least 1 char long");
                }
                _title = value;
            } 
        }
        public string Genre 
        { 
            get { return _genre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Genre cannot be null");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Must be at least 1 char long");
                }
                _genre = value;
            }
        }
        public int ReleaseYear 
        { 
            get { return _releaseYear; }
            set
            {
                if (value < 1950 || value > DateTime.Now.Year)
                {
                    throw new ArgumentOutOfRangeException($"Release year must be between 1950 and {DateTime.Now.Year}");
                }
                _releaseYear = value;
            } 
        }
        public Game(string title, string genre, int releaseYear)
        {
            Title = title;
            Genre = genre;
            ReleaseYear = releaseYear;
        }
        public Game() { }   
    }
}
