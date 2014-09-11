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
using ConsoleApplication1.classes;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            organization school = new organization();
           
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

            //Drawing the text  
            
            XgraphicTest.DrawString("MedPass Immunization Form", font, XBrushes.Black, new XRect(370,5,150,60), XStringFormats.Center);
            XgraphicTest.DrawString("Print clearly using blue or black ink", font2, XBrushes.Black, new XRect(383, 25, 150, 60), XStringFormats.Center);
           

            // Draw Rectangle 
            XPen pen = new XPen(XColors.Blue, Math.PI);
   

        
        

        
            //Save The Doc 
            const string filename = "MeddPassTestDoc6.pdf";
            document.Save(filename);
            Process.Start(filename); 

            
            
        }
    } 

}
