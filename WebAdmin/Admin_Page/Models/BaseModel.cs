using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin_Page.Models
{
    public class BaseModel<T>
    {
        public bool Success { get; set; }
     
        public int Status { get; set; }
       
        public string Message { get; set; }
     
        public T Data { get; set; }
    }
}