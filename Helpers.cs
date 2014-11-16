using Instagram.DataProvider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Instagram
{
    public enum ImgType
    {
        LowRes,
        StdRes,
        ThumbNail
    }
    [DataContract]
    public class TagSerchaResposne
    {
        [DataMember]
        public object pagination;
        [DataMember]
        public List<postResponse> data;
        [DataMember]
        public object meta;

        public static TagSerchaResposne GetInstagramResponse(MemoryStream response)
        {
            response.Position = 0;
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(TagSerchaResposne));
            return (TagSerchaResposne)ser.ReadObject(response);
        }
    }

    [DataContract]
    public class postResponse
    {
        [DataMember]
        public object attribution;
        [DataMember]
        public object tags;
        [DataMember]
        public object location;
        [DataMember]
        public object comments;
        [DataMember]
        public object filter;
        [DataMember]
        public object created_time;
        [DataMember]
        public object link;
        [DataMember]
        public object likes;
        [DataMember]
        public InstagramImageSet images;
        [DataMember]
        public object users_in_photo;
        [DataMember]
        public object caption;
        [DataMember]
        public object type;
        [DataMember]
        public object id;
        [DataMember]
        public object user;

    }

    [DataContract]
    public class InstagramImageSet
    {
        [DataMember]
        public InstagramImage low_resolution { get; set; }
        [DataMember]
        public InstagramImage standard_resolution { get; set; }
        [DataMember]
        public InstagramImage thumbnail { get; set; }
    }
    [DataContract]
    public class InstagramImage
    {
        [DataMember]
        public object url { get;set; }
        [DataMember]
        public object width { get;set; }
        [DataMember]
        public object height { get;set; }
    }
}
