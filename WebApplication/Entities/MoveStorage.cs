﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Entities
{
    public class MoveStorage
    {
        [Key]
        public int MoveID { get; set; }

        public string MoveNo { get; set; }

        public string MoveDate { get; set; }

        public string MoveDescription { get; set; }

        public virtual ICollection<MoveDetails> MoveDetails { get; set; }


    }
}