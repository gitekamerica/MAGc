using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Abstract;
using WebApplication.Entities;

namespace WebApplication.Concrete
{
    public class EFEquipmentRepository: IEquipmentRepository
    {

        private EFDbContext context = new EFDbContext();

        public IQueryable<Equipment> Equipments
        {
            get { return context.Equipments; }
        }


        public void SaveEquipment(Equipment equipment)
        {
            if (equipment.ID_equipment == 0)
            {
                context.Equipments.Add(equipment);
            }
            else
            {
                Equipment dbEntry = context.Equipments.Find(equipment.ID_equipment);
                if (dbEntry != null)
                {
                    dbEntry.ID_equipment = equipment.ID_equipment;
                    dbEntry.EquipementName = equipment.EquipementName;
                    dbEntry.EquipmentDescription = equipment.EquipmentDescription;
                   
                }
            }
            context.SaveChanges();
        }


    }
}