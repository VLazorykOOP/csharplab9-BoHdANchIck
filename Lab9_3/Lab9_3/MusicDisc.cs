using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_3
{
    class MusicDisc
    {
        public string DiscName { get; set; }
        private List<Song> Songs { get; set; }

        public MusicDisc(string discName)
        {
            DiscName = discName;
            Songs = new List<Song>();
        }

        public void AddSong(Song song)
        {
            Songs.Add(song);
        }

        public void RemoveSong(string title)
        {
            Songs.RemoveAll(s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public void ViewSongs()
        {
            Console.WriteLine($"Disc: {DiscName}");
            foreach (var song in Songs)
            {
                Console.WriteLine($" - {song}");
            }
        }

        public List<Song> FindSongsByArtist(string artist)
        {
            return Songs.FindAll(s => s.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase));
        }
    }
}
