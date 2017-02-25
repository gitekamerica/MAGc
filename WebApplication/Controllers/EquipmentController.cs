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



        public EquipmentController(IEquipmentRepository equipmentRepository, IPersonRepository personRepository, ICategoryRepository repositorycategory)
        {
            this.repository = equipmentRepository;
            this.repositoryperson = personRepository;
            this.repositorycategory = repositorycategory;
        }

        // GET: Equipment
        public ActionResult EquipmentList()
        {
            return View();
        }

        public ActionResult GetEquipment()
        {
            var equipments = (from x in repository.Equipments.AsEnumerable()
                              join y in repositorycategory.Categorys.AsEnumerable()
                              on x.Category equals y.id_category
                              join z in repositoryperson.Persons.AsEnumerable()
                              on x.Person equals z.IdPerson

                              select new
                              {
                                  ID_equipment = x.ID_equipment,
                                  EquipementName = x.EquipementName,
                                  EquipmentDescription = x.EquipmentDescription,
                                  CategoryName = y.categoryName,
                                  Person = z.FirstName + " " + z.Surname
                              }).ToList();
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

            var wybranaosoba = (from os in  osoby
                                select os.Text).First().ToString();

            //  ViewBag.Osoby = osoby;



            return PartialView(viewedit);
        }


        [HttpPost]
        public ActionResult Save(int id, FormCollection form)
        {
            bool status = false;

          //  int id1 = Int32.Parse(Request.Form["ID_equipment"]);

            string category = Request.Form["Category"];
            string person = Request.Form["pa"]; ;
            string equipementName = Request.Form["EquipementName"];
            string companyNumber = Request.Form["CompanyNumber"];
            string serialNumber = Request.Form["SerialNumber"];
            string equipmentDescription = Request.Form["EquipmentDescription"];

            Equipment eq = new Equipment();

            if (ModelState.IsValid)
            {
                if (id > 0)
                {

                    var result = repository.Equipments.Where(x => x.ID_equipment == id).FirstOrDefault();

                    if(result!=null)
                    {
                        result.EquipementName = equipementName;
                        result.Person = Int32.Parse(person);
                        result.Category= Int32.Parse(category);
                        result.EquipmentDescription = equipmentDescription;
                        result.SerialNumber = serialNumber;
                        result.CompanyNumber = companyNumber;

                        repository.SaveEquipment(result);
                        status = true;
                    }


                }
                else
                {
                    eq.EquipementName = equipementName;
                    eq.EquipmentDescription = equipmentDescription;
                    eq.Category = Int32.Parse(category);
                    eq.Person = Int32.Parse(person);
                    eq.CompanyNumber = companyNumber;
                    eq.SerialNumber = serialNumber;

                    repository.SaveEquipment(eq);
                    status = true;
                }


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