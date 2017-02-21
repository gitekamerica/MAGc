using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Abstract;
using WebApplication.Entities;

namespace WebApplication.Controllers
{
    public class PersonController : Controller
    {
        private IPersonRepository repositoryperson;

        public PersonController(IPersonRepository personRepository)
        {
            this.repositoryperson = personRepository;
        }
        

        // GET: Person
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Save ()
        {
            IEnumerable<Persons> v = repositoryperson.Persons;
            return PartialView(v);
        }


        [HttpPost]
        public ActionResult Save(int id)
        {
            bool status = true;
            

            return new JsonResult { Data = new { staus = status } };

        }





        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Autocomplete(string term )
        {
            IEnumerable<Persons> vperson = repositoryperson.Persons;




            var result = new List<KeyValuePair<string, string>>();

            IList<SelectListItem> List = new List<SelectListItem>();


            foreach (var p in vperson)
            {

                List.Add(new SelectListItem { Text = p.FirstName + " " + p.Surname, Value = p.IdPerson.ToString() });
            }



            foreach (var item in List)
            {

                result.Add(new KeyValuePair<string, string>(item.Value.ToString(), item.Text));


            }
            var result3 = result.Where(s => s.Value.ToLower().Contains(term.ToLower())).Select(w => w).ToList();
            return Json(result3, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetDetail(int id)
        {
            Persons vperson = repositoryperson.Persons.Where(x => x.IdPerson == id).FirstOrDefault();

            Persons model = new Persons();
            // select data by id here display static data;
            if (id == 0)
            {
                model.IdPerson = 0;
                model.FirstName  = "brak";
                model.Surname = "brak";
                model.Position = "brak";
            }
            else
            {
                model.IdPerson = vperson.IdPerson;
                model.FirstName = vperson.FirstName;
                model.Surname = vperson.Surname;
                model.Position = vperson.Position;
            }

            return Json(model);

        }

        
    }
    public class DemoModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
    }







}