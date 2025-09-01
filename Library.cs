using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib;

namespace Metal_Player
{
    public class Library
    {
        public List<Track> Tracks { get; private set; }
        private string _path;

        public string GetPath
        {
            get { return _path; }
        }
        public Library()
        {
            Tracks = new List<Track>();
            _path = "";
        }

        public void AppendTrack(string PathToTracks)
        {
            _path = PathToTracks;
            foreach (string file in Directory.GetFiles(_path, "*.mp3").Concat(Directory.GetFiles(_path, "*.wav")))
            {
                string filePath = Path.GetFullPath(file);
                var someFile = TagLib.File.Create(filePath);

                string fileName = someFile.Tag.Title;
                string fileAlbum = someFile.Tag.Album;
                string fileArtist = someFile.Tag.FirstPerformer;
                string fileGenre = someFile.Tag.FirstGenre;
                string fileCountry = someFile.Tag.MusicBrainzReleaseCountry;

                if (fileName == "" || fileName == null) fileName = Path.GetFileNameWithoutExtension(file);
                if(fileAlbum == "" || fileAlbum == null) fileAlbum = "Unknown";
                if (fileArtist == "" || fileArtist == null) fileArtist = "Unknown";
                if (fileGenre == "" || fileGenre == null) fileGenre = "Unknown";
                if(fileCountry == "" || fileCountry == null) fileCountry = "Unknown";

                Track track = new Track(fileName, fileAlbum, fileArtist, fileGenre, fileCountry, file);
                Tracks.Add(track);
            }
        }
    }
}
