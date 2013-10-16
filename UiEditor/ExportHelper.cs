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
            if (node == null)
                return "";

            string prefix = "LY_" + Path.GetFileNameWithoutExtension(srcPath).ToUpper()+"_";

            StringWriter sw = new StringWriter();
            foreach (string name in node.getAllNodeNames())
            {
                string line = "#define " + prefix + name.ToUpper() + "    " + "\"" + name + "\"";
                sw.WriteLine(line);
            }
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

            FileStream fs = File.OpenWrite(dstPath);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(dstContent);


            return true;
        }
    }
}
