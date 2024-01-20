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

}
