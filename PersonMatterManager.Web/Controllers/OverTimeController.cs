using PersonMatterManager.BLL;
using PersonMatterManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonMatterManager.Web.Controllers
{
    public class OverTimeController : BaseController
    {
        OverTimeBLL overTimeBLL = new OverTimeBLL();
        // GET: OverTime
        #region 页面显示视图
        public ActionResult OverTimeInfo()
        {
            return View();
        }

        public ActionResult OverTimeInto()
        {
            return View();
        }

        public ActionResult OverTimeSee()
        {
            return View();
        }
        #endregion

        public JsonResult GetOvertimeInfo()
        {
            var list = overTimeBLL.GetOvertimeInfo();
            int page = 1, rows = 5;//设置默认页码和行数
            if (!string.IsNullOrEmpty(Request["offset"]))
            {
                page = Convert.ToInt32(Request["offset"]);
            }
            if (!string.IsNullOrEmpty(Request["limit"]))
            {
                rows = Convert.ToInt32(Request["limit"]);
            }
            page = (page / rows) + 1;
            return Json(new { total = list.Count(), rows = list.ToList().Skip((page - 1) * rows).Take(rows) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOverTimeInfoPersonal()
        {
            UserInfo us = Session["UserInfo"] as UserInfo;
            return Json(overTimeBLL.GetOvertimeInfoPersonal(us.UserID));
        }

        public JsonResult GetOverTimeById(int id)
        {
            return Json(overTimeBLL.GetOverTimeById(id));
        }

        public JsonResult AddOverTime(Overtime overtime)
        {
            var userID = (Session["UserInfo"] as UserInfo).UserID;
            overtime.UserID = userID;
            return Json(overTimeBLL.AddOverTime(overtime).ToString());
        }

        public JsonResult GetOverTimeSee()
        {
            return Json(overTimeBLL.GetOverTimeInfo());
        }

        public JsonResult SaveSeeOverTime(int id,int select,string appreason)
        {
            return Json(overTimeBLL.SaveSeeOverTime(id, select, appreason).ToString());
        }
    }
}