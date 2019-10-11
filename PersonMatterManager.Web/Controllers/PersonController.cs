using PersonMatterManager.BLL;
using PersonMatterManager.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonMatterManager.Web.Controllers
{
    public class PersonController : Controller
    {
        UserInfoBLL userInfoBLL = new UserInfoBLL();
        public ActionResult PersonManager()
        {
            return View();
        }

        public ActionResult PersonInfo()
        {
            return View();
        }

        public ActionResult FriendInfo()
        {
            return View();
        }

        public ActionResult ModifyPwd(string oldpwd,string newpwd)
        {
            int id = (Session["UserInfo"] as UserInfo).UserID;
            string modify = userInfoBLL.ModifyPwd(id, oldpwd, newpwd);
            if (modify == "True")
                Session["UserInfo"] = null;
            return Content(modify);
        }

        public bool ModifyInfo(string id,string name,string sex,string age,string tel,string remark,string address,string s)
        {
            UserInfo us = new UserInfo();
            bool modify = userInfoBLL.ModifyInfo(id, name, sex, age, tel, remark, address, s, out us);
            if (modify == true)
                Session["UserInfo"] = us;
            return modify;
        }
        

        public bool ModifyInfoimg(HttpPostedFileBase files)
        {
            string s="";
            if (files != null)
            {
                var webRootPath = AppDomain.CurrentDomain.BaseDirectory;
                string relativeDirPath = "\\wwwroot\\images";
                string absolutePath = webRootPath + relativeDirPath;

                string[] fileTypes = new string[] { ".gif", ".jpg", ".jpeg", ".png", ".bmp" };
                string extension = Path.GetExtension(files.FileName);
                if (fileTypes.Contains(extension.ToLower()))
                {
                    //if (!Directory.Exists(absolutePath)) Directory.CreateDirectory(absolutePath);
                    Guid gid = Guid.NewGuid();
                    string fileName = gid.ToString() + extension;
                    var filePath = absolutePath + "\\" + fileName;
                    files.SaveAs(filePath);
                    s = fileName;
                }
            }
            UserInfo us = new UserInfo();
            int UserID = (Session["UserInfo"] as UserInfo).UserID;
            bool modify = userInfoBLL.ModifyInfoimg(UserID, s,out us);
            if (modify == true)
                Session["UserInfo"] = us;
            return modify;
        }
        
        public JsonResult GetFriendInfo(int PageIndex,int PageSize)
        {
            int total;
            UserInfo us = Session["UserInfo"] as UserInfo;
            var list = userInfoBLL.GetFriendInfo(Convert.ToInt32(us.DepartmentID), Convert.ToInt32(us.UserID), PageIndex, PageSize, out total);
            int num = total;
            return Json(new { list, num });
            //UserInfo us = Session["UserInfo"] as UserInfo;
            //return Json(userInfoBLL.GetFriendInfo(Convert.ToInt32(us.DepartmentID), Convert.ToInt32(us.UserID)));
        }

        public JsonResult GetPerson()
        {
            return Json(userInfoBLL.GetPerson());
        }

        public JsonResult GetDepSelect()
        {
            DepartmentBLL departmentBLL = new DepartmentBLL();
            return Json(departmentBLL.GetDepartmentInfo());
        }

        public JsonResult GetRoleSelect()
        {
            RoleBLL roleBLL = new RoleBLL();
            return Json(roleBLL.GetRole());
        }

        public ActionResult AddPerson(UserInfo us,HttpPostedFileBase file)
        {
            us.EntryTime = DateTime.Now;
            us.UserStatr = 1;
            //return Content(userInfoBLL.AddPerson(us).ToString());
            bool add = userInfoBLL.AddPerson(us);
            return Content(add.ToString());
        }

        public bool AddInfoimg(string UserName,HttpPostedFileBase files)
        {
            string s = "";
            if (files != null)
            {
                var webRootPath = AppDomain.CurrentDomain.BaseDirectory;
                string relativeDirPath = "\\wwwroot\\images";
                string absolutePath = webRootPath + relativeDirPath;

                string[] fileTypes = new string[] { ".gif", ".jpg", ".jpeg", ".png", ".bmp" };
                string extension = Path.GetExtension(files.FileName);
                if (fileTypes.Contains(extension.ToLower()))
                {
                    //if (!Directory.Exists(absolutePath)) Directory.CreateDirectory(absolutePath);
                    Guid gid = Guid.NewGuid();
                    string fileName = gid.ToString() + extension;
                    var filePath = absolutePath + "\\" + fileName;
                    files.SaveAs(filePath);
                    s = fileName;
                }
            }
            UserInfo us = new UserInfo();
            bool modify = userInfoBLL.AddInfoimg(UserName,s);
            return modify;
        }

        public JsonResult GetPersonInfo(string number, string name)
        {
            return Json(userInfoBLL.GetPersonInfo(number, name));
        }

        public JsonResult GetPersonInfobyID(string id)
        {

            return Json(userInfoBLL.GetPersonInfobyID(Convert.ToInt32(id)));
        }

        public ActionResult ModifyPerson(UserInfo us)
        {
            return Content(userInfoBLL.ModifyPerson(us).ToString());
        }

        public ActionResult DelPerson(string[] number, string[] name)
        {
            return Content(userInfoBLL.DelPerson(number,name).ToString());
        }

        public JsonResult GetPageInfo(int PageIndex, int PageSize)
        {
            int total;
            var list = userInfoBLL.GetPageInfo(PageIndex, PageSize, out total);
            int num = total;
            return Json(new {list,num});
        }
    }
}