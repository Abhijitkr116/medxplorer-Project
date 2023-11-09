using MedXplorer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedXplorer.Controllers
{
    public class AdminController : Controller
    {
        // GET: Insert
        [HttpGet]
        public ActionResult Insert()
        {
            DoctorInsertModel doctorinsertModel = new DoctorInsertModel();
            ViewResult result = View("Insert", doctorinsertModel);
            ActionResult ar = result;
            return ar;
        }
        [HttpPost]
        public ActionResult Insert(DoctorInsertModel doctorinsertModel, String Insert)
        {
            DoctorInsertManager insertM = new DoctorInsertManager();
            int count = insertM.InsertData(doctorinsertModel);
            //int Total = insertM.Total_No_Of_User(insertModel);

            return View();



        }
    }
}