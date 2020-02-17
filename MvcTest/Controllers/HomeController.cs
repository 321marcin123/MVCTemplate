using AutoMapper;
using Serilog;
using System.Web.Mvc;

namespace MvcTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public HomeController()
        {

        }

        public HomeController
            (
                IMapper mapper,
                ILogger logger
            )
        {
            this.mapper = mapper;
            this.logger = logger;
        }


        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}