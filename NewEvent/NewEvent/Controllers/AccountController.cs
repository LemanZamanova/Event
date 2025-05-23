using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NewEvent.Models;
using NewEvent.Utilities;
using NewEvent.ViewModels.User;

namespace NewEvent.Controllers;
public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }
    public IActionResult Register()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM registerVM)
    {
        if (!ModelState.IsValid) return View(registerVM);

        AppUser user = new AppUser
        {
            Name = registerVM.Name,
            Surname = registerVM.Surname,
            Email = registerVM.Email,
            UserName = registerVM.UserName,
        };

        var result = await _userManager.CreateAsync(user, registerVM.Password);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
                return View(registerVM);
            }

        }
        await _userManager.AddToRoleAsync(user, registerVM.Password);
        await _signInManager.SignInAsync(user, false);
        return RedirectToAction("Index", "Home");





    }
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM loginVM, string? returnUrl)
    {
        if (!ModelState.IsValid) return View(loginVM);







        return View();
    }



    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignInAsync();

        return RedirectToAction("Index", "Home");
    }



    //ModelState.AddModelError(string.Empty, "Password Username or Email is incorrect");
    //            return View(registerVM);
    

    public async IActionResult CreateRole()
    {
        foreach (UserRole role in Enum.GetValuesAsUnderlyingType(role.ToString())) 
        {
            if(!await _roleManager.CreateAsync(UserRole.Member.ToString()))
                await _roleManager.
        }


    }
}