using SixLabors.ImageSharp.PixelFormats;
using System.Runtime.InteropServices;
using SImage = SixLabors.ImageSharp.Image;
using SRgba = SixLabors.ImageSharp.PixelFormats.Rgba32;

namespace LUP.Images
{
    public static class ImageLoader
    {
        public static Image FromFile(string file)
        {
            using var stream = File.OpenRead(file);
            return FromStream(stream);
        }


        public static Image FromStream(Stream stream)
        {
            using var img = SImage.Load(stream);
            return Convert(img);
        }


        private static Image Convert(SImage image)
        {
            using var pixels = image.CloneAs<SRgba>();
            var type = image.PixelType;

            var pixelType = new ImagePixelInfo
            {
                HasAlpha = type.AlphaRepresentation != PixelAlphaRepresentation.None,
                Size = type.BitsPerPixel
            };

            List<Rgba32> result = new();

            pixels.ProcessPixelRows(x =>
            {
                for (int i = 0; i < x.Height; i++)
                {
                    var span = x.GetRowSpan(i);

                    for (int j = 0; j < span.Length; j++)
                    {
                        var color = span[j];

                        result.Add(new()
                        {
                            R = color.R,
                            G = color.G, 
                            B = color.B,
                            A = color.A
                        });
                    }
                }
            });

            var array = result.ToArray();
            return new Image(image.Width, image.Height, array, pixelType);
        }
    }
}
