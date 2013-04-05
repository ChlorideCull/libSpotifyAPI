using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpotifyAPI
{
    /// <summary>
    /// This class contains all the settings available to the API session. This class is not static, you have to instantiate it using new.
    /// </summary>
    public class SpotifySessionConfig
    {
        /// <param name="SpotifyAPIKey">The API Key provided by the Spotify Developers website.</param>
        public SpotifySessionConfig(byte[] SpotifyAPIKey)
        {
            APIKey = SpotifyAPIKey;
        }
        public SpotifySessionConfig() { }

        /// <summary>
        /// API Version is to be set to what version corresponds to your libspotify dll.
        /// </summary>
        public int APIVersion = 12;
        /// <summary>
        /// This option regulates where the Cache is saved. It is set by default to a subfolder named "spotifycache" in the current directory.
        /// </summary>
        public string CacheLocation = System.IO.Path.Combine(Environment.CurrentDirectory, "spotifycache");
        /// <summary>
        /// This option regulates where the Settings is saved. It is set by default to a subfolder named "spotifysettings" in the current directory.
        /// </summary>
        public string SettingsLocation = System.IO.Path.Combine(Environment.CurrentDirectory, "spotifysettings");
        /// <summary>
        /// This is required to be set with the byte array of the API key you get from the Spotify Developers website, it can be set through the constructor.
        /// </summary>
        public byte[] APIKey;
        /// <summary>
        /// The "User-agent" of your application, max 255 characters long. The User-agent should be a relevant, customer intended identification of your application.
        /// </summary>
        public string UserAgent = "SpotifyAPI for C# - libspotify wrapper";
        /// <summary>
        /// Unique ID for this device used by Spotify to identify devices to make sure no more than three different devices has downloaded playlists. Set to "Username/NetBIOS-name/OSVersion/ProcessorCount" by default.
        /// </summary>
        public string DeviceID = Environment.UserName + "/" + Environment.MachineName + "/" + Environment.OSVersion + "/" + Environment.ProcessorCount;
        /// <summary>
        /// Should the local copies of playlists be compressed, therefore saving space but sacrificing performance?
        /// </summary>
        public bool CompressPlaylists = true;
        /// <summary>
        /// Should metadata not be saved for local copies of the playlists, therefore reducing diskspace usage but requires the need for requesting metadata from the Spotify backend when loading a list?
        /// </summary>
        public bool DontSaveMetadataForPlaylists = false;
        /// <summary>
        /// Avoid loading playlists into RAM on startup, this should probably be set to true as the library handles loading into RAM.
        /// </summary>
        public bool InitiallyUnloadPlaylists = true;
        /// <summary>
        /// Select the Proxy to use, loaded from Internet Settings by default.
        /// </summary>
        public System.Net.IWebProxy Proxy = System.Net.WebRequest.GetSystemWebProxy();
        /// <summary>
        /// A certificate file containing all root ca certificates in PEM format. Exported from the OS by default.
        /// </summary>
        public string CACertsName; //TODO: Import from OS.
    }
}
