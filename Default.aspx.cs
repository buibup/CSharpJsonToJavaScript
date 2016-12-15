using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using JSONObject.Models;
using System.Net;
using Newtonsoft.Json;

namespace JSONObject
{
    public partial class Default : System.Web.UI.Page
    {
        private static string url = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //GetCustomers();
            GetPatient();
        }
        [WebMethod]
        public static List<Patient> GetPatient()
        {
            url = "http://10.104.10.44/PatientJsonApi/api/Patient/1213048085/jsonp?callback=?";
            var client = new WebClient { Encoding = System.Text.Encoding.UTF8 };
            var json = client.DownloadString(url);

            List<Patient> result = JsonConvert.DeserializeObject<List<Patient>>(json);

            return result;
        }
        [WebMethod]
        public static List<Todo> GetTodos()
        {
            url = "http://localhost:30214/api/todo";
            var client = new WebClient { Encoding = System.Text.Encoding.UTF8 };
            var json = client.DownloadString(url);

            List<Todo> result = JsonConvert.DeserializeObject<List<Todo>>(json);

            return result;
        }

        [WebMethod]
        public static List<Customer> GetCustomers()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT TOP 10 * FROM Customers"))
                {
                    cmd.Connection = con;
                    List<Customer> customers = new List<Customer>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(new Customer
                            {
                                CustomerId = sdr["CustomerId"].ToString(),
                                ContactName = sdr["ContactName"].ToString(),
                                City = sdr["City"].ToString(),
                                Country = sdr["Country"].ToString(),
                                PostalCode = sdr["PostalCode"].ToString(),
                                Phone = sdr["Phone"].ToString(),
                                Fax = sdr["Fax"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return customers;
                }
            }
        }
    }
}