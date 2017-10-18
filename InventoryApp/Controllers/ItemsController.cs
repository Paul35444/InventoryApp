using System.Web.Mvc;

namespace InventoryApp.Controllers
{
    public class ItemsController : Controller
    {
        public ItemsController()
        {
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}