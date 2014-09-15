using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1.classes
{
    public class student
    {
        string student_first_name;
        string student_last_name;
        DateTime student_dob;
        organization student_school;
        

            public string get_student_name()
            {
                return this.student_first_name + " " + this.student_last_name;
            }
            public void set_student_first_name(string fn)
            {
                this.student_first_name = fn;
            }
            public void set_student_last_name(string ln)
            {
                this.student_last_name = ln;
            }

     public student()
     {
         student_first_name = "Bob";
         student_last_name = "Smith";
         student_dob = DateTime.Now;
         student_school = null;
     }

     public student(string fn, string ln, DateTime dob, organization school)
     {
         student_first_name = fn;
         student_last_name = ln;
         student_dob = dob;
         student_school = school;
     }

        
    }
}
