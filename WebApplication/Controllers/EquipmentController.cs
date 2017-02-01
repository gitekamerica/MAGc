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

        public EquipmentController (IEquipmentRepository equipmentRepository)
        {
            this.repository = equipmentRepository;
        }




        // GET: Equipment
        public ActionResult EquipmentList()
        {

            return      View();
        }


        public ActionResult GetEquipment()
        {
            var equipments = repository.Equipments.OrderBy(x => x.EquipementName).ToList();

            return Json(new { data = equipments }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]

        public ActionResult Save(int id)
        {
            var v = repository.Equipments.Where(a => a.ID_equipment == id).FirstOrDefault();
            return View(v);
        }


        [HttpPost]
        public ActionResult Save(Equipment equ)
        {
            bool status = false;

            if (ModelState.IsValid)
            {
                repository.SaveEquipment(equ);
                status = true;

            }

            return new JsonResult { Data = new { staus = status } };

        }

    }
}