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
                        OverTimeName = GetNameById(item.OvertimeID),
                        OvertimeID = item.OvertimeID,
                        OvertimeDuration=item.OvertimeDuration,
                        OvertimeEndTime=item.OvertimeEndTime,
                        OvertimeState=item.OvertimeState,
                        OvertimeStateTime=item.OvertimeStateTime,
                    }
                );
            }
            return returnlist; 
        }

        public string GetNameById(int id)
        {
            return UserInfoDAL.LoadEntities(u => u.UserID == id).FirstOrDefault().UserName;
        }
    }
}
