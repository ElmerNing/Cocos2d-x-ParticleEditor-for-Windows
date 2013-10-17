using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UiEditor
{
    class Cocos2dDllImporter : DllImporter
    {
        public delegate bool MInitializeApplication(int hwnd);
        public delegate bool MGameLoop(float interval);
        public delegate bool MSetResourceDir(StringBuilder path);
        public delegate bool MAddSpriteFramesWithFile(StringBuilder path);
        public delegate bool MRemoveSpriteFrames();
        public delegate bool MUiChanged(StringBuilder json);
        
        public Cocos2dDllImporter()
        {
            Open("libcocos2d.dll");
        }

        static private Cocos2dDllImporter mDll = null;
        static public Cocos2dDllImporter shared()
        {
            if (mDll == null)
            {
                mDll = new Cocos2dDllImporter();
            }
            return mDll;
        }
    }
}
