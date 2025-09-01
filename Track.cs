using NAudio.CoreAudioApi.Interfaces;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metal_Player
{
    public class Track
    {
        public string Name { get; private set; }
        public string Album { get; private set; }
        public string Artist { get; private set; }
        public string Genre { get; private set; }
        public string Country { get; private set; }
        public bool Stop {  get; set; }
        public bool Pause { get; set; }
        public bool Play { get; set; }

        private string _path;

        private IWavePlayer _player;
        private AudioFileReader _audioFileReader;
        List<Track> _tracks;

        public Track(string name, string album, string artist, string genre, string country, string Path)
        {
            Name = name;
            Album = album;
            Artist = artist;
            Genre = genre;
            Country = country;
            _path = Path;

            Stop = true;
            Play = false;
            Pause = true;
        }
        public void btnPlay(object o, EventArgs args)
        {
            for(int i = 0; i < _tracks.Count; i++)
            {
                if(_tracks[i] == this)
                {
                    if(_tracks[i].Play)
                    {
                        _tracks[i].Play = false;
                        _tracks[i].Pause = true;
                        _tracks[i].GetPause();
                    }
                    else if(_tracks[i].Pause)
                    {
                        _tracks[i].Play = true;
                        _tracks[i].Pause = false;
                        _tracks[i].GetPlay();
                    }
                }
                else
                {
                    _tracks[i].GetStop();
                }
            }
            
        }

        public void GetPause()
        {
            if(_player != null)
            {
                _player.Pause();
            }
        }

        public void GetPlay()
        {
            if (_player == null)
            {
                _audioFileReader = new AudioFileReader(_path);
                _player = new WaveOutEvent();
                _player.Volume = 0.5f;
                _player.Init(_audioFileReader);
                _player.Play();
            }
            else
            {
                _player.Play();
            }
        }

        public void GetStop()
        {
            if (_player != null)
            {
                if (_player != null)
                {
                    _player.Stop();
                    _player.Dispose();
                    _player = null;
                }

                if (_audioFileReader != null)
                {
                    _audioFileReader.Dispose();
                    _audioFileReader = null;
                }
            }
        }
    }
}
