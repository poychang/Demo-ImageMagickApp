using System;

namespace ImageMagickApp
{
    public static class SampleFiles
    {
        private static string _RootDirectory = AppDomain.CurrentDomain.BaseDirectory ?? System.Reflection.Assembly.GetExecutingAssembly().Location;
        private static string _FilesDirectory = _RootDirectory + @"Files\";

        public static string OutputDirectory { get; set; } = _RootDirectory + @"Output\";
        public static string CorruptImageJpg { get; set; } = _FilesDirectory + "CorruptImage.jpg";
        public static string FileWithWarningJpg { get; set; } = _FilesDirectory + "FileWithWarning.jpg";
        public static string FujiFilmFinePixS1ProJpg { get; set; } = _FilesDirectory + "FujiFilmFinePixS1Pro.jpg";
        public static string InvalidFileJpg { get; set; } = _FilesDirectory + "InvalidFile.jpg";
        public static string SnakewareEps { get; set; } = _FilesDirectory + "Snakeware.eps";
        public static string SnakewareGif { get; set; } = _FilesDirectory + "Snakeware.gif";
        public static string SnakewareJpg { get; set; } = _FilesDirectory + "Snakeware.jpg";
        public static string SnakewarePdf { get; set; } = _FilesDirectory + "Snakeware.pdf";
        public static string SnakewarePng { get; set; } = _FilesDirectory + "Snakeware.png";
        public static string StillLifeCR2 { get; set; } = _FilesDirectory + "StillLife.cr2";
        public static string YourProfileIcc { get; set; } = _FilesDirectory + "YourProfile.icc";
        public static string SampleBackground { get; set; } = _FilesDirectory + "2FD-Background.jpg";
        public static string ImageCompareBefore { get; set; } = _FilesDirectory + "charts-before.png";
        public static string ImageCompareAfter { get; set; } = _FilesDirectory + "charts-after.png";
    }
}
