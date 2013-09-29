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
            //mPropertyWidget.InitWithCCNode(node.CCNode);
            AppSettings a = new AppSettings();
            mPropertyGrid.SelectedObject = node.CCNode;


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

    [DefaultPropertyAttribute("SaveOnClose")]
    public class AppSettings
    {
        private bool saveOnClose = true;
        private string greetingText = "欢迎使用应用程序！";
        private int maxRepeatRate = 10;
        private int itemsInMRU = 4;
        private bool settingsChanged = false;
        private string appVersion = "1.0";
        [CategoryAttribute("文档设置"),
        DefaultValueAttribute(true)]
        public bool SaveOnClose
        {
            get { return saveOnClose; }
            set { saveOnClose = value; }
        }
        [CategoryAttribute("全局设置"),
        ReadOnlyAttribute(true),
        DefaultValueAttribute("欢迎使用应用程序！")]
        public string GreetingText
        {
            get { return greetingText; }
            set { greetingText = value; }
        }
        [CategoryAttribute("全局设置"),
        DefaultValueAttribute(4)]
        public int ItemsInMRUList
        {
            get { return itemsInMRU; }
            set { itemsInMRU = value; }
        }
        [DescriptionAttribute("以毫秒表示的文本重复率。"),
        CategoryAttribute("全局设置"),
        DefaultValueAttribute(10)]
        public int MaxRepeatRate
        {
            get { return maxRepeatRate; }
            set { maxRepeatRate = value; }
        }
        [BrowsableAttribute(false),
        DefaultValueAttribute(false)]
        public bool SettingsChanged
        {
            get { return settingsChanged; }
            set { settingsChanged = value; }
        }
        [CategoryAttribute("版本"),
        DefaultValueAttribute("1.0"),
        ReadOnlyAttribute(true)]
        public string AppVersion
        {
            get { return appVersion; }
            set { appVersion = value; }
        }
    }
}
