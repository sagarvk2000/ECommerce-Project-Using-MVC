using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Cate_Crud.Models;

namespace Product_Cate_Crud.Controllers
{
    public class ProductController : Controller
    {
        IConfiguration configuration;
        ProductCrud crud;
        CategoryCrud categoryCrud;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment env;

        public ProductController(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            this.configuration = configuration;
            crud = new ProductCrud(this.configuration);
            categoryCrud = new CategoryCrud(this.configuration);
            this.env = env;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            return View(crud.GetProducts());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View(crud.GetProductById(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.Categorires = categoryCrud.GetCategories();
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product pro, IFormFile file)
        {
            try
            {
                using (var fs = new FileStream(env.WebRootPath + "\\images\\" + file.FileName, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fs);
                }
                pro.Imageurl = "~/images/" + file.FileName;
                var result = crud.AddProduct(pro);
                if (result >= 1)
                    return RedirectToAction(nameof(Index));
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var pro = crud.GetProductById(id);
            ViewBag.Categorires = categoryCrud.GetCategories();
            HttpContext.Session.SetString("oldImageUrl", pro.Imageurl);
            return View(pro);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product pro, IFormFile file)
        {
            try
            {
                string oldimageurl = HttpContext.Session.GetString("oldImageUrl");
                if (file != null)
                {
                    using (var fs = new FileStream(env.WebRootPath + "\\images\\" + file.FileName, FileMode.Create, FileAccess.Write))
                    {
                        file.CopyTo(fs);
                    }
                    pro.Imageurl = "~/images/" + file.FileName;


                    string[] str = oldimageurl.Split("/");
                    string str1 = (str[str.Length - 1]);
                    string path = env.WebRootPath + "\\images\\" + str1;
                    System.IO.File.Delete(path);
                }
                else
                {
                    pro.Imageurl = oldimageurl;
                }
                var result = crud.UpdateProduct(pro);
                if (result >= 1)
                    return RedirectToAction(nameof(Index));
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }

        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(crud.GetProductById(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                var pro = crud.GetProductById(id);
                string[] str = pro.Imageurl.Split("/");
                string str1 = (str[str.Length - 1]);
                string path = env.WebRootPath + "\\images\\" + str1;
                System.IO.File.Delete(path);
                var result = crud.DeleteProduct(id);
                if (result >= 1)
                    return RedirectToAction(nameof(Index));
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
