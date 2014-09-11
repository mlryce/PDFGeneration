using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.classes
{
    public class organization
    {
        public string organization_name;
            public string get_organization_name(){
                return this.organization_name;
            }
            public void set_organization_name(string name){
                this.organization_name = name;
            }

            public organization(){

                this.organization_name = "test";

            }
   
    }
               
    }

