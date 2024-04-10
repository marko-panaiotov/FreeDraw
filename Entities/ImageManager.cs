using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace FreeDraw.Entities
{
    public class ImageManager
    {
        public static void CreateSaveBitmap(Window window, Canvas canvas, string filename, BitmapEncoder encoder)
        {
            System.Windows.Size size = new System.Windows.Size(canvas.Width, canvas.Height);
            canvas.Measure(size);
            canvas.Arrange(new Rect(new System.Windows.Size((int)canvas.Width, (int)canvas.Height)));
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap((int)canvas.Width,
                                                                     (int)canvas.Height,
                                                                     96d, 96d,
                                                                     PixelFormats.Pbgra32);

            renderBitmap.Render(canvas);

            BitmapEncoder _encoder = encoder;
            _encoder.Frames.Add(BitmapFrame.Create(renderBitmap));

            using (FileStream file = File.Create(filename))
            {
                encoder.Save(file);
            }
        }
    }
}

