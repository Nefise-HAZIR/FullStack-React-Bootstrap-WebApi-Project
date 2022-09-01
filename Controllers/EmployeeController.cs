using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {

            DataTable table = new DataTable();

            string query = @"select EmployeeID,EmployeeName,Department,MailID,CONVERT(varchar(10),DOJ,120) from dbo.Employees";

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString); //sql e bağlanıyoruz
            var command = new SqlCommand(query, con); //çalıştırıyoruz command ile sorgu-bağlantı sqlCommand ile veriliyor

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(table); //sorguyla dolduruyoruz(query)

            }

            return Request.CreateResponse(HttpStatusCode.OK, table); //api dan çağırildiğinda bu tablo gidecek durumda

        }

        public string Post(Employees emp)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"insert into dbo.Employees (EmployeeName,Department,MailID,DOJ) values(
                 '" + emp.EmployeeName + @"',
                 '" + emp.Department + @"',
                 '" + emp.MailID + @"',
                 '" + emp.DOJ + @"'
                )";

                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString); //sql e bağlanıyoruz
                var command = new SqlCommand(query, con); //çalıştırıyoruz command ile sorgu-bağlantı sqlCommand ile veriliyor

                using (var da = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(table); //sorguyla dolduruyoruz(query)

                }
                return "added succesfully";
            }
            catch (Exception)
            {

                return "failed...";
            }

        }

        public string Put(Employees emp)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"update dbo.Employees set
                    EmployeeName='" + emp.EmployeeName + @"',
                    Department='" + emp.Department + @"',
                    MailID='" + emp.MailID + @"',
                    DOJ='" + emp.DOJ + @"'
                      where EmployeeID=" + emp.EmployeeID + @"
                    ";

                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString); //sql e bağlanıyoruz
                var command = new SqlCommand(query, con); //çalıştırıyoruz command ile sorgu-bağlantı sqlCommand ile veriliyor

                using (var da = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(table); //sorguyla dolduruyoruz(query)

                }
                return "Updated succesfully";
            }
            catch (Exception)
            {

                return "failed...";
            }

        }
        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"delete from dbo.Employees where EmployeeID= "+id;

                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString); //sql e bağlanıyoruz
                var command = new SqlCommand(query, con); //çalıştırıyoruz command ile sorgu-bağlantı sqlCommand ile veriliyor

                using (var da = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(table); //sorguyla dolduruyoruz(query)

                }
                return "deleted succesfully";
            }
            catch (Exception)
            {

                return "failed...";
            }

        }
    }
}
