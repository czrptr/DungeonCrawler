using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Drawing.Text;

namespace DungeonCrawler.Graphix
{
    static class FontManager
    {
        public static PrivateFontCollection Fonts = new PrivateFontCollection();

        static FontManager()
        {
            string fontFolder = Directory.GetCurrentDirectory();
            fontFolder = Directory.GetParent(fontFolder).FullName;
            fontFolder = Directory.GetParent(fontFolder).FullName;
            fontFolder += @"\Resources\Fonts\";
            Fonts.AddFontFile(fontFolder + "VCR_OSD_MONO.ttf");
        }
    }
}
