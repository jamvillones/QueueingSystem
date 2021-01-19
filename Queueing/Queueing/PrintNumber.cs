using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queueing
{
    public static class PrintNumber
    {
        public static void Print(PrintPageEventArgs e, string Number, string Category)
        {
            var centerFormat = new StringFormat();
            centerFormat.Alignment = StringAlignment.Center;

            string title = "habitasse platea dictumst vestibulum rhoncus est";
            var titleSize = e.Graphics.MeasureString(title, categoryFont, e.PageBounds.Width);
            var titleRect = new Rectangle(0, 0, e.PageBounds.Width, (int)titleSize.Height);
            e.Graphics.DrawString(title.ToUpper(), categoryFont, Brushes.Black, titleRect, centerFormat);

            var numberSize = e.Graphics.MeasureString(Number, numberFont, e.PageBounds.Width);
            var numberRect = new Rectangle(0, titleRect.Bottom + 10, e.PageBounds.Width, (int)numberSize.Height);
            e.Graphics.DrawString(Number, numberFont, Brushes.Black, numberRect, centerFormat);

            var categorySize = e.Graphics.MeasureString(Category, categoryFont, e.PageBounds.Width);
            var catRect = new Rectangle(0, numberRect.Bottom, e.PageBounds.Width, (int)categorySize.Width);
            e.Graphics.DrawString(Category + "\n\n" + DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt"), categoryFont, Brushes.Black, catRect, centerFormat);
        }
        static Font numberFont = new Font("Times New Roman", 20, FontStyle.Bold);
        static Font categoryFont = new Font("Times New Roman", 8, FontStyle.Regular);
    }
}
