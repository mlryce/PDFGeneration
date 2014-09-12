using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating New PDF Doc. 
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Created By MedPass Team";

            //Creating empty page 
            PdfPage page = document.AddPage();



            //Xgraphics object used for drawing 
            XGraphics XgraphicTest = XGraphics.FromPdfPage(page);



            //Creating a font 
            XFont font = new XFont("Arial", 20, XFontStyle.Bold);
            XFont font2 = new XFont("Arial", 15, XFontStyle.Bold);
            XFont font3 = new XFont("Arial", 10, XFontStyle.Bold);



            //Gathering info for text 

            Console.WriteLine("Please enter your name:");
            Console.Write(">  ");
            String name = Console.ReadLine();

            Console.WriteLine("Please enter your date of birth");
            String DOB = Console.ReadLine();

            Console.WriteLine("How many immunizations are Required?");
            Console.Write(">  ");
            string buffer = Console.ReadLine();
            int requiredImmunizations = Int32.Parse(buffer);
            int counter = 0;
            List<string> requiredImmunizationNames = new List<string>(); 

            //Drawing the text  

            XgraphicTest.DrawString("MedPass Immunization Form", font, XBrushes.Black, new XRect(370, 5, 150, 60), XStringFormats.Center);
            XgraphicTest.DrawString("Print clearly using blue or black ink", font2, XBrushes.Black, new XRect(383, 25, 150, 60), XStringFormats.Center);
            XgraphicTest.DrawString("Complete and upload to www.medpasshealth.com by 12/1/1965", font3, XBrushes.Black, new XRect(360, 45, 150, 60), XStringFormats.Center); 
            XgraphicTest.DrawString("DOB:" + DOB, font2, XBrushes.Black, new XRect(453, 65, 150, 60), XStringFormats.Center);   

           

            // Draw Rectangle 
            XPen pen = new XPen(XColors.Blue, Math.PI);




            //Draw Med-Pass Logo
            DrawImage(XgraphicTest, "C:\\Users\\pfloyd13\\Desktop\\GitHub\\PDFGeneration\\ConsoleApplication1\\ConsoleApplication1\\Images\\MedPassLogo.jpg", 75, 15, 129, 36);


            

            
            //Save The Doc 
            const string filename = "MeddPassTestDoc2.pdf";
            document.Save(filename);
            Process.Start(filename);

        }

        static void DrawImage(XGraphics gfx, string jpegSamplePath, int x, int y, int width, int height)
        {
            XImage image = XImage.FromFile(jpegSamplePath);
            gfx.DrawImage(image, x, y, width, height);
        }

        static void DrawRectangle(XGraphics gfx, int requiredImmunizations)
        {
            XPen pen = new XPen(XColors.Black, Math.PI);

            gfx.DrawRectangle(pen, 25, 100, 560, requiredImmunizations * 25);
        }
    }
}
