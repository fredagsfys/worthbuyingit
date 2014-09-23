using System.Web.Mvc;
using WBI.Models.Scraper;

namespace WBI.Controllers
{
    public class ScrapeController : Controller
    {
        // GET: Scrape
        public ActionResult Index()
        {
            return View();
        }

        public void ScrapeIt()
        {
            var prisjakt = new Prisjakt("http://www.prisjakt.nu/produkt.php?p=2794262");
            prisjakt.Scrape();
        }
    }
}