using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using InventoryApp.Core.Models;
using InventoryApp.Persistence;

namespace InventoryApp.Controllers.Api
{
    [Authorize]
    public class ItemsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ItemsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Delete (int id)
        {
            var userId = User.Identity.GetUserId();
            var item = _context.Items.Single(i => i.Id == id && i.UserId == userId);

            if (item.IsDeleted)
                return NotFound();

            item.IsDeleted = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
