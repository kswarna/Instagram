using System;

namespace Instagram
{
    public class InstaConnInstance
    {
        public string ClientID { get;set; }
        public string ClientSecret { get;set; }
        public Uri Redirect { get;set; }

        public InstaConnInstance (string clientID,string redirecUrl)
        {
            ClientID = clientID;
            Redirect = new Uri(redirecUrl);
        }

    }
}
