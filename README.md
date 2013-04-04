#libSpotifyAPI

libSpotifyAPI is the real Spotify-API for C#, using the functions of C# and making creating your Spotify-integrated application.

##Setting up libSpotifyAPI

###Requirements

A cup of tea, some kind of C# compiler/IDE, an Spotify Application Key and the native libspotify C-library.

###Installation, Compiling and Using.

1. Open directory, run ``git submodule init`` and ``git submodule update``
2. Go into the ``lib`` folder and compile libspotify.net
3. Open main project file.
4. Replace the reference to ``libspotifydotnet`` with one you just compiled.
5. Compile library.
6. Sip some tea while waiting.
7. Add the DLL to your program's project/compiler arguments.
8. Use the ``SpotifyAPI`` namespace.
9. Create a ``SpotifySession`` object and set its settings (including API key).
10. Read the damn documentation, it's in IntelliSense.
11. Add some [Spotify branding](http://developer.spotify.com/technologies/libspotify/#branding) to avoid breaking the [libspotify terms of use](http://developer.spotify.com/technologies/libspotify/#terms-of-use) which you still have to follow.

- - -

This product uses SPOTIFY(R) CORE but is not endorsed, certified or otherwise approved in any way by Spotify. Spotify is the registered trade mark of the Spotify Group.