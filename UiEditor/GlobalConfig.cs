using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UiEditor
{
    public class GlobalConfig
    {
        static public string root = @"D:\bwzq\ZhaoQin\";
        //资源目录
        static public String[] ResourceDir ={
                                                root + @"ZhaoQin\Resources",
                                                root + @"ZhaoQin\Resources\Zhaoqin\Res"
                                            };
        
        //导出头文件目录@
        static public String ExportHeaderPath = root + @"ZhaoQin\Classes\game\gameScene\layout";
        
        //布局文件保存目录
        static public String LayoutFileDir = root + @"ZhaoQin\Resources\Zhaoqin\Res\layout";
        
        //纹理的plist的目录
        static public String[] TexturePlistDirs = {
                                                    root + @"ZhaoQin\Resources\scene",
                                                    root + @"ZhaoQin\Resources\ui",
                                                    root + @"ZhaoQin\Resources\Zhaoqin\Res\scene",
                                                    root + @"ZhaoQin\Resources\Zhaoqin\Res\ui"
                                            };
    }
}
