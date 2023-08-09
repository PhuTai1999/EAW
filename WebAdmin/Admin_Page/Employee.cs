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
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.CheckFaces = new HashSet<CheckFace>();
            this.EmployeeFaces = new HashSet<EmployeeFace>();
            this.EmployeeInStores = new HashSet<EmployeeInStore>();
            this.EmployeeRoleLists = new HashSet<EmployeeRoleList>();
            this.TokenUsers = new HashSet<TokenUser>();
            this.WorkingShifts = new HashSet<WorkingShift>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Role { get; set; }
        public string EmpEnrollNumber { get; set; }
        public int MainStoreId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
        public int BrandId { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> DateStartWork { get; set; }
        public Nullable<int> EmployeeGroupId { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeRegency { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<int> EmployeeSex { get; set; }
        public string PersonalCardId { get; set; }
        public Nullable<System.DateTime> DatePersonalCard { get; set; }
        public string PlaceOfPersonalCard { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string MainAddress { get; set; }
        public string EmployeeHometown { get; set; }
        public string EmployeePlaceBorn { get; set; }
        public Nullable<System.DateTime> DateQuitWork { get; set; }
        public string ReasonQuit { get; set; }
        public string PersonalIncomTax { get; set; }
        public Nullable<int> MaritalStatus { get; set; }
        public string SocialInsuranceNumber { get; set; }
        public string BankNumber { get; set; }
        public Nullable<int> Bank { get; set; }
        public Nullable<int> EducationType { get; set; }
        public string EducationStatus { get; set; }
        public Nullable<int> EducationQualify { get; set; }
        public string Specialized { get; set; }
        public string SchoolName { get; set; }
        public string CourseYear { get; set; }
        public Nullable<int> FormOfTraining { get; set; }
        public string ContactOne { get; set; }
        public string ContactTwo { get; set; }
        public string Image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CheckFace> CheckFaces { get; set; }
        public virtual EmployeeGroup EmployeeGroup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeFace> EmployeeFaces { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeInStore> EmployeeInStores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeRoleList> EmployeeRoleLists { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TokenUser> TokenUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkingShift> WorkingShifts { get; set; }
    }
}