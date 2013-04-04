using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libspotifydotnet;

namespace SpotifyAPI.SpotifyExceptions
{
    public class SessionCreateFailedException : System.Exception
    {
        public SessionCreateFailedException(string Message)
            : base(Message)
        {
            this.HelpLink = "http://developer.spotify.com/technologies/libspotify/docs/12.1.45/group__error.html#gafd27986ce4cd9eeaeca8adda83c9eb6b";
        }
    }
    public class LoginFailedException : System.Exception
    {
        public LoginFailedException(string Message)
            : base(Message)
        {
            this.HelpLink = "http://developer.spotify.com/technologies/libspotify/docs/12.1.45/group__error.html#gafd27986ce4cd9eeaeca8adda83c9eb6b";
        }
    }

}
