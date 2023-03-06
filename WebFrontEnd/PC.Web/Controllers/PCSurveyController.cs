using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PC.Repository.SurveyUnitOfWork;
using PC.Services.Core;
using PC.Services.Core.Helper.Consts;
using PC.Services.Core.Interfaces;
using PC.Services.Core.Models;
using PC.Services.Core.Security;
using PC.Services.DL.DbContext;
using System.Security.Claims;

namespace PC.Web.Controllers
{
    [Authorize(Roles = PC.Services.Core.Helper.Consts.SD.Admin)]
    //[AllowAnonymous]
    public class PCSurveyController : BaseController
    {
        public readonly ISurveyUnitofWork _unitofWork;
        public PCSurveyController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            AppDBContext context,
            IConfiguration config
, ISurveyUnitofWork unitofWork) : base(userManager, signInManager, roleManager, context, config)
        {
            _unitofWork = unitofWork;
        }

        #region Survey
        /**************Survey Section******************************************/

        [HttpGet]
        //[Authorize("ListRoles-AdminController")]
        public async Task<IActionResult> Index()
        {
            var SurveyList = await _unitofWork.GeneralSurveyReport.GetAllAsync();
            return View(SurveyList);
        }



        /**************End Activity Section******************************************/
        #endregion Survey



    }
}
