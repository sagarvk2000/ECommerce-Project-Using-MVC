using Microsoft.AspNetCore.Mvc;
using Product_Cate_Crud.Models;
using System.Data;

namespace Product_Cate_Crud.Controllers
{
    public class UserController : Controller
    {
        IConfiguration configuration;
        ProductCrud pcrud;
        RegisterCrud rcrud;
        LoginCrud lcrud;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment env;

        public UserController(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            this.configuration = configuration;
            pcrud = new ProductCrud(this.configuration);
            rcrud = new RegisterCrud(this.configuration);
            lcrud = new LoginCrud(this.configuration);
            this.env = env;
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View(pcrud.GetProducts());
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        // GET: UserController/Create

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register reg)
        {
            try
            {
                int result = rcrud.AddRegister(reg);
                if (result >= 1)
                    return RedirectToAction(nameof(Login));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Login(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Register reg)
        {
            try
            {             
                var model = lcrud.GetLogin(reg.Username, reg.Password);

                if (model.UserId>0)
                {
                    HttpContext.Session.SetString("status_id", model.status_id.ToString());
                    HttpContext.Session.SetString("userid", model.UserId.ToString());
                    HttpContext.Session.SetString("username", model.Username);

                    if (model.status_id == 1)
                    {
                        return RedirectToAction("Index", "Product");
                    }
                    else if(model.status_id == 2 )
                    {
                        return RedirectToAction("Index", "ShowProduct");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();

            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }

        // GET: UserController/Delete/5
        public ActionResult SingleProduct(int id)
        {
            var model=pcrud.GetProductById(id);
            return View(model);
        }

        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult UserList()
        {
            var model = rcrud.GetUser();
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id, IFormCollection collection)
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


