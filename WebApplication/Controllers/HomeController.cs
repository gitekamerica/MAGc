using System.Web.Mvc;
using WebApplication.Abstract;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {

        private IProductRepository repository;

        public HomeController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ActionResult DashboardV1()
        {
            return View();
        }
        public ActionResult DashboardV2()
        {
            return View();
        }


       
          
      
        public ViewResult List()
        {
            return View(repository.Products);
        }

    }
}