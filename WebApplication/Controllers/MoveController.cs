using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Abstract;
using WebApplication.Entities;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class MoveController : Controller
    {

        //private IMoveStorage repositorystorage;
        //private IMoveDetails repositorydetails;
        private IEquipmentRepository repositoryequipment;
        private IPersonRepository repositoryperson;
        private ICategoryRepository repositorycategory;


        public MoveController( IEquipmentRepository repositoryeq, IPersonRepository personRepository, ICategoryRepository repositorycat)
        {
            this.repositoryequipment = repositoryeq;
            this.repositoryperson = personRepository    ;
            this.repositorycategory = repositorycat;

            // this.repositorystorage = moveRepository;
            // this.repositorydetails = detailsrepository;

        }




        // GET: Move
        public ActionResult MoveTask()
        {
            IEnumerable<Equipment> equipments = repositoryequipment.Equipments;




            return View(equipments);
        }



        public ActionResult LoadEquipments(string idOsoby)
        {

            int idos = Int32.Parse(idOsoby);

            var data = 
                        (from x in repositoryequipment.Equipments.AsEnumerable()
                         join y in repositorycategory.Categorys.AsEnumerable()
                         on x.Category equals y.id_category
                         join z in repositoryperson.Persons.AsEnumerable()
                         on x.Person equals z.IdPerson
                         where x.Person == idos

                         select new
                         {
                             ID_equipment = x.ID_equipment,
                             EquipementName = x.EquipementName,
                             EquipmentDescription = x.EquipmentDescription,
                             SerialNumber = x.SerialNumber,
                             CompanyNumber = x.CompanyNumber,
                             CategoryName = y.categoryName,
                             Person = z.FirstName + " " + z.Surname
                         }).ToList();
            



            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }


        // post save 

        //[HttpPost]

        //public JsonResult SaveMove(MoveVM m)
        //{
        //    bool status = false;

        //    if (ModelState.IsValid)
        //    {
        //        MoveStorage movestorages = new MoveStorage { MoveNo = m.MoveNo,  MoveDescription = m.MoveDescription, MoveDetails=m.MoveList };
        //        repositorystorage.SaveMoveStorage(movestorages);

        //        status = true;

        //    }
        //    else
        //    {
        //        status = false;
        //    }
        //    return new JsonResult { Data = new { status = status } };

        //}
    }
}