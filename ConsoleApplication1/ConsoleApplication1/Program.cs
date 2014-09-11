using System;
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
            PdfPage page2 = document.AddPage(); 
         

            //Xgraphics object used for drawing 
            XGraphics XgraphicTest = XGraphics.FromPdfPage(page);
            XGraphics Xtest = XGraphics.FromPdfPage(page2); 
         

            //Creating a font 
            XFont font = new XFont("Arial", 20, XFontStyle.Regular); 

            //Drawing the text  
            
            XgraphicTest.DrawString("MedPass Immunization Form", font, XBrushes.Black, new XRect(350,20,150,60), XStringFormats.Center);
            Xtest.DrawString("Please Work", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center); 
            Xtest.DrawString("2nd Line", font, XBrushes.Black, new XRect(250,362,150,60), XStringFormats.TopLeft);
           

            // Draw Rectangle 
            XPen pen = new XPen(XColors.Blue, Math.PI);
            Xtest.DrawRoundedRectangle(pen, 235, 362, 150, 60, 40, 40);

            XgraphicTest.DrawRoundedRectangle(pen, 450, 20, 150, 60, 40, 40); 
        

        
            //Save The Doc 
            const string filename = "MeddPassTestDoc.pdf";
            document.Save(filename);
            Process.Start(filename); 
            
        }
    } 

}
