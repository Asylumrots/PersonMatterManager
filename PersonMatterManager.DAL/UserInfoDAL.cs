using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonMatterManager.Entity;

namespace PersonMatterManager.DAL
{
    public class UserInfoDAL:BaseDAL<UserInfo>
    {
        public UserInfo checkLogin(string name, string pwd)
        {
            var userinfo = LoadEntities(u => u.LoginName == name && u.LoginPwd == pwd);
            return userinfo.FirstOrDefault();
        }
        
    }
}
