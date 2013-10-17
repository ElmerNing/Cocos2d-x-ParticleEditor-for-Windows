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

        public Dictionary<string, CCNode> getAllNodesDistinct()
        {
            return getAllNodeNamesHelper(this.children);
        }

        private Dictionary<string, CCNode> getAllNodeNamesHelper(Dictionary<string, CCNode> children)
        {
            Dictionary<string, CCNode> list = new Dictionary<string, CCNode>();
            if (children != null)
            {
                foreach (KeyValuePair<string, CCNode> pair in children)
                {
                    if (!pair.Key.StartsWith("__"))
                    {
                        list.Add(pair.Key, pair.Value);
                        list.Union(getAllNodeNamesHelper(pair.Value.children));
                    }
                }
            }
            return list;
        }
    }
}
