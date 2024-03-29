//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Admin_Page
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkingShift
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkingShift()
        {
            this.CheckFaces = new HashSet<CheckFace>();
        }
    
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public bool Active { get; set; }
        public Nullable<System.DateTime> CheckMin { get; set; }
        public Nullable<System.DateTime> CheckMax { get; set; }
        public Nullable<System.TimeSpan> TotalWorkTime { get; set; }
        public Nullable<bool> Status { get; set; }
        public System.DateTime ShiftStart { get; set; }
        public System.DateTime ShiftEnd { get; set; }
        public Nullable<System.TimeSpan> CheckInTime { get; set; }
        public string UpdatePerson { get; set; }
        public Nullable<int> ProcessingStatus { get; set; }
        public string Note { get; set; }
        public int StoreId { get; set; }
        public int TimeFramId { get; set; }
        public Nullable<System.TimeSpan> BreakTime { get; set; }
        public Nullable<System.DateTime> RequestedCheckOut { get; set; }
        public Nullable<System.DateTime> RequestedCheckIn { get; set; }
        public Nullable<int> IsRequested { get; set; }
        public string ApprovePerson { get; set; }
        public string NoteRequest { get; set; }
        public Nullable<System.DateTime> LastCheckBeforeShift { get; set; }
        public Nullable<System.DateTime> FirstCheckAfterShift { get; set; }
        public Nullable<bool> IsOverTime { get; set; }
        public Nullable<int> InMode { get; set; }
        public Nullable<int> OutMode { get; set; }
        public Nullable<int> BreakCount { get; set; }
        public Nullable<System.TimeSpan> CheckInExpandTime { get; set; }
        public Nullable<System.TimeSpan> CheckOutExpandTime { get; set; }
        public Nullable<System.TimeSpan> ComeLateExpandTime { get; set; }
        public Nullable<System.TimeSpan> LeaveEarlyExpandTime { get; set; }
        public Nullable<int> ModeAttendance { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Store Store { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CheckFace> CheckFaces { get; set; }
    }
}
