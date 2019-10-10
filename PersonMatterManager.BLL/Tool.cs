using PersonMatterManager.DAL;
using PersonMatterManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonMatterManager.BLL
{
    public class Tool
    {
        public static string GetSexbySexId(int n)
        {
            if (n == 1)
                return "男";
            else
                return "女";
        }

        public static int GetSexIdbySex(string n)
        {
            if (n == "男")
                return 1;
            else
                return 0;
        }

        public static string GetDeaprtmentById(int n)
        {
            DepartmentBLL bLL = new DepartmentBLL();
            return bLL.GetDepartmentName(n).DepartmentName;
        }

        public static int GetDeaprtmentByName(string name)
        {
            DepartmentBLL bLL = new DepartmentBLL();
            return bLL.GetDepartmentId(name).DepartmentID;
        }
    }
}
