using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Entities
{
    public class MoveDetails
    {
        public int MoveItemsID { get; set; }

        public int MoveID { get; set; }

        public string ItemName { get; set; }

        public int Quantity { get; set; }

        public string Rate { get; set; }

        public decimal TotalAmount { get; set; }

    }
}