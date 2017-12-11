using InventoryApp.Core;
using InventoryApp.Core.Models;
using InventoryApp.Core.ViewModels;
using InventoryApp.Persistence;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace InventoryApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public ActionResult Search(ItemFormViewModel viewModel)
        {
            return RedirectToAction("Index", "Home", new { query = viewModel.SearchTerm });
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new ItemFormViewModel
            {
                Items = new ApplicationDbContext().Items.ToList(),
                Heading = "Add Inventory"
            };
            return View(viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var context = new ApplicationDbContext();
            var item = context.Items.Single(i => i.Id == id && i.UserId == userId);

            var viewModel = new ItemFormViewModel
            {
                Heading = "Edit Inventory",
                Id = item.Id,
                Items = context.Items.ToList(),
                Company = item.Company,
                Description = item.Description,
                Quantity = item.Quantity,
                Cost = item.Cost

            };
            return View("Create", viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Update(ItemFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Items = new ApplicationDbContext().Items.ToList();

                return View("Create", viewModel);
            }

            //var item = _context.Items.Single(i => i.Id == viewModel.Id && i.UserId == userId);
            var item = _unitOfWork.Items.GetAllItems(viewModel.Id);

            if (item == null)
                return HttpNotFound();


            //var userId = User.Identity.GetUserId();
            //above var is in inline var next line
            if (item.UserId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            item.Description = viewModel.Description;
            item.Company = viewModel.Company;
            item.Cost = viewModel.Cost;
            item.Quantity = viewModel.Quantity;

            _unitOfWork.Complete();

            return RedirectToAction("MyInventory", "Item");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(ItemFormViewModel viewModel)
        {
            //var userId = User.Identity.GetUserId();
            //var user = _context.Users.Single(u => u.Id == userId);
            if (!ModelState.IsValid)
            {
                viewModel.Items = new ApplicationDbContext().Items.ToList();

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

            _unitOfWork.Items.Add(item);

            _unitOfWork.Complete();
            
            return RedirectToAction("MyInventory", "Item");
        }
    }
}