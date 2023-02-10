using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Quizzing_Web.Controllers
{
    public class HomeController : Controller
    {
        string str = ConfigurationManager.ConnectionStrings["QuizConn"].ConnectionString;
        // GET: Home
        public ActionResult Welcome()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con=new SqlConnection(str))
            {
                con.Open();
                string str = "select * from Login";
                SqlDataAdapter da = new SqlDataAdapter(str, con);
                da.Fill(dt);
            }
            return View(dt);
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}