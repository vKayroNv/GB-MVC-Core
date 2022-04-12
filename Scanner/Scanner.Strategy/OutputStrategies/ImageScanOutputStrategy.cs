using Scanner.Strategy.Interfaces;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace Scanner.Strategy.OutputStrategies
{
    public sealed class ImageScanOutputStrategy : IScanOutputStrategy
    {
        public void ScanAndSave(IScannerDevice scannerDevice, string outputFileName)
        {
            using StreamReader sr = new(scannerDevice.Scan());

            var text = sr.ReadToEnd();
            var font = new Font("Arial", 14);
            var maxWidth = 1000;

            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);
            SizeF textSize = drawing.MeasureString(text, font, maxWidth);
            StringFormat sf = new()
            {
                Trimming = StringTrimming.Word
            };
            img.Dispose();
            drawing.Dispose();

            img = new Bitmap((int)textSize.Width, (int)textSize.Height);

            drawing = Graphics.FromImage(img);
            drawing.CompositingQuality = CompositingQuality.HighQuality;
            drawing.InterpolationMode = InterpolationMode.HighQualityBilinear;
            drawing.PixelOffsetMode = PixelOffsetMode.HighQuality;
            drawing.SmoothingMode = SmoothingMode.HighQuality;
            drawing.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            drawing.Clear(Color.White);

            Brush textBrush = new SolidBrush(Color.Black);

            drawing.DrawString(text, font, textBrush, new RectangleF(0, 0, textSize.Width, textSize.Height), sf);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();
            img.Save(outputFileName, ImageFormat.Png);
            img.Dispose();
        }
    }
}