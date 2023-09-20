using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Cate_Crud.Models;

namespace Product_Cate_Crud.Controllers
{
    public class OrderController : Controller
    {
        IConfiguration configuration;
        ProductCrud pcrud;
        CartCrud ccrud;

        public OrderController(IConfiguration configuration)
        {
            this.configuration = configuration;
            pcrud = new ProductCrud(this.configuration);
            ccrud = new CartCrud(this.configuration);
        }
        // GET: OrderController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PlaceOrders(int id)
        {
            var model = pcrud.GetProductById(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult PlaceOrder(int id)
        {
            try
            {
                Order ord = new Order();
                string uid = HttpContext.Session.GetString("userid");
                ord.Userid = Convert.ToInt32(uid);
                ord.Id = id;
                ord.Quantity = 1;
                int result = ccrud.AddOrder(ord);
                if (result == 1)
                    return RedirectToAction(nameof(MyOrder));
                else
                    return View();

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //[HttpPost]
        public IActionResult MyOrder()
        {
            string userid = HttpContext.Session.GetString("userid");

            var model = ccrud.MyOrders(Convert.ToInt32(userid));

            return View(model);
        }
        public ActionResult Confirm()
        {
            return View();
        }

        public ActionResult DeleteOrder(int id)
        {
            try
            {
                var result = ccrud.RemoveOrder(id);

                return RedirectToAction("ViewCart","Cart");

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
