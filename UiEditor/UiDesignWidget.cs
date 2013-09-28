using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UiEditor.UI;

namespace UiEditor
{
    public partial class UiDesignWidget : UserControl
    {
        public UiDesignWidget()
        {
            InitializeComponent();
            CCNode node = new CCNode();
            node.postion = new CCPoint();

            CCNodeRGBA node1 = new CCNodeRGBA();
            node1.opacity = 1;

            CCNode node3 = new CCNode();
            node3.postion = new CCPoint();

            node1.addChild("312", node3);

            node.addChild("123", node1);

            InitWithCCNode(node);
        }
        
        private void InitWithCCNode(CCNode node)
        {
            mNodesTree.Nodes.Clear();
            
            mNodesTree.Nodes.Add(CreateTreeNode("base", node));

            mNodesTree.ExpandAll();
        }

        private CCTreeNode CreateTreeNode(string name, CCNode node)
        {
            List<CCTreeNode> children = new List<CCTreeNode>();
            if (node.children != null)
            {
                foreach (KeyValuePair<string, CCNode> kvp in node.children)
                {
                    children.Add(CreateTreeNode(kvp.Key, kvp.Value));
                }
            }
            return new CCTreeNode(name, children.ToArray(), node);
        }

        private void OnAfterSelect(object sender, TreeViewEventArgs e)
        {
            CCTreeNode node = (CCTreeNode)e.Node;
            mPropertyWidget.InitWithCCNode(node.CCNode);
            
        }
    }

    class CCTreeNode : TreeNode
    {
        public CCTreeNode(string name, CCTreeNode[] children, CCNode node)
            : base(name, children)
        {
            this.CCNode = node;
        }
        public CCNode CCNode;
    }
}
