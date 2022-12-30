using StaffRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffRegister.Provider
{
    public interface IStaffApiClient
    {
        IEnumerable<StaffProperty> GetAllStaffs();

        StaffProperty GetStaffByID(int id);

        bool InsertStaff(StaffProperty staffs);
    }
}
