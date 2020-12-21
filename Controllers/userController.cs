using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Data.SqlClient;
using System.Data;


namespace WebApplication2.Controllers
{
    public class userController : Controller
    {
        // GET: user
        public ActionResult Index()
        {
           bool success = bypass();
            if (success)
                return View();
            else
                return RedirectToAction("login");
        }

        // GET: user/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: user/Create
        public ActionResult Create()
        {
            Users newUser = new Users();
            List<SelectListItem> objDepts = new List<SelectListItem>();
            
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=MVCDb;Integrated Security=True;Pooling=False";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Cities";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                
                objDepts.Add(new SelectListItem { Text = dr.GetString(1), Value = dr.GetInt32(0).ToString() });
            }
            dr.Close();
            cn.Close();
            newUser.cityList = objDepts;
            
            return View(newUser);
        }

        // POST: user/Create
        [HttpPost]
        public ActionResult Create(Users newUser)
        {
            try
            {
                //Console.WriteLine(newUser.CityId);
                // TODO: Add insert logic here
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=MVCDb;Integrated Security=True;Pooling=False";
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into Users(UserName,Email,Password,FullName,CityId,Phone) values(@UserName,@Email,@Password,@FullName,@CityId,@Phone)";
                //cmd.CommandText = "insert into Users() values('"+ newUser.UserName+"','"+ newUser.Email + "','" + newUser.Password + "','',1,'025755188')";

                cmd.Parameters.AddWithValue("@UserName", newUser.UserName);
                cmd.Parameters.AddWithValue("@Email", newUser.Email);
                cmd.Parameters.AddWithValue("@Password", newUser.Password);
                cmd.Parameters.AddWithValue("@FullName", newUser.FullName);
                cmd.Parameters.AddWithValue("@CityId", newUser.CityId);
                cmd.Parameters.AddWithValue("@Phone", newUser.Phone);

                
                cmd.ExecuteNonQuery();
                cn.Close();
                return RedirectToAction("login");
            }
            catch(Exception e)

            {

                return View();
            }
        }

