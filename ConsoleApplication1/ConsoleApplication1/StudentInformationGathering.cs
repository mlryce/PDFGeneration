using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; 

namespace ConsoleApplication1
{
    class StudentInformationGathering
    {
        public int StudentInformationGatheringID { get; set; }
        public string StudentFirstName { get; set; }

        public string StudentLastName { get; set; }

        public DateTime StudentDOB { get; set; }

    }
}
