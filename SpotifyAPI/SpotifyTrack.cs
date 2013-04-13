using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libspotifydotnet;

namespace SpotifyAPI
{
    public class SpotifyTrack
    {
        /// <summary>
        /// The internal track pointer. There's a pretty big chance you won't need to get this unless you are hacking something together with libspotifydotnet.
        /// </summary>
        public readonly IntPtr internalTrack;

        /// <summary>
        /// Creates an Track that can be passed to a MusicStream. Usually created by another function in the SpotifyAPI library, for example SpotifySession.ResolveURItoTrack(URI).
        /// </summary>
        /// <param name="nativeTrackPointer">The native (internal) track pointer created by libspotifydotnet.</param>
        public SpotifyTrack(IntPtr nativeTrackPointer)
        {
            internalTrack = nativeTrackPointer;
        }

        /// <summary>
        /// Checks whether the track metadata has been loaded. This is equivalent to checking if the error code isn't SP_ERROR_IS_LOADING.
        /// </summary>
        public bool isLoaded()
        {
            return libspotify.sp_track_is_loaded(internalTrack);
        }

        /// <summary>
        /// Retrieve the current status/error code.
        /// </summary>
        public libspotify.sp_error getStatus()
        {
            return libspotify.sp_track_error(internalTrack);
        }

        public bool isPlaceholder()
        {
            //return libspotify.sp_track_is_placeholder(internalTrack); MISSING FROM LIBSPOTIFY.NET
            return false;
        }
    }
}
