using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UiEditor
{
    public partial class UiEditorForm : Form
    {
        private Cocos2dDllImporter mDll = Cocos2dDllImporter.shared();
        private const int WM_MBUTTONDOWN = 0x0210;
        public UiEditorForm()
        {
            InitializeComponent();
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            mDll.Invoke<Cocos2dDllImporter.MInitializeApplication, bool>(mPreviewPanel.Handle.ToInt32());
            LoadSpriteFrames();
        }

        private void OnTimeTick(object sender, EventArgs e)
        {
            mDll.Invoke<Cocos2dDllImporter.MGameLoop, bool>(16);
        }

        private void LoadSpriteFrames()
        {        
            foreach (string dir in GlobalConfig.ResourceDir)
            {
                mDll.Invoke<Cocos2dDllImporter.MSetResourceDir, bool>(new StringBuilder(dir));
            }
            foreach (string dir in GlobalConfig.TexturePlistDirs)
            {
                List<String> paths = DirUtil.getAllFiles(dir, ".plist");
                foreach (string path in paths)
                {
                    mDll.Invoke<Cocos2dDllImporter.MAddSpriteFramesWithFile, bool>(new StringBuilder(path));
                }
            }
        }

        private void OnClick(object sender, EventArgs e)
        {
            MouseEventArgs args = (MouseEventArgs)e;
            if (args.Button == MouseButtons.Middle)
            {
                int x = args.X;
                int y = 960 - args.Y;
                mDesignWidget.UpdateNodePostion(x, y);
            }          
        }

       
    }
}
