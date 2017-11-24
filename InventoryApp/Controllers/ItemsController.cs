using InventoryApp.Models;
using InventoryApp.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace InventoryApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult MyInventory()
        {
            var userId = User.Identity.GetUserId();
            var items = _context.Items.Where(i => i.UserId == userId)
                .Include(i => i.Company)
                .ToList();

            return View(items);
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new ItemFormViewModel
            {
                Items = _context.Items.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(ItemFormViewModel viewModel)
        {
            //var userId = User.Identity.GetUserId();
            //var user = _context.Users.Single(u => u.Id == userId);
            if (!ModelState.IsValid)
            {
                viewModel.Items = _context.Items.ToList();

                return View("Create", viewModel);
            }
                var item = new Item
                {
                    UserId = User.Identity.GetUserId(),
                    Company = viewModel.Company,
                    //CompanyId = Company.Identity.GetCompanyId(),
                    Quantity = viewModel.Quantity,
                    Description = viewModel.Description,
                    Cost = viewModel.Cost
                };

                _context.Items.Add(item);
                _context.SaveChanges();

                return RedirectToAction("MyInventory", "Item");
            }
        }
    }