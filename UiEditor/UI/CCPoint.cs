using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace UiEditor.UI
{
    public class CCPoint : CCProperty
    {
        public float x;
        public float y;

        public override string ToString()
        {
            return string.Join(",", x, y);
        }

        static public CCPoint Parse(string str)
        {
            try
            {
                string[] rgb = str.Split(',', ':', '-', '.');
                CCPoint clr = new CCPoint();
                clr.x = float.Parse(rgb[0]);
                clr.y = float.Parse(rgb[1]);
                return clr;
            }
            catch
            {
                return null;
            }
        }
    }
}
