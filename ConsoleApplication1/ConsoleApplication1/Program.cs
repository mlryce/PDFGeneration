using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new PDF document
            PdfDocument doc = new PdfDocument();
            doc.Info.Title = "Created with PDFsharp";

            // Create an empty page
            PdfPage page = doc.AddPage();

            // Get an XGraphics obj for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);

            // Draw the text
            gfx.DrawString("Hello, World!", font, XBrushes.Black,
                new XRect(0, 0, page.Width, page.Height),
                XStringFormats.Center);

            // save the document ...
            const string filename = "HelloWorld.pfd";
            doc.Save(filename);
            // ... and start a viewer.
            Process.Start(filename);





        }
    }
}
