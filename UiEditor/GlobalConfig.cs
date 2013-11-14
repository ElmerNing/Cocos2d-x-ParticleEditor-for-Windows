﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UiEditor
{
    public class GlobalConfig
    {
        //资源目录
        static public String[] ResourceDir ={
                                                @"D:\bwzq\ZhaoQin_2.2\ZhaoQin\Resources",
                                                @"D:\bwzq\ZhaoQin_2.2\ZhaoQin\Resources\Zhaoqin\Res"
                                            };
        
        //导出头文件目录@
        static public String ExportHeaderPath = @"D:\bwzq\ZhaoQin_2.2\ZhaoQin\Classes\game\gameScene\layout";
        
        //布局文件保存目录
        static public String LayoutFileDir = @"D:\bwzq\ZhaoQin_2.2\ZhaoQin\Resources\Zhaoqin\Res\layout";
        
        //纹理的plist的目录
        static public String[] TexturePlistDirs = {
                                                    @"D:\bwzq\ZhaoQin_2.2\ZhaoQin\Resources\scene",
                                                    @"D:\bwzq\ZhaoQin_2.2\ZhaoQin\Resources\ui",
                                                    @"D:\bwzq\ZhaoQin_2.2\ZhaoQin\Resources\Zhaoqin\Res\scene",
                                                    @"D:\bwzq\ZhaoQin_2.2\ZhaoQin\Resources\Zhaoqin\Res\ui"
                                            };
    }
}
