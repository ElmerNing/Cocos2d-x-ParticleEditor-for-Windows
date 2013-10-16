using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace UiEditor
{
    public class DirUtil
    {
        static public List<string> getAllFiles(string path, string ext)
        {
            List<string> list = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (FileInfo info in dir.GetFiles())
            {
                if (info.Extension == ext)
                {
                    string fulname = info.FullName;

                    list.Add(fulname.Replace(@"\", @"/"));
                }
            }

            foreach (DirectoryInfo info in dir.GetDirectories())
            {
                list.AddRange(getAllFiles(info.FullName, ext));
            }

            return list;
        }
    }
}
