using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_3
{
    class MusicCatalog
    {
        private Hashtable catalog = new Hashtable();

        public void AddDisc(string discName)
        {
            if (!catalog.ContainsKey(discName))
            {
                catalog.Add(discName, new MusicDisc(discName));
            }
            else
            {
                Console.WriteLine($"Disc '{discName}' already exists.");
            }
        }

        public void RemoveDisc(string discName)
        {
            if (catalog.ContainsKey(discName))
            {
                catalog.Remove(discName);
            }
            else
            {
                Console.WriteLine($"Disc '{discName}' not found.");
            }
        }

        public void AddSongToDisc(string discName, Song song)
        {
            if (catalog.ContainsKey(discName))
            {
                var disc = (MusicDisc)catalog[discName];
                disc.AddSong(song);
            }
            else
            {
                Console.WriteLine($"Disc '{discName}' not found.");
            }
        }

        public void RemoveSongFromDisc(string discName, string songTitle)
        {
            if (catalog.ContainsKey(discName))
            {
                var disc = (MusicDisc)catalog[discName];
                disc.RemoveSong(songTitle);
            }
            else
            {
                Console.WriteLine($"Disc '{discName}' not found.");
            }
        }

        public void ViewAllCatalog()
        {
            foreach (DictionaryEntry entry in catalog)
            {
                var disc = (MusicDisc)entry.Value;
                disc.ViewSongs();
                Console.WriteLine();
            }
        }

        public void ViewDisc(string discName)
        {
            if (catalog.ContainsKey(discName))
            {
                var disc = (MusicDisc)catalog[discName];
                disc.ViewSongs();
            }
            else
            {
                Console.WriteLine($"Disc '{discName}' not found.");
            }
        }

        public void SearchByArtist(string artist)
        {
            Console.WriteLine($"Searching for artist: {artist}");
            foreach (DictionaryEntry entry in catalog)
            {
                var disc = (MusicDisc)entry.Value;
                var songs = disc.FindSongsByArtist(artist);
                foreach (var song in songs)
                {
                    Console.WriteLine($"Found in disc '{disc.DiscName}': {song}");
                }
            }
        }
    }
}
