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

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Parker Was Here");
            Console.ReadLine();
            Console.WriteLine("PDF Sharp is the bestest");


            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();


        }
    }
}
