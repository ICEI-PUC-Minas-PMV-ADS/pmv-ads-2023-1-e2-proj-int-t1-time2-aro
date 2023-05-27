using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using permita_se.Data;
using permita_se.Data.Static;
using permita_se.Data.ViewModel;
using permita_se.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
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

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.Email);
            if (user != null)
            {
                TempData["Error"] = "Esse e-mail já está sendo utilizado!";
                return View(registerVM);
            }

            var newUser = new Usuario()
            {
                Nome = registerVM.Nome,
                Email = registerVM.Email,
                UserName = registerVM.Email
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Senha);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Produtos");
        }
     
    }
}
