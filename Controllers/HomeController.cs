using sampledbconnectivity.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sampledbconnectivity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //ViewBag.Message = "Your application description page.";
            //return View();
            List<Emplyee> employeeList = new List<Emplyee>();
            string CS = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Employee", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var employee = new Emplyee();

                    employee.EmployeeId = Convert.ToInt32(rdr["EmpId"]);
                    employee.Name = rdr["Name"].ToString();
                    employeeList.Add(employee);
                }
            }
            return View(employeeList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}