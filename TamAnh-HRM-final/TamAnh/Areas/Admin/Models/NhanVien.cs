using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentManager.Areas.Admin.Models
{
    public class NhanVien
    {
        public int ID { set; get; }

        [Required(ErrorMessage = "Họ và tên không được để trống")]
        [Display(Name = "Họ và tên")]
        public string sTenNhanVien { get; set; }

        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [Display(Name = "Ngày sinh")]
        public DateTime dNgaySinh { set; get; }

        [Required(ErrorMessage = "Giới tính không được để trống")]
        [Display(Name = "Giới tính")]
        public bool bGioiTinh { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [Display(Name = "Địa chỉ")]
        public string sDiaChi { get; set; }

        [Required(ErrorMessage = "Điện thoại không được để trống")]
        [Display(Name = "Điện thoại")]
        public string sDienThoai { get; set; }

        [Display(Name = "Bằng cấp")]
        public string sBangCap { get; set; } = "";

        [Required(ErrorMessage = "CMND / CCCD không được để trống")]
        [Display(Name = "CMND/CCCD")]
        public string sCMT { get; set; }

        [Required(ErrorMessage = "Mã vị trí công việc không được để trống")]
        [Display(Name = "Mã vị trí công việc")]
        public int iMaVTCV { get; set; }

        [Display(Name = "Vị trí công việc")]
        public string sTenVTCV { get; set; }

        public ViTriCongViec viTriCongViec { get; set; }
    }

    public class ListNhanVien
    {
        DBConnection db;

        public ListNhanVien()
        {
            db = new DBConnection();
        }

        public List<NhanVien> get(int ID = 0)
        {
            String sql;
            if (ID == 0)
                sql = "SELECT * FROM tblnhanvien";
            else
                sql = "SELECT * FROM tblnhanvien WHERE PK_iIdNhanVien = " + ID;

            List<NhanVien> nhanViens = new List<NhanVien>();

            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            NhanVien nhanVien;
            for (int i = 0, len = dt.Rows.Count; i < len; ++i)
            {
                nhanVien = new NhanVien();
                nhanVien.ID = Convert.ToInt32(dt.Rows[i]["PK_iIdNhanVien"].ToString());
                nhanVien.sTenNhanVien = dt.Rows[i]["NhanVien_sHoVaTen"].ToString();
                nhanVien.dNgaySinh = (DateTime)dt.Rows[i]["NhanVien_sNgaySinh"];
                nhanVien.bGioiTinh = Boolean.Parse(dt.Rows[i]["NhanVien_sGioiTinh"].ToString());
                nhanVien.sDiaChi = dt.Rows[i]["NhanVien_sDiaChi"].ToString();
                nhanVien.sDienThoai = dt.Rows[i]["NhanVien_sDienThoai"].ToString();
                nhanVien.sBangCap = dt.Rows[i]["NhanVien_sBangCap"].ToString();
                nhanVien.sCMT = dt.Rows[i]["NhanVien_sCMT"].ToString();
                nhanVien.iMaVTCV = Convert.ToInt32(dt.Rows[i]["FK_VCCV_iMaVCCV"].ToString());
                nhanVien.viTriCongViec = new ListViTri().get(nhanVien.iMaVTCV).FirstOrDefault();
                nhanVien.sTenVTCV = nhanVien.viTriCongViec.sTenViTri;

                nhanViens.Add(nhanVien);
            }
            return nhanViens;
        }

        public bool add(NhanVien nhanVien)
        {
            string sql = "INSERT INTO [dbo].[tblnhanvien] " +
                "([NhanVien_sHoVaTen]" +
                ",[NhanVien_sNgaySinh]" +
                ",[NhanVien_sGioiTinh]" +
                ",[NhanVien_sDiaChi]" +
                ",[NhanVien_sDienThoai]" +
                ",[NhanVien_sBangCap]" +
                ",[NhanVien_sCMT]" +
                ",[FK_VCCV_iMaVCCV])" +
                " VALUES " +
                "(@HoTen" +
                ",@NgaySinh" +
                ",@GioiTinh" +
                ",@DiaChi" +
                ",@DienThoai" +
                ",@BangCap" +
                ",@CMT" +
                ",@MaVTCV)";
            SqlConnection con = db.getConnection();

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@HoTen", nhanVien.sTenNhanVien);
            cmd.Parameters.AddWithValue("@NgaySinh", nhanVien.dNgaySinh);
            cmd.Parameters.AddWithValue("@GioiTinh", nhanVien.bGioiTinh);
            cmd.Parameters.AddWithValue("@DiaChi", nhanVien.sDiaChi);
            cmd.Parameters.AddWithValue("@DienThoai", nhanVien.sDienThoai);
            cmd.Parameters.AddWithValue("@BangCap", nhanVien.sBangCap != null ? nhanVien.sBangCap : "");
            cmd.Parameters.AddWithValue("@CMT", nhanVien.sCMT);
            cmd.Parameters.AddWithValue("@MaVTCV", nhanVien.iMaVTCV);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i > 0;
        }

        public bool update(NhanVien nhanVien)
        {
            string sql = "UPDATE [dbo].[tblnhanvien]"
                        + " SET [NhanVien_sHoVaTen] = @HoTen"
                         + ",[NhanVien_sNgaySinh] = @NgaySinh"
                         + ",[NhanVien_sGioiTinh] = @GioiTinh"
                         + ",[NhanVien_sDiaChi] = @DiaChi"
                         + ",[NhanVien_sDienThoai] = @DienThoai"
                         + ",[NhanVien_sBangCap] = @BangCap"
                         + ",[NhanVien_sCMT] = @CMT"
                         + ",[FK_VCCV_iMaVCCV] = @MaVTCV"
                         + " WHERE [PK_iIdNhanVien] = @id";
            SqlConnection con = db.getConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@HoTen", nhanVien.sTenNhanVien);
                cmd.Parameters.AddWithValue("@NgaySinh", nhanVien.dNgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", nhanVien.bGioiTinh);
                cmd.Parameters.AddWithValue("@DiaChi", nhanVien.sDiaChi);
                cmd.Parameters.AddWithValue("@DienThoai", nhanVien.sDienThoai);
                cmd.Parameters.AddWithValue("@BangCap", nhanVien.sBangCap != null ? nhanVien.sBangCap : "");
                cmd.Parameters.AddWithValue("@CMT", nhanVien.sCMT);
                cmd.Parameters.AddWithValue("@MaVTCV", nhanVien.iMaVTCV);
                cmd.Parameters.AddWithValue("@id", nhanVien.ID);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                return i > 0;
            }
            catch (Exception e)
            {
                con.Close();
                return false;
            }
        }

        public bool delete(int ID)
        {
            string sql = "DELETE FROM tblnhanvien WHERE PK_iIdNhanVien = @id";
            SqlConnection con = db.getConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.CommandType = CommandType.Text;
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i > 0;
            }
            catch (Exception e)
            {
                con.Close();
                return false;
            }
        }

    }
}