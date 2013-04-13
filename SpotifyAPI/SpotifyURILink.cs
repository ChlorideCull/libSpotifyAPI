using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libspotifydotnet;

namespace SpotifyAPI
{
    public class SpotifyURILink
    {
        /// <summary>
        /// The internal link struct. There's a pretty big chance you won't need to get this unless you are hacking something together with libspotifydotnet.
        /// </summary>
        public readonly IntPtr InternalLinkStruct;
        private string _URI;
        /// <summary>
        /// Gets the type of link.
        /// </summary>
        public readonly libspotify.sp_linktype LinkType;
        /// <summary>
        /// Create a Link object that can be used in the library.
        /// </summary>
        /// <param name="URI">A Spotify URI, for example "spotify:track:59qiaXIrZMvor2T7fkupLp".</param>
        public SpotifyURILink(string URI)
        {
            InternalLinkStruct = libspotify.sp_link_create_from_string(URI); //link is a sp_link struct which isn't documented.
            _URI = URI;
            LinkType = libspotify.sp_link_type(InternalLinkStruct);
        }
    }
}
