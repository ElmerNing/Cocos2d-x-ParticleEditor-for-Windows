using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UiEditor.UI
{
    public class CCColor3B : CCProperty
    {
        public byte r;
        public byte g;
        public byte b;

        public override string ToString()
        {
            return string.Join(",", r, g, b);
        }

        static public CCColor3B Parse(string str)
        {
            try
            {
                string[] rgb = str.Split(',', ':', '-', '.');
                CCColor3B clr = new CCColor3B();
                clr.r = byte.Parse(rgb[0]);
                clr.g = byte.Parse(rgb[1]);
                clr.b = byte.Parse(rgb[2]);
                return clr;
            }catch
            {
                return null;
            }
        }

    }
}
