using Instagram.DataProvider;
using System.IO;
using System;
using System.Threading.Tasks;

namespace Instagram
{
    public class InstagramHashTag
    {
        const string url = "https://api.instagram.com/v1/tags/{0}/media/recent?callback=?&client_id={1}";
        const string defaultClientId = "7b7a6e77113140a7bf8564a0c5353d89";
        const string defaultUrl = "http://instagram.com";

        public async Task<TagSerchaResposne> GetData(string hashTag)
        {
            return await GetData(hashTag, defaultClientId);
        }

        public async Task<TagSerchaResposne> GetData(string hashTag,string clientID)
        {
            return await GetData(hashTag, clientID, defaultUrl);
        }

        public async Task<TagSerchaResposne> GetData(string hashTag, string clientID,string url)
        {
            InstaConnInstance setup = new InstaConnInstance(clientID, url);
            var res = await getDataStream(setup, hashTag);
            return res;
        }

        private async Task<TagSerchaResposne> getDataStream(InstaConnInstance setup, string HashTag)
        {
            var urlComplete = string.Format(url, HashTag, setup.ClientID);
            var content = await new HtmlDataProvider(urlComplete).GetData();
            var res = TagSerchaResposne.GetInstagramResponse(content);
            return res;
        }

        public async Task<MemoryStream> GetImg(string url)
        {
            try
            {
                var res = await new HtmlDataProvider(url).GetData();
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }

}

