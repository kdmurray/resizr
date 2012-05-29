using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Resizr
{
    public class ImageManipulation
    {
        public static void ResizeImage(string OriginalFile, string NewFile, int MaxSize)
        {
            Image FullsizeImage = Image.FromFile(OriginalFile);

            // Prevent using images internal thumbnail
            FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
            FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

            double newHeight = FullsizeImage.Height;
            double newWidth = FullsizeImage.Width;

            if (FullsizeImage.Height > FullsizeImage.Width)
            {
                if (FullsizeImage.Height > MaxSize)
                {
                    newHeight = MaxSize;
                    newWidth = FullsizeImage.Width * ((double)MaxSize / FullsizeImage.Height);
                }
            }
            else
            {
                if (FullsizeImage.Width > MaxSize)
                {
                    newWidth = MaxSize;
                    newHeight = FullsizeImage.Height * ((double)MaxSize / FullsizeImage.Width);
                }
            }


            Image NewImage = FullsizeImage.GetThumbnailImage((int)newWidth, (int)newHeight, null, IntPtr.Zero);

            // Clear handle to original file so that we can overwrite it if necessary
            FullsizeImage.Dispose();

            // Save resized picture
            NewImage.Save(NewFile, ImageFormat.Jpeg);
        }




    }
}
