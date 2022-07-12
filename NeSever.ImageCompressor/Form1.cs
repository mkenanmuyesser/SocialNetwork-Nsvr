using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NeSeverImageCompressor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string getRoot = @"G:\Data\";
        string setRoot = @"G:\SmallData\";
        private void button1_Click(object sender, EventArgs e)
        {
            string websitePath = "SaatVeSaat";
            Convert(websitePath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string websitePath = "Morhipo";
            Convert(websitePath);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string websitePath = "Ciceksepeti";
            Convert(websitePath);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string websitePath = "KitapSec";
            Convert(websitePath);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string websitePath = "Vatan";
            Convert(websitePath);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string websitePath = "DoRe";
            Convert(websitePath);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string websitePath = "Amazon";
            Convert(websitePath);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string websitePath = "Ebebek";
            Convert(websitePath);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string websitePath = "Zara";
            Convert(websitePath);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string websitePath = "Lufian";
            Convert(websitePath);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string websitePath = "Pasabahce";
            Convert(websitePath);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string websitePath = "Pandora";
            Convert(websitePath);
        }

        private void Convert(string websitePath)
        {
            string getFilepath = getRoot + websitePath;
            List<string> directories = Directory.GetDirectories(getFilepath).ToList();
            foreach (var directory in directories)
            {
                List<string> files = Directory.GetFiles(directory).ToList();
                foreach (var file in files)
                {
                    string setFilePath = setRoot + websitePath + file.Replace(getFilepath, "");

                    if (!File.Exists(setFilePath))
                    {
                        try
                        {
                            FileInfo fi = new FileInfo(file);
                            Image image = Image.FromFile(file);

                            Save(image, 500, 500, 80, setFilePath, fi.Name);

                            image.Dispose();
                            GC.SuppressFinalize(image);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
        }

        public void Save(Image image, int maxWidth, int maxHeight, int quality, string filePath, string fileName)
        {
            // Get the image's original width and height
            int originalWidth = image.Width;
            int originalHeight = image.Height;

            // To preserve the aspect ratio
            float ratioX = (float)maxWidth / (float)originalWidth;
            float ratioY = (float)maxHeight / (float)originalHeight;
            float ratio = Math.Min(ratioX, ratioY);

            // New width and height based on aspect ratio
            int newWidth = (int)(originalWidth * ratio);
            int newHeight = (int)(originalHeight * ratio);

            // Convert other formats (including CMYK) to RGB.
            Bitmap newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

            // Draws the image in the specified size with quality mode set to HighQuality
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            // Get an ImageCodecInfo object that represents the JPEG codec.
            ImageCodecInfo imageCodecInfo = this.GetEncoderInfo(ImageFormat.Jpeg);

            // Create an Encoder object for the Quality parameter.
            System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;

            // Create an EncoderParameters object. 
            EncoderParameters encoderParameters = new EncoderParameters(1);

            // Save the image as a JPEG file with quality level.
            EncoderParameter encoderParameter = new EncoderParameter(encoder, quality);
            encoderParameters.Param[0] = encoderParameter;

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath.Replace(fileName, ""));

            newImage.Save(filePath, imageCodecInfo, encoderParameters);

            newImage.Dispose();
            GC.SuppressFinalize(newImage);
        }

        private ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().SingleOrDefault(c => c.FormatID == format.Guid);
        }       
    }
}
