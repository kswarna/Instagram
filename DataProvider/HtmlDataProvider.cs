using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.DataProvider
{
    public class HtmlDataProvider : IDataProvider
    {
        public HtmlDataProvider(string url)
        {
            Url = url;
        }
        public string Url { get; set; }
        public async Task<MemoryStream> GetData()
        {
            var webReq = (HttpWebRequest)WebRequest.Create(Url);
            var content = new MemoryStream();
            using (WebResponse response = await webReq.GetResponseAsync())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    await responseStream.CopyToAsync(content);
                }
            }
            return content;
        }
    }
}
