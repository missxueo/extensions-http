using System;
using System.Text;
using Newtonsoft.Json;

namespace System.Net.Http
{
    public class JsonContent : ByteArrayContent
    {
        public JsonContent(object data) : this(data, Encoding.UTF8)
        {

        }

        public JsonContent(object data,Encoding encoding):this(data,new JsonSerializerSettings(),encoding)
        {

        }

        public JsonContent(object data,JsonSerializerSettings settings):this(data,settings,Encoding.UTF8)
        {

        }

        public JsonContent(object data,JsonSerializerSettings settings,Encoding encoding)
            :base(GetContentByteArray(data,settings,encoding))
        {
            this.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        }

        private static byte[] GetContentByteArray(object data ,JsonSerializerSettings settings ,Encoding encoding)
        {
            if (data is string str)
                return encoding.GetBytes(str);
            return encoding.GetBytes(JsonConvert.SerializeObject(data));
        }
    }
}
