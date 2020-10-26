using ImageMagick;
using System;

namespace ImageMagickApp.Samples
{
    public static class ImageCompare
    {
        public static void CompareImages()
        {
            var beforeImage = new MagickImage(SampleFiles.ImageCompareBefore)
            {
                ColorFuzz = new Percentage(15)
            };
            var afterImage = new MagickImage(SampleFiles.ImageCompareAfter);
            var deltaImagePath = $"{SampleFiles.OutputDirectory}\\{DateTime.Now.Ticks}.png";
            var threashHold = 0.01;

            using var delta = new MagickImage();

            var result = beforeImage.Compare(afterImage, ErrorMetric.Fuzz, delta);
            if (result > threashHold)
            {
                delta.Write(deltaImagePath);
                Console.WriteLine($"Threshhold: {threashHold} compare result: {result} Does not match.");
            }
            else
            {
                Console.WriteLine($"Threshhold: {threashHold} compare result: {result} Matched.");
            }
        }
    }
}
