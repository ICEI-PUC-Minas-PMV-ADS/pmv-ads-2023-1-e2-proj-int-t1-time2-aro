using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using permita_se.Data;
using permita_se.Data.ViewModel;
using permita_se.Model;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace permita_se.Controllers
{
    public class AccountController : Controller
    {
        private const string ActionName = "Home";
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly PermitaSeDbContext _context;

        public AccountController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, PermitaSeDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }


        public IActionResult Login() =>View(new LoginVM());


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user != null)
            {
                var passWordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Senha);
                if (passWordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Senha, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Produtos");
                    }
                }
                TempData["Error"] = "Credenciais inválidas. Por favor, confira seus dados e tente novamente!";
                return View(loginVM);
            }

            TempData["Error"] = "Credenciais inválidas. Por favor, confira seus dados e tente novamente!";
            return View(loginVM);
        }

        public IActionResult Register() => View(new RegisterVM());

    }
}
