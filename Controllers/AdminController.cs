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
            DoctorInsertModel dropdownModel = new DoctorInsertModel();
            DropdownsManager dropdownManager = new DropdownsManager();
            dropdownModel = dropdownManager.GetState(dropdownModel);
            dropdownModel = dropdownManager.GetSpecialists(dropdownModel);
            ViewResult result = View("Insert", dropdownModel);
            ActionResult ar = result;
            return ar;
        }
        [HttpPost]
        public ActionResult Insert(DoctorInsertModel doctorinsertModel, String Insert)
        {
            DoctorInsertManager insertM = new DoctorInsertManager();
            int count = insertM.InsertData(doctorinsertModel);
            //Add Success view
            if(count > 0)
            {
                return View("Success");
            }
            else
            {
                return View();
            }
        }
        public JsonResult DropdownCity(String statename)
        {
            DropdownsManager dropdownManager = new DropdownsManager();
            DoctorInsertModel CityModel  = dropdownManager.GetCity(statename);
            return Json(CityModel);
        }
    }
}