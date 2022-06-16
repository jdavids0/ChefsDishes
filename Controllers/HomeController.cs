using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefsDishes.Models;

namespace ChefsDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    // *** ROOT ROUTE, SHOW ALL CHEFS ***
    public IActionResult Index()
    {
        // List<Chef> AllChefs = _context.Chefs.ToList();
        ViewBag.AllChefs = _context.Chefs.Include(a => a.CreatedDishes).ToList();
        return View();
    }

    // *** SHOW ALL DISHES ROUTE ***
    [HttpGet("dishes")]
    public IActionResult Dishes(){
        ViewBag.AllDishes = _context.Dishes.Include(a => a.Creator).ToList();
        // ViewBag.AllChefs = _context.Chefs.ToList();
        return View();
    }

    // *** CREATE CHEF ROUTES ***

    [HttpGet("new")]
    public IActionResult NewChef(){
        return View();
    }

    [HttpPost("chef/add")]
    public IActionResult AddChef(Chef newChef)
    {
        if(ModelState.IsValid)
        {
            // adding validation for age using .Now.Year built-ins
            if((DateTime.Now.Year - newChef.DateOfBirth.Year) < 18)
            {
                ModelState.AddModelError("DateOfBirth", "Must be 18 or older");
                return View("NewChef");
            } else {
                _context.Add(newChef);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

        } else {
            return View("NewChef");
        }
    }

    // *** CREATE DISH ROUTES ***
    [HttpGet("dishes/new")]
    public IActionResult NewDish()
    {
        ViewBag.AllChefs = _context.Chefs.ToList();
        return View();
    }

    [HttpPost("dish/add")]
    public IActionResult AddDish(Dish newDish)
    {
        if(ModelState.IsValid){  
            _context.Add(newDish);
            _context.SaveChanges();    
            return RedirectToAction("Dishes");
        } else {
            return View("NewDish");
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
