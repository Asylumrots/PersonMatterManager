using PersonMatterManager.BLL;
using PersonMatterManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonMatterManager.Web.Controllers
{
    public class SignController : Controller
    {
        // GET: Sign
        #region 页面显示视图
        public ActionResult SignIn()
        {
            return View();
        }

        public ActionResult Calender()
        {
            return View();
        }

        public ActionResult SignSee()
        {
            return View();
        }

        public ActionResult SignRecord()
        {
            return View();
        }
        #endregion

        AttendanceSheetBLL sheetBLL = new AttendanceSheetBLL();
        public ActionResult CheckSign()
        {
            UserInfo us = Session["UserInfo"] as UserInfo;
            //2019-03-04 00:00:00.000  
            return Content(sheetBLL.CheckSign(us.UserID, Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString());
        }

        public ActionResult AddSign()
        {
            UserInfo us = Session["UserInfo"] as UserInfo;
            return Content(sheetBLL.AddSign(us.UserID).ToString());
        }

        public JsonResult GetSignSeeDep()
        {
            UserInfo us = Session["UserInfo"] as UserInfo;
            return Json(sheetBLL.GetSignSeeDep(Convert.ToInt32(us.DepartmentID)));
        }

        public JsonResult GetSignRecordAll()
        {
            return Json(sheetBLL.GetSignRecordAll());
        }

        public ActionResult AddRemake(string time,string name,string remakes)
        {
            return Content(sheetBLL.AddRemake(Convert.ToDateTime(time), name, remakes).ToString());
        }

        public ActionResult DelAttendance(string[] time, string[] name)
        {
            return Content(sheetBLL.DelAttendance(time, name).ToString());
        }

        public JsonResult GetPageInfo(int PageIndex, int PageSize)
        {
            int total;
            var list = sheetBLL.GetPageInfo(PageIndex, PageSize, out total);
            int num = total;
            return Json(new { list, num });
        }

        public JsonResult GetCanvasInfo()
        {
            return Json(sheetBLL.GetCanvasInfo());
        }
    }
}