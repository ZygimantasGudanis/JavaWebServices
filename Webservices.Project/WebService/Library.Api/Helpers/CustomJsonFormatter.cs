using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library.Api.Helpers
{
    public class CustomJsonFormatter : BufferedMediaTypeFormatter
    {
        public CustomJsonFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/vnd.marvin.hateoas+json"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return true;
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            using (var writer = new StreamWriter(writeStream))
            {
                writer.Write(JsonConvert.SerializeObject(value));
            }
        }
    }
}
