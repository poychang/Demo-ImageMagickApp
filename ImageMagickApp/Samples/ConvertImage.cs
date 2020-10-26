﻿// Copyright 2013-2020 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using System.IO;
using ImageMagick;

namespace ImageMagickApp.Samples
{
    public static class ConvertImageSamples
    {
        public static void ConvertImageFromOneFormatToAnother()
        {
            // Read first frame of gif image
            using (var image = new MagickImage(SampleFiles.SnakewareGif))
            {
                // Save frame as jpg
                image.Write(SampleFiles.OutputDirectory + "Snakeware.jpg");
            }

            var settings = new MagickReadSettings();
            // Tells the xc: reader the image to create should be 800x600
            settings.Width = 800;
            settings.Height = 600;

            using (var memStream = new MemoryStream())
            {
                // Create image that is completely purple and 800x600
                using (var image = new MagickImage("xc:purple", settings))
                {
                    // Sets the output format to png
                    image.Format = MagickFormat.Png;

                    // Write the image to the memorystream
                    image.Write(memStream);
                }
            }

            // Read image from file
            using (var image = new MagickImage(SampleFiles.SnakewarePng))
            {
                // Sets the output format to jpeg
                image.Format = MagickFormat.Jpeg;

                // Create byte array that contains a jpeg file
                byte[] data = image.ToByteArray();
            }
        }

        public static void ConvertCmykToRgb()
        {
            // Uses sRGB.icm, eps/pdf produce better result when you set this before loading.
            var settings = new MagickReadSettings();
            settings.ColorSpace = ColorSpace.sRGB;

            // Create empty image
            using (var image = new MagickImage())
            {
                // Reads the eps image, the specified settings tell Ghostscript to create an sRGB image
                image.Read(SampleFiles.SnakewareEps, settings);

                // Save image as tiff
                image.Write(SampleFiles.OutputDirectory + "Snakeware.tiff");
            }

            // Read image from file
            using (var image = new MagickImage(SampleFiles.SnakewareJpg))
            {
                // Will use the CMYK profile if the image does not contain a color profile.
                // The second profile will transform the colorspace from CMYK to RGB
                image.TransformColorSpace(ColorProfile.USWebCoatedSWOP, ColorProfile.SRGB);

                // Save image as png
                image.Write(SampleFiles.OutputDirectory + "Snakeware.png");
            }

            // Read image from file
            using (var image = new MagickImage(SampleFiles.SnakewareJpg))
            {
                // Will use the CMYK profile if your image does not contain a color profile.
                // The second profile will transform the colorspace from your custom icc profile
                image.TransformColorSpace(ColorProfile.USWebCoatedSWOP, new ColorProfile(SampleFiles.YourProfileIcc));

                // Save image as tiff
                image.Write(SampleFiles.OutputDirectory + "Snakeware.tiff");
            }
        }
    }
}
