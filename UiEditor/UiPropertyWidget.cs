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

namespace UiEditor
{
    public partial class UiPropertyWidget : UserControl
    {
        public UiPropertyWidget()
        {
            InitializeComponent();
        }

        public void InitWithCCNode(CCNode node)
        {
            Type type = node.GetType();
            FieldInfo[] fields = type.GetFields();
            this.Controls.Clear();

            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i].Name.ToLower() == "children")
                {
                    continue;
                }
                UiPropertyGrid grid = UiPropertyGrid.create(node, fields[i]);
                grid.Location = new Point(4, 50 * i + 50);
                this.Controls.Add(grid);
            }
        }

        
    }
}
