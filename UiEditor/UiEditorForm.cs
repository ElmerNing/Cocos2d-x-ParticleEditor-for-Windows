using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UiEditor
{
    public partial class UiEditorForm : Form
    {
        private Cocos2dDllImporter mDll = new Cocos2dDllImporter();
        public UiEditorForm()
        {
            InitializeComponent();
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            mDll.Invoke<Cocos2dDllImporter.MInitializeApplication, bool>(mPreviewPanel.Handle.ToInt32());
        }

        private void OnTimeTick(object sender, EventArgs e)
        {
            mDll.Invoke<Cocos2dDllImporter.MGameLoop, bool>(16);
        }
    }
}
