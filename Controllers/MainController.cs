using MedXplorer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MedXplorer.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        //Check the Medicines availability
        public ActionResult Medicines()
        {
            ViewBag.Message = "Medicines page under development phase";

            return View();
        }

        //Hospitals and Clinics
        public ActionResult Hospitals_clinics()
        {
            ViewBag.Message = "Hospitals & Clinics page under development phase";

            return View();
        }

        //Book an appointment
        public ActionResult Appointment()
        {
            ViewBag.Message = "Book an apppointment page under development phase";

            return View();
        }

        //Services
        public ActionResult Service()
        {
            ViewBag.Message = "Service page under development phase";

            return View();
        }

        //Register or Signup
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(SignupModel signupmodel1)
        {
            SignupManager signupmanager1 = new SignupManager();
            int count = signupmanager1.InsertStudentData(signupmodel1);
            if (count > 0)
            {
                return View("_Registeredsuccess");
            }
            else
            {
                return View("RegisteredFail");
            }
        }


        //Login Page
        public ActionResult Login()
        {
            SignupModel model = new SignupModel();
            return View("Login", model);
        }
        [HttpPost] //use to take data from server and sends it to database
        public ActionResult Login(SignupModel model, string btn)
        {
            LoginManager loginModelManager = new LoginManager();
            loginModelManager.UserAuth(model);//return View("Succesful");
            if (model.Isvalid == 1)//user is valid
            {
                Session["userEmail"] = model.email;//user email in server                FormsAuthentication.SetAuthCookie(model.Name, false);//create cookie for store name
                var authTicket = new FormsAuthenticationTicket(1, model.email, DateTime.Now, DateTime.Now.AddMinutes(20), false, model.Role);//pick datetime when user log in and give 20 min session in server
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);//encrypt user data for security reasons
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);//store encrypted data in authCookie
                HttpContext.Response.Cookies.Add(authCookie);//add aurhCookie to httpcontext
                return RedirectToAction("Index", "Main", model); //reurn to home controller fo give authorization
            }
            else
            {
                model.LoginErrorMessage = "Invalid Email or Password";//if user enter invalid details then display error message
                return View("Login", model); //return to same login page
            }
        }



        //Doctor Result set
        [HttpGet]
        public ActionResult Search()
        {
            DoctorInsertModel doctorinsertModel = new DoctorInsertModel();
            DropdownsManager dropdownManager = new DropdownsManager();
            doctorinsertModel = dropdownManager.GetState(doctorinsertModel);
            doctorinsertModel = dropdownManager.GetSpecialists(doctorinsertModel);
            doctorinsertModel = dropdownManager.GetDoctorsName(doctorinsertModel);
            ViewResult vr = View("Find_doctor", doctorinsertModel);
            ActionResult ar = vr;
            return ar;
        }
        [HttpPost]
        public ActionResult Search(DoctorInsertModel doctorinsertModel, string Search)
        {
            DoctorSearchManager Im = new DoctorSearchManager();
            DropdownsManager dropdown = new DropdownsManager();
            doctorinsertModel = dropdown.GetSpecialists(doctorinsertModel);  //Doctor Insert Model
            doctorinsertModel = dropdown.GetDoctorsName(doctorinsertModel);  //Doctor Insert Model
            doctorinsertModel = dropdown.GetState(doctorinsertModel);        //Doctor Insert Model
            
            doctorinsertModel.selectListItems = Im.Search_Data(doctorinsertModel);       //Doctor Insert Model but different manager
            return View("DoctorResult", doctorinsertModel);
        }
    }
}