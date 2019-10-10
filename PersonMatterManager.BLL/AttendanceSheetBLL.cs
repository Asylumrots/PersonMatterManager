using PersonMatterManager.DAL;
using PersonMatterManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonMatterManager.BLL
{
    public class AttendanceSheetBLL
    {
        AttendanceSheetDAL sheetDAL = new AttendanceSheetDAL();
        UserInfoDAL userInfoDAL = new UserInfoDAL();

        public bool CheckSign(int Userid,DateTime day)
        {
            if (sheetDAL.LoadEntities(u => u.UserID == Userid && u.AttendanceStartTime == day).FirstOrDefault() != null)
            {
                return true;
            }
            else{
                return false;
            }
        }

        public bool AddSign(int userid)
        {
            AttendanceSheet newAttendance = new AttendanceSheet();
            newAttendance.AttendanceStartTime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            newAttendance.AttendanceType = 1;//默认
            newAttendance.UserID = userid;
            UserInfo us = userInfoDAL.LoadEntities(u => u.UserID == userid).FirstOrDefault();
            newAttendance.UserName = us.UserName;
            newAttendance.DepartmentID = us.DepartmentID;
            newAttendance.ClockTime = DateTime.Now.ToLocalTime();
            return sheetDAL.AddEntity(newAttendance);
        }

        public IQueryable<AttendanceSheet> GetSignSeeDep(int depid)
        {
            return sheetDAL.LoadEntities(u => u.DepartmentID == depid);
        }

        public IQueryable<AttendanceSheet> GetSignRecordAll()
        {
            return sheetDAL.LoadEntities(u => true);
        }

        public bool AddRemake(DateTime time, string name, string remakes)
        {
            AttendanceSheet attendanceSheet = sheetDAL.LoadEntities(u => u.AttendanceStartTime == time && u.UserName == name).FirstOrDefault();
            attendanceSheet.remake = remakes;
            return sheetDAL.ModifyEntity(attendanceSheet);
        }

        public bool DelAttendance(string[] time, string[] name)
        {
            int n = 0;
            for (int i = 0; i < time.Length; i++)
            {
                var ti = Convert.ToDateTime(time[i]);
                var na = name[i];
                AttendanceSheet us = sheetDAL.LoadEntities(u => u.AttendanceStartTime == ti && u.UserName == na).FirstOrDefault();
                bool del = sheetDAL.DeleteEntity(us);
                if (del == false)
                    n++;
            }
            if (n > 0)
                return false;
            return true;
        }

        public IQueryable<AttendanceSheet> GetPageInfo(int PageIndex, int PageSize, out int total)
        {
            var list = sheetDAL.GetPageInfo(PageIndex, PageSize, out total, u => u.AttendanceID);
            return list;
        }

        public IQueryable<AttendanceSheet> GetCanvasInfo()
        {
            return sheetDAL.GetCanvas();
        }
    }
}
