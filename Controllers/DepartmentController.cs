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
    public class DepartmentController : ApiController
    {
       public HttpResponseMessage Get()
         {
 
            DataTable table = new DataTable();

            string query = @"select DepartmentID,DepartmentName from dbo.Departments";

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString); //sql e bağlanıyoruz
            var command = new SqlCommand(query, con); //çalıştırıyoruz command ile sorgu-bağlantı sqlCommand ile veriliyor

            using (var da=new SqlDataAdapter(command)){
            command.CommandType = CommandType.Text;
            da.Fill(table); //sorguyla dolduruyoruz(query)

             }

            return Request.CreateResponse(HttpStatusCode.OK, table); //api dan çağırildiğinda bu tablo gidecek durumda

         }

        public string Post(Department dep)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"insert into dbo.Departments values('" + dep.DepartmentName + @"')";

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

        public string Put(Department dep)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"update dbo.Departments set DepartmentName='"+dep.DepartmentName+
                    @"' where DepartmentID="+dep.DepartmentID+@"
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

                string query = @"delete from dbo.Departments where DepartmentID= " + id;

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
