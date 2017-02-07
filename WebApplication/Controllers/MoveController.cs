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

        public MoveController(IMoveStorage moveRepository, IMoveDetails detailsrepository)
        {
            this.repositorystorage = moveRepository;

            this.repositorydetails = detailsrepository;

        }




        // GET: Move
        public ActionResult MoveTask()
        {
            return View();
        }


        // post save 

        [HttpPost]

        public JsonResult SaveMove(MoveVM m)
        {
            bool status = false;

            if (ModelState.IsValid)
            {
                MoveStorage movestorages = new MoveStorage { MoveNo = m.MoveNo,  MoveDescription = m.MoveDescription };
                repositorystorage.SaveMoveStorage(movestorages);


                foreach (var i in m.MoveList)
                {

                    repositorydetails.SaveMoveDetails(i);
                }

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