using PersonMatterManager.BLL;
using PersonMatterManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonMatterManager.Web.Controllers
{
    public class LeaveController : Controller
    {
        // GET: Leave
        public ActionResult LeaveInfo()
        {
            return View();
        }

        public ActionResult LeaveInto()
        {
            return View();
        }

        public ActionResult LeaveSee()
        {
            return View();
        }

        LeaveBLL leaveBLL = new LeaveBLL();
        public JsonResult GetLeaveInfo()
        {
            return Json(leaveBLL.GetLeaveInfo());
        }

        public JsonResult GetLeaveUser()
        {
            UserInfo us = Session["UserInfo"] as UserInfo;
            return Json(leaveBLL.GetLeaveUser(us.UserID));
        }

        public JsonResult GetLeaveSee()
        {
            return Json(leaveBLL.GetLeaveSee());
        }

        public JsonResult GetLeaveSeeById(int id)
        {
            return Json(leaveBLL.GetLeaveSeeById(id).FirstOrDefault());
        }

        public ActionResult AddLeave(Leave leave)
        {
            leave.UserID = (Session["UserInfo"] as UserInfo).UserID;
            leave.LeaveState = 0;
            leave.LeaveTime = DateTime.Now;
            return Content(leaveBLL.AddLeave(leave).ToString());
        }

        public ActionResult DelLeave(string[] stime,string[] etime)
        {
            return Content(leaveBLL.DelLeave(stime, etime).ToString());
        }

        public JsonResult SeeLeaveInfo(string stime,string etime)
        {
            return Json(leaveBLL.SeeLeaveInfo(Convert.ToDateTime(stime), Convert.ToDateTime(etime)).FirstOrDefault());
        }

        public ActionResult SaveSeeLeave(string appreason, int select,string stime,string etime)
        {
            return Content(leaveBLL.SaveSeeLeave(appreason, select, Convert.ToDateTime(stime), Convert.ToDateTime(etime)).ToString());
        }
    }
}