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
    public partial class UiPropertyGrid : UserControl
    {
        private CCNode mBindNode;
        private FieldInfo mBindField;
        private bool mInitDone = false;

        private UiPropertyGrid()
        {
            InitializeComponent();
        }

        public static UiPropertyGrid create(CCNode node, FieldInfo field)
        {
            UiPropertyGrid grid = new UiPropertyGrid();
            if (grid.init(node, field))
            {
                return grid;
            }
            return null;
        }

        bool init(CCNode node, FieldInfo field)
        {
            MethodInfo method = field.FieldType.GetMethod("Parse", new[]{typeof(string)} );
            if ((node == null || field == null || method == null) &&
                field.FieldType.Name.ToLower() != "string")
            {
                return false;
            }
            mInitDone = true;
            mBindField = field;
            mBindNode = node;
            mNameLabel.Text = field.Name;
            mEditor.Text = GetProperty();
            return true;
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            if (!mInitDone)
                return;
            SetProperty(mEditor.Text);
        }

        private string GetProperty()
        {
            object property = mBindField.GetValue(mBindNode);
            if (property != null)
                return property.ToString();
            else
                return "";
        }

        private void SetProperty(string property)
        {
            if (mBindField.FieldType.Name.ToLower() == "string")
            {
                if (property != "")
                {
                    mBindField.SetValue(mBindNode, property);
                }
                else
                {
                    mBindField.SetValue(mBindNode, null);
                }
                
            }
            else
            {
                MethodInfo method = mBindField.FieldType.GetMethod("Parse", new[] { typeof(string) });
                mBindField.SetValue(mBindNode, method.Invoke(null, new object[] { property }));
            }
        }
    }
}
