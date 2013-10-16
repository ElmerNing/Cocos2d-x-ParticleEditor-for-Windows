using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UiEditor.UI
{
    class CCMenu : CCNode
    {
        public CCMenu()
        {
            position = new CCPoint();
            position.x = 0;
            position.y = 0;

            this.addChild("btn_example", new CCMenuItemSprite());
        }
        public bool isTopButton = false;
    }
}
