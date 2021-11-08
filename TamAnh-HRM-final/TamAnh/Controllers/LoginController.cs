using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TamAnh.Models;

namespace TamAnh.Controllers
{
    public class LoginController : Controller
    {
        DBConnection db;

        public LoginController()
        {
            db = new DBConnection();
        }
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                return RedirectToAction("../Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            
            SqlConnection myCnn = db.getConnection();
            myCnn.Open();
            SqlCommand cmd = new SqlCommand("Select * from tbltaikhoan JOIN tblnhanvien ON tbltaikhoan.FK_NhanVien_iId = tblnhanvien.PK_iIdNhanVien where TaiKhoan_sTen = @user AND TaiKhoan_sMatKhau = @pass", myCnn);
            //FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1")
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@pass", password);
            cmd.CommandType = CommandType.Text;
            using (SqlDataReader data = cmd.ExecuteReader())
            {
                if (data.Read())
                {
                    Session["username"] = data["NhanVien_sHoVaTen"];
                    Session["user_id"] = data["PK_iIdNhanVien"];
                    return RedirectToAction("../Home");
                }
                else
                {
                    ViewBag.error = "Tài khoản hoặc mật khẩu không chính xác";
                    return View("Index");
                }
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove("username");
            Session.Remove("user_id");
            return RedirectToAction("Index");
        }

    }

}
