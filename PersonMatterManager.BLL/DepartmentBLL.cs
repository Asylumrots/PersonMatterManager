using PersonMatterManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonMatterManager.Entity;

namespace PersonMatterManager.BLL
{
    
    public class DepartmentBLL
    {
        DepartmentDAL departmentDAL = new DepartmentDAL();

        public IQueryable<Department> GetDepartmentInfo()
        {
            return departmentDAL.LoadEntities(u => true);
        }

        public Department GetDepartmentName(int n)
        {
            return departmentDAL.LoadEntities(u => u.DepartmentID == n).FirstOrDefault();
        }

        public Department GetDepartmentId(string name)
        {
            return departmentDAL.LoadEntities(u => u.DepartmentName == name).FirstOrDefault();
        }

        public string AddDepartment(string Name)
        {
            if (departmentDAL.LoadEntities(u=>u.DepartmentName==Name).FirstOrDefault()!=null)
            {
                return "ContainName";
            }
            Department department = new Department();
            department.DepartmentName = Name;
            department.DepartmentID = departmentDAL.LoadEntities(u => true).Max(u => u.DepartmentID)+1;
            department.People = 0;
            bool add = departmentDAL.AddEntity(department);
            if (add == false)
                return "False";
            return "True";
        }

        public string DelDepartment(int[] id)
        {
            int n = 0;
            foreach (var item in id)
            {
                Department department = departmentDAL.LoadEntities(u => u.DepartmentID == item).FirstOrDefault();
                bool del=departmentDAL.DeleteEntity(department);
                if (del == false)
                    n++;
            }
            if (n > 0)
                return "False";
            return "True";
        }
    }
}
