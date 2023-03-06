using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC.Services.Core;
using PC.Services.Core.EmailModel;
using PC.Services.Core.Interfaces;
using PC.Services.Core.Security;
using PC.Services.DL.DbContext;
using PC.Web.Models;
using System.Diagnostics;

namespace PC.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            AppDBContext context,
            IConfiguration config
            ) : base(userManager, signInManager, roleManager, context, config)
        {
        }

        //[AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        //[Authorize]
        //[AllowAnonymous]
        public async Task<IActionResult> Home()
        {

            //throw new Exception("Error has been occured");
            ViewBag.users = _context.Users.Count();
            ViewBag.Approvals = "15000";//_context.TrsDetails.Count();
            ViewBag.AuthorityMatrix = "1000"; //_context.AuthorityMatrix.Count();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}