        // GET: user/Edit/5
        public ActionResult updation(int id=0)
        {
            bool success = bypass();
            if (!success)

                return RedirectToAction("login");
            else {
                Users u = (Users)Session["logged_user"];
                List<SelectListItem> objDepts = new List<SelectListItem>();

                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=MVCDb;Integrated Security=True;Pooling=False";
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Cities";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SelectListItem item = new SelectListItem();
                    item.Text = dr.GetString(1);
                    item.Value = dr.GetInt32(0).ToString();


                    if (dr.GetInt32(0) == u.CityId)
                    {
                        item.Selected = true;
                    }
                    objDepts.Add(item);
                }
                dr.Close();
                cn.Close();
                u.cityList = objDepts;

                return View(u);
            }
        }

        // POST: user/Edit/5
        [HttpPost]
        public ActionResult updation(Users newUser)
        {
            try
            {
                // TODO: Add update logic here
                Session.Remove("logged_user");
                Session.Add("logged_user",newUser);
                Session.Add("logged_username", newUser.UserName);
                Session.Add("logged_Email", newUser.Email);
                Session.Add("logged_Password", newUser.Password);
                Session.Add("logged_phone", newUser.Phone);
                Session.Add("logged_FullName", newUser.FullName);
                Session.Add("logged_CityId", newUser.CityId);
                SqlConnection cn = new SqlConnection();
                    cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=MVCDb;Integrated Security=True;Pooling=False";
                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "update Users set Email = @Email, Password = @Password ,FullName = @FullName,CityId = @CityId,Phone =@Phone where Username = @UserName ";  //cmd.CommandText = "insert into Users() values('"+ newUser.UserName+"','"+ newUser.Email + "','" + newUser.Password + "','',1,'025755188')";

                    cmd.Parameters.AddWithValue("@UserName", newUser.UserName);
                    cmd.Parameters.AddWithValue("@Email", newUser.Email);
                    cmd.Parameters.AddWithValue("@Password", newUser.Password);
                    cmd.Parameters.AddWithValue("@FullName", newUser.FullName);
                    cmd.Parameters.AddWithValue("@CityId", newUser.CityId);
                    cmd.Parameters.AddWithValue("@Phone", newUser.Phone);

                    cmd.ExecuteNonQuery();
                    cn.Close();
                    return RedirectToAction("Index");
               
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: user/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: user/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult login()
        {
            Users LoginUser = new Users();
            
            return View(LoginUser);
        }
        [HttpPost]
        public ActionResult login(Users newUser)
        {
            try
            {

                //Console.WriteLine(newUser.CityId);
                // TODO: Add insert logic here
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=MVCDb;Integrated Security=True;Pooling=False";
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Users where UserName = @UserName AND Password = @Password";
                    //cmd.CommandText = "insert into Users() values('"+ newUser.UserName+"','"+ newUser.Email + "','" + newUser.Password + "','',1,'025755188')";

                cmd.Parameters.AddWithValue("@UserName", newUser.UserName);
               
                cmd.Parameters.AddWithValue("@Password", newUser.Password);
                /*  cmd.Parameters.AddWithValue("@FullName", newUser.FullName);
                  cmd.Parameters.AddWithValue("@CityId", newUser.CityId);
                  cmd.Parameters.AddWithValue("@Phone", newUser.Phone);*/
                SqlDataReader dr = cmd.ExecuteReader();
                bool success = false;
                /*while (dr.Read()) {
                    success = true;
                }*/
               
                if (dr.Read())
                {
                    Users u = new Users
                    {
                        UserName = dr.GetString(0),
                        Email = dr.GetString(1),
                        Password = dr.GetString(2),
                        FullName = dr.GetString(3),
                        CityId = dr.GetInt32(4),
                        Phone = dr.GetString(5),
                    };
                    Session.Add("logged_user", u);
                    Session.Add("logged_username", u.UserName);
                    Session.Add("logged_Email", u.Email);
                    Session.Add("logged_Password", u.Password);
                    Session.Add("logged_phone", u.Phone);
                    Session.Add("logged_FullName", u.FullName);
                    Session.Add("logged_CityId", u.CityId);

                    if (newUser.IsActive)
                    {
                        HttpCookie objCookie = new HttpCookie("Poonam");

                        objCookie.Expires = DateTime.Now.AddDays(2);
                        objCookie.Values["UserName"] = u.UserName;
                        objCookie.Values["Password"] = u.Password;

                        Response.Cookies.Add(objCookie);
                    }
                    return RedirectToAction("Index");
                }
              
                else {
                   // ViewBag.msg = "Login Details Invalid";
                    string msg = "Login Details Invalid";
                    TempData["msg"] = msg;
                    return RedirectToAction("login");


                }
               
            }
            catch (Exception e)

            {

                return View();
            }
        }
        public ActionResult logout(string msg = "you have succesfully logged out")
        {
            Session.Abandon();
            HttpCookie obj = Request.Cookies["Poon"];
            TempData["msg1"] = "you have succesfully logged out";
            ViewBag.msg = "you have succesfully logged out";
            return RedirectToAction("login");
        }
        public bool IsCookieAlive(Users user)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=MVCDb;Integrated Security=True;Pooling=False";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Users where UserName=@UserName and Password = @Password";

            cmd.Parameters.AddWithValue("@UserName", user.UserName);
            cmd.Parameters.AddWithValue("@Password", user.Password);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Users u = new Users
                {
                    UserName = dr.GetString(0),
                    Email = dr.GetString(1),
                    Password = dr.GetString(2),
                    FullName = dr.GetString(3),
                    CityId = dr.GetInt32(4),
                    Phone = dr.GetString(5),
                };

                Session.Add("logged_user", u);
                Session.Add("logged_username", u.UserName);
                Session.Add("logged_Email", u.Email);
                Session.Add("logged_Password", u.Password);
                Session.Add("logged_phone", u.Phone);
                Session.Add("logged_FullName", u.FullName);
                Session.Add("logged_CityId", u.CityId);

                return true;
            }
            return false;

        }

        public bool bypass() {

            HttpCookie objCookie = Request.Cookies["Poonam Pise"];
            if (Session["logged_user"] != null)
            {
                return true;
            }
            else if (objCookie != null)
            {
                Users user = new Users
                {
                    UserName = objCookie.Values["UserName"],
                    Password = objCookie.Values["Password"]
                };
                if (IsCookieAlive(user))
                {
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return false;
            }

        }

       
    }
}
