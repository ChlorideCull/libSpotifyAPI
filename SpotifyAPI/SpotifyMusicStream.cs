using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpotifyAPI
{
    public class SpotifyMusicStream : System.IO.MemoryStream
    {
        /// <summary>
        /// The samplerate in Samples/Second
        /// </summary>
        public int Samplerate;
        public SpotifyMusicStream(int _Samplerate)
        {
            Samplerate = _Samplerate;
        }
    }
}
