using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libspotifydotnet;
using System.Runtime.InteropServices;

namespace SpotifyAPI
{
    public class SpotifySession
    {
        private libspotify.sp_error temp;
        private IntPtr spotsession;
        /// <summary>
        /// This stream will be written to when music data is recieved.
        /// </summary>
        public static SpotifyMusicStream MusicStream = new SpotifyMusicStream(0);

        /// <summary>
        /// Initiate a new Spotify Session using the provided configuration, username and password. Please note that using multiple sessions per application is unsupported.
        /// </summary>
        /// <param name="Username">The username to login with.</param>
        /// <param name="Password">The password to login with. You may not store this as plaintext according to the libspotify Terms of Use.</param>
        /// <param name="Configuration">The session configuration to use.</param>
        public SpotifySession(string Username, string Password, SpotifySessionConfig Configuration)
        {
            libspotify.sp_session_config sessionconfig = new libspotify.sp_session_config();
            sessionconfig.api_version = Configuration.APIVersion;
            IntPtr apikey = Marshal.AllocHGlobal(Configuration.APIKey.Length);
            Marshal.Copy(Configuration.APIKey, 0, apikey, Configuration.APIKey.Length);
            sessionconfig.application_key = apikey;
            sessionconfig.application_key_size = Configuration.APIKey.Length;
            sessionconfig.cache_location = Configuration.CacheLocation;
            sessionconfig.device_id = Configuration.DeviceID;
            sessionconfig.compress_playlists = Configuration.CompressPlaylists;
            sessionconfig.dont_save_metadata_for_playlists = Configuration.DontSaveMetadataForPlaylists;
            sessionconfig.initially_unload_playlists = Configuration.InitiallyUnloadPlaylists;
            sessionconfig.settings_location = Configuration.SettingsLocation;
            sessionconfig.user_agent = Configuration.UserAgent;
            //TODO: Implement callbacks to get music streams etc.
            //TODO: Fix the proxy below, needs to get type.
            /*sessionconfig.proxy = Configuration.Proxy.GetProxy(new Uri("http://spotify.com/")).AbsoluteUri; //Should be correct. I think.
            sessionconfig.proxy_username = Configuration.Proxy.Credentials.GetCredential(new Uri("http://spotify.com/"),*/
            sessionconfig.ca_certs_filename = Configuration.CACertsName;
            libspotify.sp_session_callbacks callbacks = new libspotify.sp_session_callbacks();
            callbacks.music_delivery = Marshal.GetFunctionPointerForDelegate(mdd);
            IntPtr callbacksNative = Marshal.AllocHGlobal(Marshal.SizeOf(callbacks));
            Marshal.StructureToPtr(callbacks, callbacksNative, true);
            sessionconfig.callbacks = callbacksNative;

            temp = libspotify.sp_session_create(ref sessionconfig, out spotsession);
            if (temp != libspotify.sp_error.OK)
            {
                SpotifyExceptions.SessionCreateFailedException exc = new SpotifyExceptions.SessionCreateFailedException(libspotify.sp_error_message(temp));
                throw exc;
            }
            temp = libspotify.sp_session_login(spotsession, Username, Password, false, null);
            if (temp != libspotify.sp_error.OK)
            {
                SpotifyExceptions.LoginFailedException exc = new SpotifyExceptions.LoginFailedException(libspotify.sp_error_message(temp));
                throw exc;
            }
        }

        public SpotifyTrack ResolveURItoTrack(SpotifyURILink link)
        {
            IntPtr trck = libspotify.sp_link_as_track(link.InternalLinkStruct);
            return new SpotifyTrack(trck);
        }

        /// <summary>
        /// Starts buffering the Track inside the MusicStream object of the Session.
        /// </summary>
        /// <param name="Track">The SpotifyTrack to buffer.</param>
        public void playTrack(SpotifyTrack Track)
        {
            temp = libspotify.sp_session_player_load(spotsession, Track.internalTrack);
            temp = libspotify.sp_session_player_play(spotsession, true);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        private delegate int MusicDeliveryDelegate(IntPtr sessionPtr, IntPtr formatPtr, IntPtr framesPtr, int num_frames);
        private static MusicDeliveryDelegate mdd = new MusicDeliveryDelegate(MusicDelivery);
        //////////
        private static int MusicDelivery(IntPtr sessionPtr, IntPtr formatPtr, IntPtr framesPtr, int num_frame)
        {
            if (num_frame == 0) { return 0; }
            libspotify.sp_audioformat format = (libspotify.sp_audioformat)Marshal.PtrToStructure(formatPtr, typeof(libspotify.sp_audioformat));
            byte[] buffer = new byte[num_frame * sizeof(Int16) * format.channels];
            Marshal.Copy(framesPtr, buffer, 0, buffer.Length);
            MusicStream.Samplerate = format.sample_rate;
            MusicStream.Write(buffer, 0, buffer.Length);
            return num_frame;
        }
    }
}
