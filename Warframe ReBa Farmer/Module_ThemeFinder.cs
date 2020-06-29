using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace Warframe_ReBa_Farmer
{
    class Module_ThemeFinder
    {

        public static void GetColorFromScreen()
        {
            Bitmap ScreenPixelHolder = new Bitmap(1, 1, PixelFormat.Format24bppRgb);
            //Section
            Graphics.FromImage(ScreenPixelHolder).CopyFromScreen(new Point(664, 72), new Point(0, 0), new Size(1, 1));
            string StringHolder = string.Format("{{ Color.FromArgb({0}, {1}, {2}), ", ScreenPixelHolder.GetPixel(0, 0).R, ScreenPixelHolder.GetPixel(0, 0).G, ScreenPixelHolder.GetPixel(0, 0).B);
            //Text
            Graphics.FromImage(ScreenPixelHolder).CopyFromScreen(new Point(612, 72), new Point(0, 0), new Size(1, 1));
            StringHolder += string.Format("Color.FromArgb({0}, {1}, {2}) }}, //", ScreenPixelHolder.GetPixel(0, 0).R, ScreenPixelHolder.GetPixel(0, 0).G, ScreenPixelHolder.GetPixel(0, 0).B);
            Debug.Print(StringHolder);
            ScreenPixelHolder.Dispose();
            ScreenPixelHolder = null;
        }

        private static Dictionary<Color, Color> ThemeColours = new Dictionary<Color, Color>
        {
            { Color.FromArgb(232, 227, 227), Color.FromArgb(158, 159, 167) }, //Equinox
            { Color.FromArgb(255, 255, 0), Color.FromArgb(2, 127, 217) }, //High Contrast
            { Color.FromArgb(232, 213, 93), Color.FromArgb(255, 255, 255) }, // Legacy
            { Color.FromArgb(245, 227, 173), Color.FromArgb(190, 169, 102) }, //Vitruvian
            { Color.FromArgb(236, 211, 162), Color.FromArgb(238, 193, 105) }, //Baruuk
            { Color.FromArgb(111, 229, 253), Color.FromArgb(35, 201, 245) }, //Corpus
            { Color.FromArgb(200, 169, 237), Color.FromArgb(140, 119, 147) }, //Dark Lotus
            { Color.FromArgb(229, 212, 108), Color.FromArgb(255, 255, 255) }, //Deadlock
            { Color.FromArgb(255, 115, 230), Color.FromArgb(57, 105, 192) }, //Fortuna
            { Color.FromArgb(255, 224, 153), Color.FromArgb(255, 189, 102) }, //Grineer
            { Color.FromArgb(255, 241, 191), Color.FromArgb(36, 184, 242) }, //Lotus
            { Color.FromArgb(245, 73, 93), Color.FromArgb(140, 38, 92) }, //Nidus
            { Color.FromArgb(178, 125, 5), Color.FromArgb(20, 41, 29) }, //Orokin
            { Color.FromArgb(255, 61, 51), Color.FromArgb(153, 31, 35) }, //Stalker
            { Color.FromArgb(6, 109, 74), Color.FromArgb(9, 78, 106) } //Tenno
        };

        private static Color CurrentTheme;
        public static Color FindTheme(int R, int G, int B)
        {
            CurrentTheme = Color.FromArgb(R, G, B);
            return ThemeColours[CurrentTheme];

        }

    }
}
