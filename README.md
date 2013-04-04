#libSpotifyAPI

libSpotifyAPI is a better wrapper for libspotify programmed in C#. It's aimed to be usable on Linux (through mono) and Windows provided you can get the C-library. Please note that isn't just a wrapper that requires you to handle unhandled memory and marshaling, even less requiring you to even read the official API documentation for libspotify!

##Setting up libSpotifyAPI

###Requirements

A cup of tea, some kind of C# compiler/IDE, an Spotify Application Key and the native libspotify C-library.

###Installation, Compiling and Using.

1. Open project file.
2. Compile library.
3. Sip some tea while waiting.
4. Add the DLL to your program's project/compiler arguments.
5. Use the ``SpotifyAPI`` namespace.
6. Create a ``SpotifySession`` object and set its settings (including API key).
7. Read the damn documentation, it's in IntelliSense.
8. Add some [Spotify branding](http://developer.spotify.com/technologies/libspotify/#branding) to avoid breaking the [libspotify terms of use](http://developer.spotify.com/technologies/libspotify/#terms-of-use) which you still have to follow.

- - -

This product uses SPOTIFY(R) CORE but is not endorsed, certified or otherwise approved in any way by Spotify. Spotify is the registered trade mark of the Spotify Group.