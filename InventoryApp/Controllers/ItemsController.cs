using InventoryApp.Models;
using InventoryApp.ViewModels;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace InventoryApp.Controllers
{
    public class ItemsController : Controller
    {
        private ApplicationDbContext _context;

        public ItemsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new ItemFormViewModel
            {
                
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(ItemFormViewModel viewModel)
        {
            //var userId = User.Identity.GetUserId();
            //var user = _context.Users.Single(u => u.Id == userId);

            var item = new Item
            {
                UserId = User.Identity.GetUserId(),
                CompanyId = viewModel.Company,
                Quantity = viewModel.Quantity,
                Description = viewModel.Description,
                Cost = viewModel.Cost
            };

            _context.Items.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}