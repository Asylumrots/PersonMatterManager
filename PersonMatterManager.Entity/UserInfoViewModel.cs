using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonMatterManager.Entity
{
    public class UserInfoViewModel
    {
        public int UserID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<int> RoleID { get; set; }
        public string UserNumber { get; set; }
        public string LoginName { get; set; }
        public string LoginPwd { get; set; }
        public string UserName { get; set; }
        public Nullable<int> UserAge { get; set; }
        public Nullable<int> UserSex { get; set; }
        public string UserTel { get; set; }
        public string UserAddress { get; set; }
        public string UserIphone { get; set; }
        public string UserRemarks { get; set; }
        public Nullable<int> UserStatr { get; set; }
        public Nullable<System.DateTime> EntryTime { get; set; }
        public Nullable<System.DateTime> DimissionTime { get; set; }
        public Nullable<decimal> BasePay { get; set; }
    }
}
