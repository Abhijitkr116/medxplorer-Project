using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedXplorer.Models
{
    public class DoctorInsertModel
    {
        public string Doctor_Name { get; set; }
        public string Specialist { get; set; }
        public string State { get; set; }
        public string city { get; set; }
        public string Full_Address { get; set; }
        public string Experience { get; set; }
        public string Working_Place { get; set; }
        public string Start_Time { get; set; }
        public string End_Time { get; set; }
        public string Qualification { get; set; }
        public string Contact_No { get; set; }
        public int? Fees { get; set; }

    }
}