using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin_Page.Environment
{
    public class ApiUrl
    {
        //public const string baseUrl = "https://eawwebapi-dev-as.azurewebsites.net/api/v1/";
        public const string baseUrl = "http://23.97.57.51:7890/";

        //Store Setting
        public const string GetListStores = baseUrl + "Stores/";
        public const string GetStores = baseUrl + "Stores/AllStores/";
        public const string AuthorizeCodeUrl = baseUrl + "Stores/Generate/";
        
    }
}