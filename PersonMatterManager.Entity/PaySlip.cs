//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonMatterManager.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class PaySlip
    {
        public int PaySlipID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<decimal> Prize { get; set; }
        public Nullable<decimal> LeaveMoney { get; set; }
        public Nullable<decimal> OvertimeMoney { get; set; }
        public Nullable<decimal> LateMoney { get; set; }
        public Nullable<decimal> AdvanceMoney { get; set; }
        public Nullable<decimal> Absence { get; set; }
        public Nullable<decimal> fine { get; set; }
        public Nullable<decimal> Sa_Bonus { get; set; }
        public Nullable<System.DateTime> Sa_Time { get; set; }
        public Nullable<decimal> Sa_TotalSalary { get; set; }
    }
}
