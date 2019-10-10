using PersonMatterManager.BLL;
using PersonMatterManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonMatterManager.Web.Controllers
{
    public class LoginController : Controller
    {
        UserInfoBLL userInfoBLL = new UserInfoBLL();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public bool CheckLogin(string name,string pwd)
        {
            UserInfo userinfo = userInfoBLL.checkLogin(name, pwd);
            if (userinfo != null)
            {
                Session["UserInfo"] = userinfo;
                return true;
            }
            return false;
        }
    }
}