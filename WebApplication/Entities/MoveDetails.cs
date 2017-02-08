using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Entities
{
    public class MoveDetails
    {
        [Key]
        public int MoveItemsID { get; set; }

        public int MoveID { get; set; }

        public string ItemName { get; set; }

        public virtual MoveStorage MoveStorage { get; set; }

        //public int Quantity { get; set; }

        //public string Rate { get; set; }

        //public decimal TotalAmount { get; set; }

    }
}