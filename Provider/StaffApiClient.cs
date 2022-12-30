using Newtonsoft.Json;
using StaffRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StaffRegister.Provider
{
    public class StaffApiClient : IStaffApiClient
    {
        private readonly HttpClient _httpClient;

        public StaffApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IEnumerable<StaffProperty> GetAllStaffs()
        {
            var response = _httpClient.GetAsync("https://localhost:5001/get-staffs").Result;

            var staffresponse = response.Content.ReadAsStringAsync().Result;

            var staffs = JsonConvert.DeserializeObject<IEnumerable<StaffProperty>>(staffresponse);

            return staffs;
        }

        public StaffProperty GetStaffByID(int id)
        {
            var response = _httpClient.GetAsync($"https://localhost:5001/get-staffs/{id}").Result;

            var staffresponse = response.Content.ReadAsStringAsync().Result;

            var staffs = JsonConvert.DeserializeObject<StaffProperty>(staffresponse);

            return staffs;
        }
        public bool InsertStaff(StaffProperty staffs)
        {
            var url = "https://localhost:5001/get-staffs";
            var content = new StringContent(JsonConvert.SerializeObject(staffs), Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync(url, content).Result;
            return true;



        }
    }
}
