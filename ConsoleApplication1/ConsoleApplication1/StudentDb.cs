﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace ConsoleApplication1
{
     class StudentDb : DbContext
    {
        public DbSet<StudentInformationGathering> StudentInformationGathering { get; set; } 
    }
}
