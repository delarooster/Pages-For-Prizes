﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Web
{
    public class Prize
    {
        public int ID { get; set; }

        
        public int UserType { get; set; }

        
        public int Milestone { get; set; }

        
        public int MaxNumPrizes { get; set; }

       
        public bool isActive { get; set; }


        public int FamilyID { get; set; }

        
        public DateTime StartDate { get; set; }

        
        public DateTime EndDate { get; set; }

        public string Title { get; set; }
    }
}