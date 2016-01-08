using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace SocialNetwork.WEB.Infrastructure
{
    public class CaptchaImage : IDisposable
    {
        public const string CaptchaValueKey = "CaptchaImageText";

        private string _text;
        private int _width;
        private int _height;
        public Bitmap Image { get; set; }

        public CaptchaImage(string s, int width, int height)
        {
            _text = s;
            _width = width;
            _height = height;
            GenerateImage();
        }

        // создаем изображение
        private void GenerateImage()
        {
            Bitmap bitmap = new Bitmap(_width, _height, PixelFormat.Format32bppArgb);

            Graphics g = Graphics.FromImage(bitmap);
            // отрисовка строки
            g.DrawString(_text, new Font("Arial", _height/2, FontStyle.Bold),
                Brushes.Red, new RectangleF(0, 0, _width, _height));

            g.Dispose();

            Image = bitmap;
        }

        ~CaptchaImage()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                Image.Dispose();
        }
    }
}