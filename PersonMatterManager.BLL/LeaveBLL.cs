using PersonMatterManager.DAL;
using PersonMatterManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonMatterManager.BLL
{
    public class LeaveBLL
    {
        LeaveDAL leaveDAL = new LeaveDAL();

        public IQueryable<Leave> GetLeaveInfo()
        {
            return leaveDAL.LoadEntities(u => true);
        }

        public IQueryable<Leave> GetLeaveUser(int userid)
        {
            return leaveDAL.LoadEntities(u => u.UserID == userid);
        }

        public IQueryable<Leave> GetLeaveSee()
        {
            return leaveDAL.LoadEntities(u => u.LeaveState == 0);
        }
        
        public IQueryable<Leave> GetLeaveSeeById(int id)
        {
            return leaveDAL.LoadEntities(u => u.LeaveID == id);
        }

        public bool AddLeave(Leave leave)
        {
            return leaveDAL.AddEntity(leave);
        }

        public bool DelLeave(string[] stime, string[] etime)
        {
            int n = 0;
            for (int i = 0; i < stime.Length; i++)
            {
                var num = Convert.ToDateTime(stime[i]);
                var na = Convert.ToDateTime(etime[i]);
                Leave us = leaveDAL.LoadEntities(u => u.LeaveStartTime == num && u.LeaveEndTime == na).FirstOrDefault();
                bool del = leaveDAL.DeleteEntity(us);
                if (del == false)
                    n++;
            }
            if (n > 0)
                return false;
            return true;
        }

        public IQueryable<Leave> SeeLeaveInfo(DateTime stime, DateTime etime)
        {
            return leaveDAL.LoadEntities(u => u.LeaveStartTime == stime && u.LeaveEndTime == etime);
        }

        public bool SaveSeeLeave(string appreason, int select,DateTime stime,DateTime etime)
        {
            Leave leave = leaveDAL.LoadEntities(u => u.LeaveStartTime == stime && u.LeaveEndTime == etime).FirstOrDefault();
            leave.ApprovalTime = DateTime.Now;
            leave.ApproverReason = appreason;
            leave.ApproverID = 0;//暂定0
            leave.LeaveState = select;
            return leaveDAL.ModifyEntity(leave);
        }
    }
}
