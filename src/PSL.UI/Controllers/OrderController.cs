using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PSL.UI.Core;
using PSL.UI.Core.Caching;
using PSL.UI.Core.Data;
using PSL.UI.Core.Data.Entities;
using PSL.UI.Core.Identity;
using PSL.UI.Core.Mvc;
using PSL.UI.Helper;
using PSL.UI.Models;
using X.PagedList;

namespace PSL.UI.Controllers
{
    public class OrderController : AuthController
    {
        public OrderController()
        {
        }

        public OrderController(ApplicationDbContext dbContext, ApplicationUserManager userManager) : base(dbContext, userManager)
        {
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var orders = DbContext.Orders.Where(w => w.ClientId == userId).Include(a => a.Product).OrderByDescending(a => a.Date);

            ViewBag.Suppliers = new SelectList(DbContext.Suppliers, "Id", "Name");

            return View(orders);
        }

        public ActionResult History(int page = 1)
        {
            var userId = User.Identity.GetUserId();
            var purchases = DbContext.Purchases.Where(w => w.BuyerId == userId).Include(a => a.Supplier).Include(a => a.PurchaseInOrders.Select(b=>b.Product)).OrderByDescending(a => a.Date).ToPagedList(page, 20);

            return View(purchases);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(CheckoutViewModel model)
        {
            if (ModelState.IsValid)
            {

                var userId = User.Identity.GetUserId();
                var purchase = new Purchase
                {
                    Date = DateTime.Now,
                    SupplierId = model.SupplierId,
                    BuyerId = userId
                };
                var totalPrice = 0m;

                foreach (var item in model.Items)
                {
                    var product = DbContext.Products.Find(item.ProductId);
                    var order = DbContext.Orders.Find(item.OrderId);

                    if (product == null || order == null)
                        continue;

                    //add
                    purchase.PurchaseInOrders.Add(new PurchaseInOrder
                    {
                        ProductId = product.Id,
                        Quantity = item.Quantity
                    });

                    //edit
                    product.Inventory -= item.Quantity;
                    DbContext.Entry(product).State = EntityState.Modified;

                    //remove
                    order.Deleted = true;
                    DbContext.Entry(order).State = EntityState.Modified;

                    totalPrice += item.Quantity * product.Price;
                }

                //add
                purchase.TotalAmount = totalPrice;
                DbContext.Purchases.Add(purchase);

                //commit
                DbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(int productId, int quantity)
        {
            if (!Request.IsAjaxRequest())
                return new EmptyResult();

            var product = DbContext.Products.Find(productId);

            if (product == null)
                return HttpNotFound();

            if (quantity > product.Inventory)
                return Json("Product quantity large than inventory count");

            var totalPrice = quantity * product.Price;
            var userId = User.Identity.GetUserId();

            //add 
            DbContext.Orders.Add(new Order
            {
                ProductId = productId,
                Quantity = quantity,
                Price = totalPrice,
                Date = DateTime.Now,
                ClientId = userId,
                Title = $"{product.Name} - {totalPrice}"
            });

            //commit
            DbContext.SaveChanges();

            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var order = DbContext.Orders.Find(id);

            if (order == null)
                return HttpNotFound();

            //remove 
            order.Deleted = true;
            DbContext.Entry(order).State = EntityState.Modified;

            //commit
            DbContext.SaveChanges();

            //cache
            var userId = User.Identity.GetUserId();
            ProductCache.ClearOrders(userId);

            return RedirectToAction("Index");
        }

    }
}