using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MedXplorer.Models
{
    public class DoctorInsertModel
    {
        public string Doctor_Name { get; set; }
        public string Specialist { get; set; }
        public string State { get; set; } //Insert your Restaurant State
        public string City { get; set; } //Insert your Restaurant City
        public string Full_Address { get; set; }
        public string Experience { get; set; }
        public string Working_Place { get; set; }
        public string Start_Time { get; set; }
        public string End_Time { get; set; }
        public string Qualification { get; set; }
        public string Contact_No { get; set; }
        public int? Fees { get; set; }
        
        public List<DoctorInsertModel> selectListItems = new List<DoctorInsertModel>();

        public List<string> ListofDoctors = new List<string>(); //Bind the list of Doctors into dropdown

        public List<string> ListofSpecialist = new List<string>(); //Bind the list of specialist into dropdown

        public List<string> ListofState = new List<string>(); //Bind the list of state into dropdown

        public List<string> ListofCity = new List<string>();  //Bind the list of city into dropdown


    }
}