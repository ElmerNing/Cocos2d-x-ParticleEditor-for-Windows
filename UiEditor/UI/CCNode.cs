using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UiEditor.UI
{
    public class CCNode : CCObject
    {
        public CCPoint postion = null;
        public CCPoint anchorPoint = null;
        public CCPoint scale = null;
        public CCPoint rotation = null;
        public bool visible = true;
        public int zOrder = 0;
        public Dictionary<string, CCNode> children = null;
    }
}
