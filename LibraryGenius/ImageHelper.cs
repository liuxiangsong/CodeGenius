using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace LibraryGenius
{
    public static class ImageUtility
    {
        public static Image Scale(this Image @this, double ratio)
        {
            if (@this == null) return null;
            int width = Convert.ToInt32(@this.Width * ratio);
            int height = Convert.ToInt32(@this.Height * ratio);
            return @this.Scale(width, height);
        }

        public static Image Scale(this Image @this, int width, int height)
        {
            if (@this == null) return null;

            var r = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(r))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawImage(@this, 0, 0, width, height);
            }

            return r;
        }
    }
}
