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

        static CCNode mCopyNode = null;

        public UiDesignWidget()
        {
            InitializeComponent();
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
            dlg.InitialDirectory = GlobalConfig.LayoutFileDir;
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
            dlg.InitialDirectory = GlobalConfig.LayoutFileDir;
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
                dlg.FileName = mSavePathLabel.Text;
                dlg.Filter = " 布局文件(*.layout)|*.layout";
                DialogResult result = dlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    mSavePathLabel.Text = dlg.FileName;
                }
            }
            if (mBaseNode != null)
            {
                UTF8Encoding utf8 = new UTF8Encoding(false);
                StreamWriter sw = new StreamWriter(mSavePathLabel.Text, false, utf8);
                sw.Write(mBaseNode.ToJson());
                sw.Close();
            }
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

        private void OnChangeItemClick(object sender, ToolStripItemClickedEventArgs e)
        {
            Assembly asb = Assembly.GetExecutingAssembly();
            Type insertype = asb.GetType("UiEditor.UI." + e.ClickedItem.Text, false, true);
            if (insertype == null)
                return;
            if (mNodesTree.SelectedNode == null)
                return;

            CCTreeNode tSelNode = (CCTreeNode)mNodesTree.SelectedNode;
            CCTreeNode tParentNode = (CCTreeNode)tSelNode.Parent;
            if (tParentNode == null)
                return;

            string name = tSelNode.Text;
            ConstructorInfo construct = insertype.GetConstructor(new Type[] { });
            CCNode node = (CCNode)construct.Invoke(null);
            node.children = tSelNode.CCNode.children;
            tParentNode.CCNode.children[name] = node;
            InitWithCCNode(mBaseNode);
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

        private void OnRenameClick(object sender, EventArgs e)
        {
            CCTreeNode tSelNode = (CCTreeNode)mNodesTree.SelectedNode;
            if (tSelNode == null)
                return;

            CCTreeNode tParentnode = (CCTreeNode)tSelNode.Parent;
            if (tParentnode == null)
                return;
         
            SaveFileDialog dlg = new SaveFileDialog();
            DialogResult re = dlg.ShowDialog();
            if (re == DialogResult.OK)
            {
                CCNode node = tParentnode.CCNode.children[tSelNode.Text];
                string name = Path.GetFileName(dlg.FileName);
                tParentnode.CCNode.children.Remove(tSelNode.Text);
                tParentnode.CCNode.children.Add(name, node);
                InitWithCCNode(mBaseNode);
            }
        }

        private void OnCopyClick(object sender, EventArgs e)
        {
            CCTreeNode tSelNode = (CCTreeNode)mNodesTree.SelectedNode;
            if (tSelNode == null)
                return;

            mCopyNode = tSelNode.CCNode;
        }

        private void OnPastClick(object sender, EventArgs e)
        {
            CCTreeNode tSelNode = (CCTreeNode)mNodesTree.SelectedNode;
            if (tSelNode == null)
                return;
            if (mCopyNode == null)
                return;

            string name = GetInput();
            if (name == null)
            {
                return;
            }

            tSelNode.CCNode.addChild(name, mCopyNode);

            mBaseNode = CCNode.FromJson<CCNode>(mBaseNode.ToJson());
            mBaseNode = CCNode.FromJson<CCNode>(mBaseNode.ToJson());
            InitWithCCNode(mBaseNode);
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

        private void onExportHppClick(object sender, EventArgs e)
        {
            List<String> layoutFiles = DirUtil.getAllFiles(GlobalConfig.LayoutFileDir, ".layout");
            if (!Directory.Exists(GlobalConfig.ExportHeaderPath))
                Directory.CreateDirectory(GlobalConfig.ExportHeaderPath);
            
            foreach(String file in layoutFiles)
            {
                ExportHelper.ExportLayout(file);
            }
            
        }

        private void Reset()
        {
            mNodesTree.Nodes.Clear();
            mPropertyWidget.Controls.Clear();
            mBaseNode = null;
        }

        private void onFunctionBtnClick(object sender, EventArgs e)
        {
            if (mPropertyWidget.BindCCNode == null)
                return;
            CCPoint pt = mPropertyWidget.BindCCNode.position;
            if (pt == null)
            {
                pt = new CCPoint();
                mPropertyWidget.BindCCNode.position = pt;
            }
            if (sender == upbtn)
            {
                pt.y += 1;
            }else if (sender == downbtn)
            {
                pt.y -= 1;
            }else if (sender == leftbtn)
            {
                pt.x -= 1;
            }else if (sender == rightbtn)
            {
                pt.x += 1;
            }
            OnFreshClick(null, null);
        }

        private string GetInput()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            DialogResult re = dlg.ShowDialog();
            if (re == DialogResult.OK)
            {
                string name = Path.GetFileName(dlg.FileName);
                return name;
            }
            return null;
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
