using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Entities
{
    public class Equipment
    {
        [Key]
        public int ID_equipment { get; set; }
        public string EquipementName { get; set; }
        public string EquipmentDescription { get; set; }

    }
}