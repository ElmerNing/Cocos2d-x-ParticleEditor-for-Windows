using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace UiEditor.UI
{
    [DefaultPropertyAttribute("SaveOnClose")]  
    public class CCPoint : CCObject
    {
        public float x;
        public float X
        {
            get { return x; }
            set { x = value; }
        }
        public float y;
        public float Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
