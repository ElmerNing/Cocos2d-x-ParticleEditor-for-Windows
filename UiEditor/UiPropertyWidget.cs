﻿using System;
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
        public CCNode BindCCNode = null;
        public UiPropertyWidget()
        {
            InitializeComponent();
        }
        public void InitWithCCNode(CCNode node)
        {
            BindCCNode = node;
            Type type = node.GetType();
            FieldInfo[] fields = type.GetFields();
            this.Controls.Clear();
            Label label = new Label();
            label.Text = type.ToString();
            label.Location = new Point(4, 25);
            label.AutoSize = true;
            this.Controls.Add(label);
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i].Name.ToLower() == "children")
                {
                    continue;
                }
                UiPropertyGrid grid = UiPropertyGrid.create(node, fields[i]);
                grid.Location = new Point(4, 30 * i + 50);
                this.Controls.Add(grid);
            }
        }        
    }
}
