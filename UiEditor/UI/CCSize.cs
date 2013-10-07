using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UiEditor.UI
{
    public class CCSize : CCProperty
    {
        public float width;
        public float height;

        public override string ToString()
        {
            return string.Join(",", width, height);
        }

        static public CCSize Parse(string str)
        {
            try
            {
                string[] rgb = str.Split(',', ':', '-', '.');
                CCSize clr = new CCSize();
                clr.width = float.Parse(rgb[0]);
                clr.height = float.Parse(rgb[1]);
                return clr;
            }
            catch
            {
                return null;
            }
        }
    }
}
