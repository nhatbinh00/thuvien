using LiteLibrary.BusinessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LiteLibrary.Areas.Admin.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            var model = new Models.LoginModel();
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(Models.LoginModel model)
        {
            if (string.IsNullOrWhiteSpace(model.UserName) || string.IsNullOrWhiteSpace(model.Password))
            {
                ModelState.AddModelError("", "Username and password expected!");
                return View(model);
            }

            var user = UserAccountBLL.Authorize(model.UserName,model.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Login Failed!");
                return View(model);
            }

            FormsAuthentication.SetAuthCookie(model.UserName, false);
            return RedirectToAction("Index", "HomeAdmin");
        }
    }
}