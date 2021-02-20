using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace LibraryGenius
{
    public class BytesImageUtil
    {
        /// <summary>
        /// 将字节数组转换成图像对象
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>图像对象</returns>
        public static Image BytesToImage(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }

            Image image = null;
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                image = Image.FromStream(stream);
            }
            return image;
        }

        /// <summary>
        /// 将图像对象转换为字节数组
        /// </summary>
        /// <param name="image">Image对象</param>
        /// <returns>字节数组</returns>
        public static byte[] ImageToBytes(Image image)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            byte[] bytes = null;
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Jpeg);
                bytes = stream.ToArray();
            }
            return bytes;
        }
    }
}
