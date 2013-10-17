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

            foreach (KeyValuePair<string, CCNode> pair in node.getAllNodesDistinct())
            {
                string name = pair.Key;
                string typename = pair.Value.GetType().Name;

                //string name
                string prefix = "LY_" + filename.ToUpper() + "_";
                string line = "#define " + string.Join("_", "LY", filename.ToUpper(), typename.ToUpper(), name.ToUpper()) + "    " +"\"" + name + "\"";
                sw.WriteLine(line);
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
