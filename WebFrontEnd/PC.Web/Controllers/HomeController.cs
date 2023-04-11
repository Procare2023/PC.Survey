using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC.DataLayer.Enum;
using PC.Repository.SurveyUnitOfWork;
using PC.Services.Core;
using PC.Services.Core.EmailModel;
using PC.Services.Core.Security;
using PC.Services.DL.DbContext;
using PC.Web.Models;
using System.Diagnostics;

namespace PC.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public readonly ISurveyUnitofWork _unitofWork;
        public HomeController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            AppDBContext context,
            IConfiguration config,
            ISurveyUnitofWork unitofWork
            ) : base(userManager, signInManager, roleManager, context, config)
        {
            _unitofWork = unitofWork;
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
            ViewBag.surveyCount = _unitofWork.GeneralSurveyReport.Count().ToString();
            ViewBag.Answred = _unitofWork.GeneralSurveyReport
                                .FindAllAsync(criteria: r => r.SurveyStatus == SurveyStatus.Answered).Result.Count();
            ViewBag.NotAnswred = _unitofWork.GeneralSurveyReport
                                .FindAllAsync(criteria: r => r.SurveyStatus == SurveyStatus.Sent).Result.Count();
            //ViewBag.NotSent = _unitofWork.GeneralSurveyReport
            //                    .FindAllAsync(criteria: r => r.SurveyStatus == SurveyStatus.Unsent).Result.Count();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}