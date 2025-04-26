namespace Lab9_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicCatalog catalog = new MusicCatalog();

            catalog.AddDisc("Best of Rock");
            catalog.AddDisc("Chill Vibes");

            catalog.AddSongToDisc("Best of Rock", new Song("Bohemian Rhapsody", "Queen", new TimeSpan(0, 5, 55)));
            catalog.AddSongToDisc("Best of Rock", new Song("Smoke on the Water", "Deep Purple", new TimeSpan(0, 5, 40)));
            catalog.AddSongToDisc("Chill Vibes", new Song("Sunset Lover", "Petit Biscuit", new TimeSpan(0, 3, 58)));

            catalog.ViewAllCatalog();

            catalog.SearchByArtist("Queen");

            catalog.RemoveSongFromDisc("Best of Rock", "Smoke on the Water");
            catalog.ViewDisc("Best of Rock");

            catalog.RemoveDisc("Chill Vibes");
            catalog.ViewAllCatalog();
        }
    }
}
