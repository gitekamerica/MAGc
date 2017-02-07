using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Entities;

namespace WebApplication.Models
{
    public class MoveVM
    {
      
    //    public DateTime MoveDate { get; set; }
     

        public string MoveNo { get; set; }
     

        public string MoveDescription { get; set; }

        public List<MoveDetails> MoveList { get; set; }



    }
}