using InventoryApp.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace InventoryApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index(string query = null)
        {
            var enteredItems = _context
                .Items
                .Include(i => i.User)
                .Where(i => !i.IsDeleted);

            if(!string.IsNullOrWhiteSpace(query))
            {
                enteredItems = enteredItems
                    .Where(i =>
                    i.Company.Contains(query) ||
                    i.Description.Contains(query));
            }

            return View(enteredItems);
        }

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