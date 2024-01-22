using BildWebApp.Data;
using BildWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BildWebApp.Controllers;
public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;
    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        List<Category> ObjCatagoryList = _db.Categories.ToList();
        return View(ObjCatagoryList);
    }

   //---------- Add item in a databases----------//
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Category obj)
    {
        if(obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name", "The disply order cannot match the name");
        }
        if(ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        return View();
    }

    //-------Update item in a databases----------//
    public IActionResult Edit(int? id)
    {
        if(id == null || id == 0) {
            return NotFound();
        }
        Category? categoryFromDb  = _db.Categories.Find(id);
       // Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.ID ==id);
        //Category? categoryFromDb2 = _db.Categories.Where(u=>u.ID==id).FirstOrDefault();
        
        if(categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }
    [HttpPost]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name", "The disply order cannot match the name");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View();
    }
    //--------- Delete item in the databases ----------//
    public IActionResult Delete(int? id)
    {
        if(id == null || id == 0)
        {
            return NotFound();
        }
        Category? CategoryFormDb = _db.Categories.Find(id);

        if(CategoryFormDb == null)
        {
            return NotFound();
        }
        return View(CategoryFormDb);
    }

    [HttpPost,ActionName("Delete")]
    public IActionResult DeletePost(int? id)
    {
        Category? obj = _db.Categories.Find(id);
        if (obj == null)
        {
            return NotFound();
        }      
        _db.Categories.Remove(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

}
