using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Reflection;
using UiEditor.UI;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters;

namespace UiEditor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>

        static void Test()
        {
            CCNode node = new CCNode();
            node.postion = new CCPoint();

            CCNodeRGBA node1 = new CCNodeRGBA();
            node1.opacity = 1;

            node.children = new Dictionary<string, CCNode>();
            node.children.Add("123", node1);

            List<Type> knowtypes = new List<Type>();
            foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (t.Namespace == "UiEditor.UI")
                {
                    knowtypes.Add(t);
                }

            }
            
            JsonSerializerSettings setting = new JsonSerializerSettings();
            //setting.ObjectCreationHandling = ObjectCreationHandling.;
            setting.TypeNameHandling = TypeNameHandling.Auto;
            setting.TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple;
            
            string json = JsonConvert.SerializeObject(node, Formatting.Indented, setting);
            //Console.Write(node.ToJson());
            Console.Write(json);

            //JsonConvert.DeserializeObject(json, typeof(CCNode));
            CCNode node2 = JsonConvert.DeserializeObject<CCNode>(json, setting);
            

            /*DataContractJsonSerializer json = new DataContractJsonSerializer(node.GetType(), knowtypes);
            MemoryStream stream = new MemoryStream();

            json.WriteObject(stream, node);
            string jsonsz = Encoding.UTF8.GetString(stream.ToArray());
            Console.Write(jsonsz);*/
        }

        [STAThread]
        static void Main()
        {

            Test();

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new UiEditorForm());
        }
    }
}
