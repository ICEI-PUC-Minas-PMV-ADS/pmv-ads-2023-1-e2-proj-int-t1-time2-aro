using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using permita_se.Data;
using permita_se.Data.ViewModel;
using permita_se.Migrations;
using System;

namespace permita_se.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly PermitaSeDbContext _context;

        public AccountController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, PermitaSeDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _context = context;
        }


        public IActionResult Login() =>View(new LoginVM());
      
    }
}
