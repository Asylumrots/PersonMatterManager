using PersonMatterManager.BLL;
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
        public ActionResult OverTimeInfo()
        {
            return View();
        }

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
    }
}