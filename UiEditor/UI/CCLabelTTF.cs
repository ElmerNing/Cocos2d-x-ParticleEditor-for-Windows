using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UiEditor.UI
{
    public class CCLabelTTF : CCSprite
    {
        public string text = null;
        public string languagetext = null;
        public string fontName = null;
        public int fontSize = 14;

        public CCSize dmensions = null;
        public int horizontalAlignment = 0;
        public int verticalTextAlignment = 0;
    }

    public class CCLabelTTFEx : CCSprite
    {
        public string text = null;
        public string languagetext = null;
        public string fontName = null;
        public int fontSize = 14;

        public CCSize dmensions = null;
        public int horizontalAlignment = 0;
        public int verticalTextAlignment = 0;

        public int strokeSize = 0;
        public CCColor3B strokeColor = null;
    }
}
