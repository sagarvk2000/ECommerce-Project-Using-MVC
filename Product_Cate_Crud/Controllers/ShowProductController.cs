using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Cate_Crud.Models;

namespace Product_Cate_Crud.Controllers
{
    public class ShowProductController : Controller
    {
        IConfiguration configuration;
        ProductCrud pcrud;

        public ShowProductController(IConfiguration configuration)
        {
            this.configuration = configuration;
            pcrud = new ProductCrud(this.configuration);
        }


        // GET: ShowProductController
        public ActionResult Index(int pg=1)
        {
            var model = pcrud.GetProducts();
            const int pagesize = 8;
            if (pg < 1)
            {
                pg = 1;
            }

            int recscount = model.Count();

            var pager = new Pager(recscount, pg, pagesize);

            int recskip = (pg - 1) * pagesize;

            var data = model.Skip(recskip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;
            return View(data);
        }

        // GET: ShowProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShowProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShowProductController/Create
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

        // GET: ShowProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShowProductController/Edit/5
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

        // GET: ShowProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShowProductController/Delete/5
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
