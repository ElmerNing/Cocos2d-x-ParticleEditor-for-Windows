using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace UiEditor.UI
{
    [DefaultPropertyAttribute("SaveOnClose")]
    public class CCNode : CCObject
    {
        public CCPoint position = null;
        public CCPoint anchorPoint = null;
        public CCPoint scale = null;
        public CCSize containSize = null;
        public float rotation = 0;
        public bool visible = true;
        public int zOrder = 0;
        public Dictionary<string, CCNode> children = null;

        public void addChild(string name, CCNode node)
        {
            if (children == null)
            {
                children = new Dictionary<string, CCNode>();
            }
            children.Add(name, node);
        }
    }
}
