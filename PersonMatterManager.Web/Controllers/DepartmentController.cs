using PersonMatterManager.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonMatterManager.Web.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

        DepartmentBLL departmentBLL = new DepartmentBLL();

        public JsonResult GetDepartmentInfo()
        {
            return Json(departmentBLL.GetDepartmentInfo());
        }

        public ActionResult AddDepartment(string Name)
        {
            string add = departmentBLL.AddDepartment(Name);
            return Content(add);
        }

        public ActionResult DelDepartment(int[] id)
        {
            string del = departmentBLL.DelDepartment(id);
            return Content(del);
        }
    }
}