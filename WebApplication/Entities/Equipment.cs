using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Entities
{


    public class Equipment
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ID_equipment { get; set; }     
        [DisplayName("Nazwa sprzetu")]
        public string EquipementName { get; set; }
        public string EquipmentDescription { get; set; }
        public int  Category { get; set; }
        public int? Person { get; set; }

    }




}