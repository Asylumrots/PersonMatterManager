using PersonMatterManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonMatterManager.DAL
{
    public class OverTimeDAL:BaseDAL<Overtime>
    {
        public dynamic GetOverTimeUserInfo()
        {
            var s=db.Overtime.Join(db.UserInfo, o => o.UserID, u => u.UserID, (o, u) => new{
                o.OvertimeID,
                o.OvertimeStateTime,
                o.OvertimeEndTime,
                o.OvertimeDuration,
                o.UserID,
                o.ApplyTime,
                o.OvertimeState,
                o.ApproverReason,
                u.UserName,
                u.DepartmentID,
                u.UserTel
            }).Where(u=>u.OvertimeState==0);
            return s;
        }
    }
}
