using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Abstract;
using WebApplication.Entities;

namespace WebApplication.Controllers
{
    public class EquipmentController : Controller
    {

        private IEquipmentRepository repository;
        private IPersonRepository repositoryperson;
        private ICategoryRepository repositorycategory;



        public EquipmentController (IEquipmentRepository equipmentRepository, IPersonRepository personRepository, ICategoryRepository repositorycategory)
        {
            this.repository = equipmentRepository;
            this.repositoryperson = personRepository;
            this.repositorycategory = repositorycategory;
        }

        // GET: Equipment
        public ActionResult EquipmentList()
        {
            return  View();
        }

        public ActionResult GetEquipment()
        {
            var equipments = (from x in repository.Equipments.AsEnumerable()
                             join y in repositorycategory.Categorys.AsEnumerable()
                             on x.Category equals y.id_category
                             join z in repositoryperson.Persons.AsEnumerable()
                             on x.Person equals z.IdPerson

                             select new { ID_equipment = x.ID_equipment, EquipementName = x.EquipementName, EquipmentDescription = x.EquipmentDescription, CategoryName = y.categoryName   , Person = z.FirstName + " " + z.Surname                 
              } ).ToList();
            return Json(new { data = equipments }, JsonRequestBehavior.AllowGet);
        }


        //Save or Edit EquipmentName
        [HttpGet]
        public ActionResult Save(int id)
        {
     
            var viewedit = repository.Equipments.Where(a => a.ID_equipment == id).FirstOrDefault();


            var categorie = repositorycategory.Categorys.Select(c => new SelectListItem()
            {
                Text = c.categoryName,
                Value = c.id_category.ToString()
            
            });


            ViewBag.Testowy = categorie;




            var osoby = repositoryperson.Persons.Select(c => new SelectListItem()
            {
                Text = c.FirstName + " " + c.Surname,
                Value = c.IdPerson.ToString()

            });


            ViewBag.Osoby = osoby;



            return PartialView(viewedit);
        }


        [HttpPost]
        public ActionResult Save(Equipment equ)
        {
            bool status = false;

           //equ.Category= Int32.Parse(Request["Testowy"]);


            if (ModelState.IsValid)
            {
                repository.SaveEquipment(equ);
                status = true;
            }
            else
            { 
                // błąd kontroli poprawności, więc ponownie wyświetlamy formularz wprowadzania danych
                return View();
            }

            return new JsonResult { Data = new { staus = status } };

        }







    }
}