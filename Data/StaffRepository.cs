using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using StaffRegister.Models;

namespace StaffApi.Data
{
    public class StaffRepository
    {
        private readonly SqlConnection _sqlConnection;

        public StaffRepository()
        {
            var myConnection = "data source= (localdb)\\mssqllocaldb; database= TrainingDatabase;";

            _sqlConnection = new SqlConnection(myConnection);
        }

        public IEnumerable<StaffProperty> GetDetails()
        {
            try
            {
                _sqlConnection.Open();

                var selectCommand = new SqlCommand("select * from EmployeeDetails", _sqlConnection);

                var myOperation = selectCommand.ExecuteReader();

                var staffList = new List<StaffProperty>();

                while (myOperation.Read())
                {
                    staffList.Add(new StaffProperty
                    {
                        Id = (int)myOperation["EmpID"],
                        StaffName = (string)myOperation["EmpName"],
                        StaffAge = (int)myOperation["EmpAge"],
                        StaffDesig = (string)myOperation["EmpDesig"],
                        StaffExp = (int)myOperation["EmpExperience"],
                    });
                }
                return staffList;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public StaffProperty ViewDetails(int id)
        {
            try
            {
                _sqlConnection.Open();

                var myViewCommand = new SqlCommand("select * from EmployeeDetails where EmpID = @id", _sqlConnection);

                myViewCommand.Parameters.AddWithValue("id", id);

                var viewCommand = myViewCommand.ExecuteReader();

                var stafflist = new List<StaffProperty>();

                while (viewCommand.Read())
                {
                    stafflist.Add(new StaffProperty
                    {
                        Id = (int)viewCommand["EmpID"],
                        StaffName = (string)viewCommand["EmpName"],
                        StaffAge = (int)viewCommand["EmpAge"],
                        StaffDesig = (string)viewCommand["EmpDesig"],
                        StaffExp = (int)viewCommand["EmpExperience"],
                    });
                }

                return stafflist.FirstOrDefault();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public bool InsertDetails(StaffProperty staffs)
        {
            try
            {
                _sqlConnection.Open();

                var myCommand = new SqlCommand("insert into EmployeeDetails values (@name, @age, @designation,@experience); ", _sqlConnection);

                myCommand.Parameters.AddWithValue("name", staffs.StaffName);
                myCommand.Parameters.AddWithValue("age", staffs.StaffAge);
                myCommand.Parameters.AddWithValue("designation", staffs.StaffDesig);
                myCommand.Parameters.AddWithValue("experience", staffs.StaffExp);

                var insertCommand = myCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }

        }

        public bool UpdateDetails(StaffProperty staffs)
        {
            try
            {
                _sqlConnection.Open();

                var updateConnect = new SqlCommand("update EmployeeDetails set EmpName=@name,EmpAge=@age,EmpDesig=@designation,EmpExperience=@experience  where EmpID=@id", _sqlConnection);

                updateConnect.Parameters.AddWithValue("name", staffs.StaffName);
                updateConnect.Parameters.AddWithValue("age", staffs.StaffAge);
                updateConnect.Parameters.AddWithValue("designation", staffs.StaffDesig);
                updateConnect.Parameters.AddWithValue("experience", staffs.StaffExp);
                updateConnect.Parameters.AddWithValue("id", staffs.Id);

                updateConnect.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public bool DeleteDetails(int id)
        {
            try
            {
                _sqlConnection.Open();

                var deleteDetails = new SqlCommand("delete from EmployeeDetails where EmpID=@id", _sqlConnection);

                deleteDetails.Parameters.AddWithValue("id", id);

                deleteDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
    }
}
