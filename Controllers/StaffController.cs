using Microsoft.AspNetCore.Mvc;
using StaffApi.Data;
using StaffRegister.Models;
using StaffRegister.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffRegister.Controllers
{
    
    public class StaffController : Controller
    {
        private readonly IStaffApiClient _staffClient;

        public StaffController(IStaffApiClient staffClient)
        {
            _staffClient = staffClient; //Constructor injection
        }
        public IActionResult GetStaffData()
        {
            //var staffRepository = new StaffRepository();
            //var staffs = staffRepository.GetDetails();

            var staffs = _staffClient.GetAllStaffs();

            return View(staffs);
        }
        public IActionResult GetStaffById( int id)
        {
            //var staffRepository = new StaffRepository();
            //var staffId = staffRepository.ViewDetails(id);

            var staffId = _staffClient.GetStaffByID(id);

            return View(staffId);
        }

        public IActionResult InsertStaff()
        {
            return View();
        }

        [HttpPost]

        public IActionResult InsertStaff(StaffProperty staffs)
        {
            //var staffRepository = new StaffRepository();
            //staffRepository.InsertDetails(staffs);

            _staffClient.InsertStaff(staffs);

            return RedirectToAction("GetStaffData");

        }
        //public IActionResult Updatestaff(int Id)
        //{
        //    var staffRepository = new StaffRepository();

        //    var updateStaff = staffRepository.ViewDetails(Id);

        //    return View(updateStaff);
        //}
        //[HttpPost]

        //public IActionResult Updatestaff(StaffProperty staffs)
        //{
        //    var staffRepository = new StaffRepository();

        //    staffRepository.UpdateDetails(staffs);

        //    return View();
        //}

        //public IActionResult DeleteStaff(int id)
        //{
        //    var staffRepository = new StaffRepository();

        //    var deleteStaff = staffRepository.ViewDetails(id);

        //    return View(deleteStaff);
        //}
        //[HttpPost]

        //public IActionResult DeleteStaff(StaffProperty staffs)
        //{
        //    var staffRepository = new StaffRepository();

        //    staffRepository.DeleteDetails(staffs.Id);

        //    return RedirectToAction("GetStaffData");
        //}
    }
}