using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin_Page.Models
{
    public class AuthorizeCodeViewModel
    {
        public int codeId { get; set; }
        public string code { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime expiredDate { get; set; }
    }

    public class StoreViewModel
    {
        public StoreViewModel()
        {

        }
        public StoreViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public int StoreCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public Nullable<bool> isAvailable { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string AuthorizeCode { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public int Type { get; set; }
        public Nullable<int> RoomRentMode { get; set; }
        public Nullable<System.DateTime> ReportDate { get; set; }
        public string ShortName { get; set; }
        public bool IsUsed { get; set; }
    }

    public class PageSizeModel
    {
        public PageSizeModel(int size)
        {
            this.size = size;
           
        }
        public PageSizeModel()
        {

        }
        List<SelectListItem> PageSize { get; set; }
        public int size { get; set; }
    }
}