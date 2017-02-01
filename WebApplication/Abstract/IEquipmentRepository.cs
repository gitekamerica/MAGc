using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Entities;

namespace WebApplication.Abstract
{
  public  interface IEquipmentRepository
    {

        IQueryable<Equipment> Equipments { get; }
        void SaveEquipment(Equipment equipment);

    }
}
