using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UiEditor.UI;



namespace UiEditor
{
    public class ExportHelper
    {
        private static String GetExportPath(string srcPath)
        {
            string srcname = Path.GetFileName(srcPath);
            string dstname = srcname.Replace(".layout", ".h");
            return GlobalConfig.ExportHeaderPath + @"\" + dstname;
        }

        private static String Convert(string srcPath)
        {
            FileStream fs = File.Open(srcPath, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fs);
            CCNode node = CCNode.FromJson<CCNode>(reader.ReadToEnd());
            reader.Close();
            fs.Close();
            if (node == null)
                return "";
         
            StringWriter sw = new StringWriter();
            string filename = Path.GetFileNameWithoutExtension(srcPath);
            string hppGuard = "LY_" + filename.ToUpper() + "_H__";
            sw.WriteLine("#ifndef " + hppGuard);
            sw.WriteLine("#define " + hppGuard);
            sw.WriteLine();

            Dictionary<string, CCNode> nodes = node.getAllNodesDistinct();
            foreach (KeyValuePair<string, CCNode> pair in nodes)
            {
                string name = pair.Key;
                string typename = pair.Value.GetType().Name;

                //string name
                string define = "#define ";
                string macro1 = string.Join("_", "LY", filename.ToUpper(), typename.ToUpper(), name.ToUpper());
                string value1 = "\"" + name + "\"";
                string line = define + macro1 + "\t" + value1;
                sw.WriteLine(line);

                string macro2 = string.Join("_", "LY_GET", filename.ToUpper(), name.ToUpper()) + "(layoutnode)";
                string value2 = "dynamic_cast<" + typename + "*>(" + "layoutnode->getChildByName(" + value1 + "))";
                sw.WriteLine(define + macro2 + "\t" + value2);
            }
            sw.WriteLine();
            sw.WriteLine("#endif");
            return sw.ToString();
        }

        public static bool ExportLayout(string srcPath)
        {
            string dstPath = GetExportPath(srcPath);

            //是否需更新
            if (File.Exists(dstPath))
            {
                FileInfo dstinfo = new FileInfo(dstPath);
                FileInfo srcinfo = new FileInfo(srcPath);
                if (dstinfo.LastWriteTime > srcinfo.LastWriteTime)
                {
                    return false;
                }
            }

            string dstContent = Convert(srcPath);

            UTF8Encoding utf8 = new UTF8Encoding(false);
            StreamWriter sw = new StreamWriter(dstPath, false, utf8);
            sw.Write(dstContent);
            sw.Close();

            return true;
        }
    }
}
