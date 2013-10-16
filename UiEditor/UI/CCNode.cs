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

        public List<String> getAllNodeNames()
        {
            return getAllNodeNamesHelper(this.children);
        }

        private List<String> getAllNodeNamesHelper(Dictionary<string, CCNode> children)
        {
            List<String> list = new List<String>();
            if (children != null)
            {
                foreach (KeyValuePair<string, CCNode> pair in children)
                {
                    if (!pair.Key.StartsWith("__"))
                    {
                        list.Add(pair.Key);
                        list.AddRange(getAllNodeNamesHelper(pair.Value.children));
                    }
                }
            }
            return list;
        }
    }
}
