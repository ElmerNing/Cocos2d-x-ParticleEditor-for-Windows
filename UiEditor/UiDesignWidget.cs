using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UiEditor.UI;
using System.Reflection;
using System.IO;

namespace UiEditor
{
    public partial class UiDesignWidget : UserControl
    {
        CCNode mBaseNode = null;

        public UiDesignWidget()
        {
            InitializeComponent();
            /*CCNode node = new CCNode();
            node.postion = new CCPoint();

            CCNodeRGBA node1 = new CCNodeRGBA();
            node1.opacity = 1;

            CCNode node3 = new CCNode();
            node3.postion = new CCPoint();

            node1.addChild("312", node3);

            node.addChild("123", node1);

            InitWithCCNode(node);*/
        }
        
        private void InitWithCCNode(CCNode node)
        {
            Reset();
            mBaseNode = node;
            mNodesTree.Nodes.Add(CreateTreeNode("base", node));
            mNodesTree.SelectedNode = mNodesTree.Nodes[0];
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

        private void OnNewBtnClick(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = " 布局文件(*.layout)|*.layout";
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                mSavePathLabel.Text = dlg.FileName;
            }
        }

        private void OnOpenBtnClick(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = " 布局文件(*.layout)|*.layout";
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                mSavePathLabel.Text = dlg.FileName;
                StreamReader sr = new StreamReader(dlg.FileName, Encoding.UTF8);
                CCNode node = CCObject.FromJson<CCNode>(sr.ReadToEnd());
                InitWithCCNode(node);
                sr.Close();
            }
        }

        private void OnSaveBtnClick(object sender, EventArgs e)
        {
            if (mSavePathLabel.Text == "")
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = " 布局文件(*.layout)|*.layout";
                DialogResult result = dlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    mSavePathLabel.Text = dlg.FileName;
                }
            }

            StreamWriter sw = new StreamWriter(mSavePathLabel.Text, false, Encoding.UTF8);
            sw.Write(mBaseNode.ToJson());
            sw.Close();
        }

        private void OnInsertClick(object sender, ToolStripItemClickedEventArgs e)
        {
            Assembly asb = Assembly.GetExecutingAssembly();
            Type insertype = asb.GetType("UiEditor.UI." + e.ClickedItem.Text, false, true);
            if (insertype == null)
                return;

            SaveFileDialog dlg = new SaveFileDialog();
            DialogResult re = dlg.ShowDialog();
            if (re == DialogResult.OK)
            {
                string name = Path.GetFileName(dlg.FileName);
                ConstructorInfo construct = insertype.GetConstructor(new Type[] { });
                CCNode node = (CCNode)construct.Invoke(null);
                if (mNodesTree.SelectedNode == null)
                {
                    InitWithCCNode(node);
                }
                else
                {
                    CCTreeNode tnode = CreateTreeNode(name, node);
                    ((CCTreeNode)mNodesTree.SelectedNode).CCNode.addChild(name, node);
                    mNodesTree.SelectedNode.Nodes.Add(tnode);
                    mNodesTree.SelectedNode = tnode;
                }
            }
        }

        private void OnDeleteClick(object sender, EventArgs e)
        {
            if (mNodesTree.SelectedNode == null)
                return;

            CCTreeNode parentnode = (CCTreeNode)mNodesTree.SelectedNode.Parent;
            if (parentnode == null)
            {
                Reset();
            }
            else
            {
                parentnode.CCNode.children.Remove(mNodesTree.SelectedNode.Text);
                InitWithCCNode(mBaseNode);
            }

        }

        private void OnFreshClick(object sender, EventArgs e)
        {
            if (mBaseNode != null)
            {
                string json = mBaseNode.ToJson();

                Cocos2dDllImporter.shared().Invoke<Cocos2dDllImporter.MUiChanged, bool>(new StringBuilder(json));
            }
            else
            {
                Cocos2dDllImporter.shared().Invoke<Cocos2dDllImporter.MUiChanged, bool>(new StringBuilder(""));
            }
        }

        public void Reset()
        {
            mNodesTree.Nodes.Clear();
            mPropertyWidget.Controls.Clear();
            mBaseNode = null;
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
