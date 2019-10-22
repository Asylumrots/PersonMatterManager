using PersonMatterManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonMatterManager.DAL
{
    public class AttendanceSheetDAL:BaseDAL<AttendanceSheet>
    {
        public IQueryable<dynamic> GetCanvas()
        {
            var list = db.AttendanceSheet.GroupBy(u => new { u.AttendanceStartTime})
                .Select(x=> new { AttendanceStartTime=x.Key.AttendanceStartTime,AttendanceType=x.Count()}).AsQueryable().OrderByDescending(x=>x.AttendanceStartTime).Take(8);
            return list;
        }
    }
}
