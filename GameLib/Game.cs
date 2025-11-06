namespace GameLib
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public Game(string title, string genre, int releaseYear)
        {
            Title = title;
            Genre = genre;
            ReleaseYear = releaseYear;
        }
    }
}
