using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Abstract;
using WebApplication.Entities;

namespace WebApplication.Models
{
    public class EquipmentVM
    {
        private ICategoryRepository repositorycategory;

        private IEquipmentRepository repositoryequipment;


        public EquipmentVM(ICategoryRepository repositorycategory, IEquipmentRepository repositoryequipment)
        {
            this.repositorycategory = repositorycategory;
            this.repositoryequipment = repositoryequipment;

        }


        public IEnumerable<Equipment> Equipments
        {
            get
            {
                return repositoryequipment.Equipments;
            }

        }
        

        public List<Category> Categories
        {
            get
            {
                return repositorycategory.Categorys.ToList();
            }

        }

    }
}