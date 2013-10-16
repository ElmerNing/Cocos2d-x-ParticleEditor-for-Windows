using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UiEditor.UI
{
    class CCMenuItemSprite : CCNodeRGBA
    {
        public CCMenuItemSprite()
        {
            CCSprite normal = new CCSprite();
            normal.spriteFrameName = "uc_btn_4_n.png";
            this.addChild("__NormalImage__", normal);

            CCSprite select = new CCSprite();
            select.spriteFrameName = "uc_btn_4_t.png";
            this.addChild("__SelectedImage__", select);

            CCSprite disable = new CCSprite();
            disable.spriteFrameName = "uc_btn_1_disable.png";
            this.addChild("__DisabledImage__", disable);
        }
    }
}
