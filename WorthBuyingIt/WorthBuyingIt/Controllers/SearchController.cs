using System.Linq;
using System.Web.Mvc;
using WBI.Data.Raven;
using WBI.Models.Product;

namespace WBI.Controllers
{
    public class SearchController : RavenController
    {
        /// <summary>
        /// Method used to show first page on startpage returning a View.
        /// </summary>
        /// <returns>Views/Search/Search.cshtml</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View("Search", null);
        }

        /// <summary>
        /// Method querying distinct products from database and returning filtered on params.
        /// </summary>
        /// <param name="value">Takes a search value from user</param>
        /// <param name="take">How many results to take per page</param>
        /// <returns>Json productlist result</returns>
        [HttpGet]
        public JsonResult GetDistinctProducts(string value, int take = 10)
        {
            var distinctProductList = RavenSession.Query<Product>().Where(o => o.Name.Contains(value)).Take(take).ToList();

            return Json(distinctProductList, JsonRequestBehavior.AllowGet);
        }
    }
}