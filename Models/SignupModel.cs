using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedXplorer.Models
{
    public class SignupModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int Isvalid { get; set; } // for Form Based Authentication
        public string Role { get; set; } //for Role Based Authorization
        public string LoginErrorMessage { get; set; }//for displaying invaild details


    }
}