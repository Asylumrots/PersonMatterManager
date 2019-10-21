using PersonMatterManager.DAL;
using PersonMatterManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonMatterManager.BLL
{
    public class OverTimeBLL
    {
        OverTimeDAL overTimeDAL = new OverTimeDAL();
        UserInfoDAL UserInfoDAL = new UserInfoDAL();
        public List<OverTimeViewModel> GetOvertimeInfo()
        {
            var list= overTimeDAL.LoadEntities(u => true);
            var returnlist = new List<OverTimeViewModel>();
            foreach (var item in list)
            {
                returnlist.Add(
                    new OverTimeViewModel
                    {
                        OverTimeName = GetNameById(Convert.ToInt32(item.UserID)),
                        OvertimeID = item.OvertimeID,
                        OvertimeDuration=item.OvertimeDuration,
                        OvertimeEndTime=item.OvertimeEndTime,
                        OvertimeState=item.OvertimeState,
                        OvertimeStateTime=item.OvertimeStateTime,
                        ApplyTime=item.ApplyTime,
                        ApproverReason=item.ApproverReason,
                    }
                );
            }
            return returnlist; 
        }

        public string GetNameById(int id)
        {
            return UserInfoDAL.LoadEntities(u => u.UserID == id).FirstOrDefault().UserName;
        }

        public IQueryable<Overtime> GetOvertimeInfoPersonal(int userID)
        {
            return overTimeDAL.LoadEntities(u => u.UserID == userID);
        }

        public Overtime GetOverTimeById(int id)
        {
            return overTimeDAL.LoadEntities(u => u.OvertimeID == id).FirstOrDefault();
        }

        public bool AddOverTime(Overtime overtime)
        {
            overtime.OvertimeState = 0;
            overtime.OvertimeDuration = 0;
            return overTimeDAL.AddEntity(overtime);
        }

        public dynamic GetOverTimeInfo()
        {
            return overTimeDAL.GetOverTimeUserInfo();
        }

        public bool SaveSeeOverTime(int id,int select,string appreason)
        {
            var overTime = overTimeDAL.LoadEntities(u => u.OvertimeID==id).FirstOrDefault();
            overTime.OvertimeState = select;
            overTime.ApproverReason = appreason;
            return overTimeDAL.ModifyEntity(overTime);
        }
    }
}
