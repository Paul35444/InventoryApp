using InventoryApp.Controllers;
using InventoryApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace InventoryApp.ViewModels
{
    public class ItemFormViewModel
    {
        public int Id { get; set; }

        //[Required]
        public ApplicationUser User { get; set; }

        //[Required]
        public string UserId { get; set; }

        [Required]
        public string Company { get; set; }

        //public string CompanyId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Cost { get; set; }

        public IEnumerable<Item> Items { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<ItemsController, ActionResult>> update =
                    (i => i.Update(this));

                Expression<Func<ItemsController, ActionResult>> create =
                    (i => i.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }
    }
}