using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters;
namespace UiEditor.UI
{
    public class CCObject
    {
        static JsonSerializerSettings setting = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            TypeNameHandling = TypeNameHandling.Auto,
            TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
            Formatting = Formatting.Indented
        };

        public string ToJson()
        {
            string json = JsonConvert.SerializeObject(this, setting);
            return json;
        }

        static public T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, setting);
        }
    }
}
