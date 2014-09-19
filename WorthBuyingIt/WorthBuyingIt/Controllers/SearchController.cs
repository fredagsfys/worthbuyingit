using System.Linq;
using System.Web.Mvc;
using WorthBuyingIt.Models;

namespace WorthBuyingIt.Controllers
{
    public class SearchController : RavenController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult Index()
        {
            return View("Search");
        }

        /// <summary>
        /// 
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