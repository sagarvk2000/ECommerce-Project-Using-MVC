using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Cate_Crud.Models;

namespace Product_Cate_Crud.Controllers
{
    public class CartController : Controller
    {
        IConfiguration configuration;
        ProductCrud pcrud;
        LoginCrud lcrud;
        CartCrud ccrud;
        public CartController(IConfiguration configuration)
        {
            this.configuration = configuration;
            pcrud = new ProductCrud(this.configuration);
            lcrud = new LoginCrud(this.configuration);
            ccrud = new CartCrud(this.configuration);
        }

        // GET: CartController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        


        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
        [HttpGet]
        public ActionResult AddToCart(int id)//this is product id
        {
            try
            {
                Cart cart = new Cart();
                string uid = HttpContext.Session.GetString("userid");
                cart.Userid = Convert.ToInt32(uid);
                cart.Id = id;
                cart.Quantity = 1;
                int result = ccrud.AddToCart(cart);
                if (result == 1)
                    return RedirectToAction(nameof(ViewCart));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        // GET: CartController/Edit/5
        public ActionResult ViewCart()
        {
            string uid = HttpContext.Session.GetString("userid");
            var res = ccrud.ViewCart(Convert.ToInt32(uid));
            return View(res);
        }

        // POST: CartController/Edit/5
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



        // GET: CartController/Delete/5
        public ActionResult RemoveCart(int id)//product id
        {
            try
            {
                var result = ccrud.DeleteCart(id);

                return RedirectToAction(nameof(ViewCart));

            }
            catch (Exception ex)
            {
                return View();
            }
        }   
    }
}
