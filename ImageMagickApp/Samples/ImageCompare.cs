using ImageMagick;
using System;
using System.IO;

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
            var deltaImage = new MagickImage();
            var threshold = 0.01;
            var compareSetting = new CompareSettings
            {
                HighlightColor = MagickColors.Red,
                LowlightColor = MagickColors.White,
                Metric = ErrorMetric.Fuzz,
            };

            var result = beforeImage.Compare(afterImage, compareSetting, deltaImage);
            if (result > threshold)
            {
                var deltaImagePath = Path.Combine(SampleFiles.OutputDirectory, $"{DateTime.Now.Ticks}.png");
                deltaImage.Write(deltaImagePath);
                Console.WriteLine($"Threshold: {threshold} compare result: {result} Does not match.");
            }
            else
            {
                Console.WriteLine($"Threshold: {threshold} compare result: {result} Matched.");
            }
        }
    }
}
