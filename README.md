#libSpotifyAPI

libSpotifyAPI is the real Spotify-API for C#, using the functions of C# and making the creation of your Spotify-integrated application easier.

##Setting up libSpotifyAPI

###Requirements

A cup of tea, some kind of C# compiler/IDE, a Spotify Application Key and the native `libspotify` C library available [here](http://developer.spotify.com/technologies/libspotify/).

###Installation, Compiling and Using.

1. Open directory, run ``git submodule init`` and ``git submodule update``
2. Go into the ``lib`` folder and compile libspotify.net
3. Copy the downloaded libspotify dll/so to the project's main folder and rename it to ``libspotify.dll``.
4. Open main project file.
5. Replace the reference to ``libspotifydotnet`` with one you just compiled. 
6. Compile library.
7. Sip some tea while waiting.
8. Add the DLL to your program's project/compiler arguments.
9. Use the `SpotifyAPI` namespace.
10. Create a `SpotifySession` object and set its settings (including API key).
11. Read the damn documentation, it's in IntelliSense.
12. Add some [Spotify branding](http://developer.spotify.com/technologies/libspotify/#branding) to avoid breaking the [libspotify terms of use](http://developer.spotify.com/technologies/libspotify/#terms-of-use) which you still have to follow.

- - -

This product uses SPOTIFY(R) CORE but is not endorsed, certified or otherwise approved in any way by Spotify. Spotify is the registered trade mark of the Spotify Group.