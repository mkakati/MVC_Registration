using System.Collections.Generic;
using System.Web.Mvc;
using MVCAssignment.Models;
using MVCAssignment.App_Data;
using System.Web;
using System.IO;
using System.Linq;
using System;

namespace MVCAssignment.Controllers
{
    public class EmployeeController : Controller
    {
        /// <summary>
        /// Get Country List from database 
        /// </summary>
        /// <returns>List of Country to view</returns>
        [HttpGet]
        public ActionResult Account()
        {
            ViewBag.CountryList = new SelectList(GetCountryList(), "ID", "CountryName");
            return View();
        }

        /// <summary>
        /// Converted the database list to List<> formate to display in view 
        /// </summary>
        /// <returns>list of country to GetCountryList() method</returns>
        public List<EmployeesCountry> GetCountryList()
        {
            sdirecttestdbEntities dbEntities = new sdirecttestdbEntities();
            List<EmployeesCountry> EmployeesCountries = dbEntities.EmployeesCountries.ToList();
            return EmployeesCountries;
        }
        /// <summary>
        /// On the basis of country list getting the State List by the help of linq query and send it to view
        /// </summary>
        /// <param name="CountryId"></param>
        /// <returns>State List to View</returns>
        [HttpGet]
        public JsonResult GetStateList(int CountryId)
        {
            sdirecttestdbEntities dbEntities = new sdirecttestdbEntities();
            //getting the list of state where country table countryId is equal to state table countryId
            List<EmployeesState> StateList = dbEntities.EmployeesStates.Where(x => x.CountryID == CountryId).ToList();
            var stateList = new SelectList(StateList, "ID", "StateName");
            return Json(new { data = stateList }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Get the data filled by the user in Ed object of employeeData Model and created the database object and 
        /// table (EmployeeData) object and store the ED data to edb which is table object. 
        /// </summary>
        /// <param name="ED"></param>
        /// <param name="ProfileImage"></param>
        /// <returns>Employee Data</returns>
        [HttpPost]
        public ActionResult Account(EmployeeData ED, HttpPostedFileBase ProfileImage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int NameID = 1;
                    //created the Database Object 
                    sdirecttestdbEntities dbEntities = new sdirecttestdbEntities();
                    //created the table object 
                    EmployeesDB edb = new EmployeesDB();
                    edb.FullName = ED.FullName;
                    edb.Email = ED.Email;
                    edb.DateOfBirth = ED.DateOfBirth;
                    edb.Address = ED.Address;
                    if (ProfileImage != null && ProfileImage.ContentLength > 0)
                    {
                        //get the path where we want to store our image
                        string path = Path.Combine(Server.MapPath("~/uploads"), Path.GetFileName(ProfileImage.FileName));
                        //move the image to upload folder
                        ProfileImage.SaveAs(path);
                        ViewBag.message = "file uploaded";
                    }
                    edb.ImageActualName = Path.GetFileName(ProfileImage.FileName);
                    string ptr = Convert.ToString(NameID + "1_");
                    edb.ImageName = string.Concat(ptr, ED.ImageName);
                    edb.CountryId = ED.CountryId;
                    edb.StateId = ED.StateId;
                    //store the data into table 
                    dbEntities.EmployeesDBs.Add(edb);
                    //update the table with new data
                    dbEntities.SaveChanges();
                    int ID = edb.UserId;
                    NameID = NameID + 1;
                }
                ViewBag.CountryList = new SelectList(GetCountryList(), "ID", "CountryName");
                ModelState.Clear();
                return View();
            }
            catch (Exception)
            {
                throw new Exception("Filed is not valid");
            }

        }
    }
}