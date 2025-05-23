using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewEvent.DAL;
using NewEvent.ViewModels;

namespace NewEvent.Controllers;
public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
       _context = context;
    }
    public async  Task<IActionResult> Index()
    {
        HomeVM homeVM = new HomeVM
        {
            Speakers = await _context.Speakers.Include(s => s.Position).ToListAsync()
        };
        return View(homeVM);
    }
}
