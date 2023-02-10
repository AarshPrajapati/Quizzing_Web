using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quizzing_Model.Model;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;


namespace Quizzing_Web.Controllers
{

    public class LoginController : Controller
    {
        string str = ConfigurationManager.ConnectionStrings["QuizConn"].ConnectionString;
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login Aa)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                //string login = "select username,password from Login where username=@p1 and password=@p2";
                con.Open();
                SqlCommand cmd = new SqlCommand("qz_login", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@username", Aa.username));
                cmd.Parameters.Add(new SqlParameter("@password", Aa.password));
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    FormsAuthentication.SetAuthCookie(Aa.username, false);
                    return RedirectToAction("Welcome", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username and Password");
                }
                return View();
            }
           
        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Login Aarsh)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                //string signup="Insert into Login values(@p1,@p2)";
                SqlCommand cmd = new SqlCommand("qz_insert", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@F_name", Aarsh.F_name));
                cmd.Parameters.Add(new SqlParameter("@L_name", Aarsh.L_name));
                cmd.Parameters.Add(new SqlParameter("@username", Aarsh.username));
                cmd.Parameters.Add(new SqlParameter("@E_mail", Aarsh.E_mail));
                cmd.Parameters.Add(new SqlParameter("@password", Aarsh.password));
                cmd.ExecuteNonQuery();
               // FormsAuthentication.SetAuthCookie(Aarsh.username, false);
            }
            return RedirectToAction("Welcome","Home");
        }

        public ActionResult Logout()
        {
           // FormsAuthentication.SignOut();
            return RedirectToAction("Login","Login");
        }
    }
}