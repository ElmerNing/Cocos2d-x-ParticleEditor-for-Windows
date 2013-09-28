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
        public delegate bool MAddSpriteFramesWithFile(StringBuilder path);
        public delegate bool MRemoveSpriteFrames();
        
        public Cocos2dDllImporter()
        {
            //var myAssemblyName = new AssemblyName { Name = "DllImporter" };
            //var myAssemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.Run);
            //mModuleBuilder = myAssemblyBuilder.DefineDynamicModule("DllImporter");
            Open("libcocos2d.dll");
        }
    }
}
