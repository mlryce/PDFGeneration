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
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using ConsoleApplication1.classes;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new StudentContext())
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

                // Draw Logo
                DrawImage(XgraphicTest, "..\\..\\Images\\MedPassLogo.jpg", 105, 20, 180, 55);

                // Draw Data Matrix
                DrawImage(XgraphicTest, "..\\..\\Images\\Data-Matrix_Roemerind.jpg", 10, 10, 95, 95);

                //Get user input 
                //Console.WriteLine("Please enter your first name:");
                //Console.Write(">  ");
                //String fname = Console.ReadLine();
                //Console.WriteLine("Please enter your last name:");
                //Console.Write(">  ");
                //String lname = Console.ReadLine();
                //Console.WriteLine("Please enter your DOB:");
                //string buffer = Console.ReadLine();
                //DateTime DOB = DateTime.Now;
                //bool flag = false;

                //while (flag == false)
                //{
                //    if (DateTime.TryParse(buffer, out DOB))
                //    {
                //        flag = true;
                //        Console.WriteLine("DOB Successfully entered.");

                //    }
                //    else
                //    {
                //        flag = false;
                //        Console.WriteLine("Please enter a valid date of birth in the format x/xx/xxxx");
                //        buffer = Console.ReadLine();
                //    }
                //}

                Console.WriteLine("Please enter your Student ID");
                int ID = int.Parse(Console.ReadLine());

                Student student = db.Students.Find(ID);

                
                Console.WriteLine("How many immunizations are Required?");
                Console.Write(">  ");
                string buffer1 = Console.ReadLine();
                int requiredImmunizations = Int32.Parse(buffer1);
                int counter = 0;
                List<string> requiredImmunizationNames = new List<string>();

                //writing user input to database 
                student.student_dob.ToString();
                DateTime dateOnly = student.student_dob.Date;
                string dateFix = dateOnly.ToString("d");

                //var student = new Student { student_first_name = fname, student_last_name = lname, student_dob = DOB};
                //db.Students.Add(student);
                //db.SaveChanges();

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
               
                //writing to pdf 
                XgraphicTest.DrawString("Date of Birth: " + dateFix, studentFont, XBrushes.Black, new XRect(430, 54, 150, 60), XStringFormats.Center);
                XgraphicTest.DrawString("Student Name: " + student.student_first_name + " " + student.student_last_name, studentFont, XBrushes.Black, new XRect(110, 90, 0, 0), XStringFormats.Default);
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
        }
      

        static void DrawRectangle(XGraphics gfx, int x, int y, int width, int height)
        {
            XPen pen = new XPen(XColors.Black, Math.PI);
            
            gfx.DrawRectangle(pen, x, y, width, height);
        }

        static void DrawImage(XGraphics gfx, string jpegSameplePath, int x, int y, int width, int height)
        {
            XImage image = XImage.FromFile(jpegSameplePath);
            gfx.DrawImage(image, x, y, width, height);
        }
    }
}
