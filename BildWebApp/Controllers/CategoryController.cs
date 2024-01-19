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
}
