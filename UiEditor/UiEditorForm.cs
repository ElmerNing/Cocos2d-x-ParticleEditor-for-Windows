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
        public UiEditorForm()
        {
            InitializeComponent();
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            mDll.Invoke<Cocos2dDllImporter.MInitializeApplication, bool>(mPreviewPanel.Handle.ToInt32());
            //mDll.Invoke(Cocos2dDllImporter.MAddSpriteFramesWithFile, bool)();
            LoadSpriteFrames();
        }

        private void OnTimeTick(object sender, EventArgs e)
        {
            mDll.Invoke<Cocos2dDllImporter.MGameLoop, bool>(16);
        }

        private void LoadSpriteFrames()
        {
            DirectoryInfo dir = new DirectoryInfo(@"E:\Lab\Cocos2d-x-ParticleEditor-for-Windows\Debug.win32\scene");
            foreach (string path in getAllFiles(@"E:\Lab\Cocos2d-x-ParticleEditor-for-Windows\Debug.win32\scene"))
            {
                
                mDll.Invoke<Cocos2dDllImporter.MAddSpriteFramesWithFile, bool>(new StringBuilder(path));
                
            }
        }

        private List<string> getAllFiles(string path)
        {
            List<string> list = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (FileInfo info in dir.GetFiles())
            {
                if (info.Extension == ".plist")
                {
                    string fulname = info.FullName;

                    list.Add(fulname.Replace(@"\", @"/"));
                }
            }

            foreach (DirectoryInfo info in dir.GetDirectories())
            {
                list.AddRange(getAllFiles(info.FullName));
            }

            return list;
        }
    }
}
