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

        private IMoveStorage repositorystorage;
        private IMoveDetails repositorydetails;
        private IEquipmentRepository repositoryequipment;
        private IPersonRepository repositoryperson;


        public MoveController(IMoveStorage moveRepository, IMoveDetails detailsrepository, IEquipmentRepository repositoryeq, IPersonRepository personRepository)
        {
            this.repositoryequipment = repositoryeq;

            this.repositorystorage = moveRepository;

            this.repositorydetails = detailsrepository;
            this.repositoryperson = personRepository;


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

            var data = (from x in repositoryequipment.Equipments.AsEnumerable()
                        join y in repositoryperson.Persons.AsEnumerable()
                        on x.Person equals y.IdPerson
                        where x.Person == idos

                        select new { EquipementName = x.EquipementName }).ToList();


       
            



            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }


        // post save 

        [HttpPost]

        public JsonResult SaveMove(MoveVM m)
        {
            bool status = false;

            if (ModelState.IsValid)
            {
                MoveStorage movestorages = new MoveStorage { MoveNo = m.MoveNo,  MoveDescription = m.MoveDescription, MoveDetails=m.MoveList };
                repositorystorage.SaveMoveStorage(movestorages);


            

                status = true;

            }
            else
            {
                status = false;
            }


            return new JsonResult { Data = new { status = status } };

        }
    }
}