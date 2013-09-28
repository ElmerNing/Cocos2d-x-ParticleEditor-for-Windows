using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace UiEditor.UI
{
    public class CCObject
    {
        public string ToJson()
        {
            JsonSerializerSettings setting = new JsonSerializerSettings();
            string json = JsonConvert.SerializeObject(this, Formatting.Indented, setting);
            return json;
        }
    }
}
