using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonMatterManager.DAL;
using PersonMatterManager.Entity;

namespace PersonMatterManager.BLL
{
    public class RoleBLL
    {
        RoleDAL roleDAL = new RoleDAL();
        public IQueryable<Role> GetRole()
        {
            return roleDAL.LoadEntities(u => true);
        }
    }
}
