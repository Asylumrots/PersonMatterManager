using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonMatterManager.Entity
{
    public class OverTimeViewModel
    {
        public int OvertimeID { get; set; }
        public Nullable<System.DateTime> OvertimeStateTime { get; set; }
        public Nullable<System.DateTime> OvertimeEndTime { get; set; }
        public Nullable<int> OvertimeDuration { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> ApplyTime { get; set; }
        public Nullable<int> OvertimeState { get; set; }
        public string ApproverReason { get; set; }
        public string OverTimeName { get; set; }
    }
}
