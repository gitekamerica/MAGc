using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Entities;

namespace WebApplication.Models
{
    public class MoveVM
    {

        public string  MoveNo { get; set; }
        public DateTime MoveDate { get; set; }
        public string Description { get; set; }
        public List<MoveDetails> MoveList { get; set; }


    }
}