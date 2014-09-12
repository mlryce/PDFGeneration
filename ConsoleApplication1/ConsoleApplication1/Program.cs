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
            XFont studentFont = new XFont("Arial", 14, XFontStyle.Bold);
            XFont immunFont = new XFont("Arial", 12, XFontStyle.Bold);
            XFont topStatement = new XFont("Arial", 10, XFontStyle.Regular); 

            //Drawing the text  

            XgraphicTest.DrawString("MedPass Immunization Form", font, XBrushes.Black, new XRect(370, 5, 150, 60), XStringFormats.Center);
            XgraphicTest.DrawString("Print clearly using blue or black ink", font2, XBrushes.Black, new XRect(383, 25, 150, 60), XStringFormats.Center);
            XgraphicTest.DrawString("Complete and upload to medpasshealth.com by 12/01/1776", topStatement, XBrushes.Black, new XRect(377, 40, 150, 60), XStringFormats.Center);  
           

            // Draw Rectangle 
            XPen pen = new XPen(XColors.Blue, Math.PI);




            //Draw Med-Pass Logo
           

            Console.WriteLine("Please enter your name:");
            Console.Write(">  ");
            String name = Console.ReadLine();
            Console.WriteLine("Please enter your DOB:"); 
            string DOB = Console.ReadLine(); 
            Console.WriteLine("How many immunizations are Required?");
            Console.Write(">  ");
            string buffer = Console.ReadLine();
            int requiredImmunizations = Int32.Parse(buffer);
            int counter = 0;
            List<string> requiredImmunizationNames = new List<string>();

            if (requiredImmunizations != 0)
            { 
                while (counter < requiredImmunizations)
                {
                    Console.WriteLine("Please enter the name of an immunization:");
                    Console.Write(">  ");

                    requiredImmunizationNames.Add(Console.ReadLine());
                    counter++;
                }
            }

            XgraphicTest.DrawString("Date of Birth: " + DOB, studentFont, XBrushes.Black, new XRect(430, 54, 150, 60), XStringFormats.Center); 
            XgraphicTest.DrawString("Student Name: " + name, studentFont, XBrushes.Black, new XRect(60, 90, 0, 0), XStringFormats.Default);
            //Required Immunizations Rectangle 1 - Major Rectangle
            DrawRectangle(XgraphicTest, 15, 100, 560, requiredImmunizations * 20);
            //Required Immunizations Rectangle 2 - Dividing Rectangle
            DrawRectangle(XgraphicTest, 105, 100, 470, requiredImmunizations * 20);
            //DrawImage(XgraphicTest, );
            counter = 0;
            while (counter < requiredImmunizations)
            {
                int veriticalPosition = 20 * counter;
                XgraphicTest.DrawString(requiredImmunizationNames[counter], immunFont, XBrushes.Black, new XRect(40, 115 + veriticalPosition, 0, 0), XStringFormats.Default);

                counter++;
            }

            //Save The Doc 
            const string filename = "MeddPassTestDoc2.pdf";
            document.Save(filename);
            Process.Start(filename);

        }

        

        static void DrawRectangle(XGraphics gfx, int x, int y, int width, int height)
        {
            XPen pen = new XPen(XColors.Black, Math.PI);
            
            gfx.DrawRectangle(pen, x, y, width, height);
        }
    }
}
