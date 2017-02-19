using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Entities
{
    public class Category
    {
      [Key]
      public int id_category { get; set; }

      public  string categoryName { get; set; }

      

    }
}