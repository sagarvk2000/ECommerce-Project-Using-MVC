using Microsoft.AspNetCore.Mvc;
using Product_Cate_Crud.Models;

namespace Product_Cate_Crud.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration configuration;
        private CategoryCrud crud;

        public CategoryController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new CategoryCrud(this.configuration);
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            var model = crud.GetCategories();
            return View(model);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var result = crud.GetCategoryById(id);
            return View(result);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category cat)
        {
            try
            {
                int result = crud.AddCategory(cat);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = crud.GetCategoryById(id);
            return View(result);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category cat)
        {
            try
            {
                int result = crud.UpdateCategory(cat);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = crud.GetCategoryById(id);
            return View(result);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteCategory(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
