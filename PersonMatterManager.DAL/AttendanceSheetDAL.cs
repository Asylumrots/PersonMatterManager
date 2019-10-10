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
        HRCEntities db = new HRCEntities();
        public IQueryable<AttendanceSheet> GetCanvas()
        {
            return db.AttendanceSheet.Where(u => true).OrderByDescending(u => u.AttendanceStartTime).Take(8);
        }
    }
}
