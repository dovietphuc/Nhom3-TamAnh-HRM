using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace StudentManager.Areas.Admin.Models
{
    public class HopDong
    {
        public int ID { set; get; }

        [Required(ErrorMessage = "Số hợp đồng không được để trống")]
        [Display(Name = "Số hợp đồng")]
        public int iSoHopDong { get; set; }

        [Required(ErrorMessage = "Ngày ký không được để trống")]
        [Display(Name = "Ngày ký")]
        public DateTime dNgayKy { set; get; }

        [Required(ErrorMessage = "Ngày có hiệu lực không được để trống")]
        [Display(Name = "Ngày có hiệu lực")]
        public DateTime dNgayCoHieuLuc { get; set; }

        [Required(ErrorMessage = "Ngày hết hạn không được để trống")]
        [Display(Name = "Ngày hết hạn")]
        public DateTime dNgayHetHan { get; set; }

        [Required(ErrorMessage = "Lương cơ bản không được để trống")]
        [Display(Name = "Lương cơ bản")]
        public int iLuongCoBan { get; set; }

        [Required(ErrorMessage = "Lương cơ đóng bảo hiểm không được để trống")]
        [Display(Name = "Lương đóng bảo hiểm")]
        public int iLuongDongBH { get; set; }

        [Display(Name = "Ghi chú")]
        public string sGhiChu { get; set; } = "";

        [Display(Name = "Đường dẫn tệp đính kèm")]
        public string sTepDinhKem { get; set; } = "";

        [Required(ErrorMessage = "Mã nhân viên không được để trống")]
        [Display(Name = "Mã nhân viên")]
        public int iMaNhanVien { get; set; }

        [Display(Name = "Nhân viên")]
        public string sTenNhanVien { get; set; }

        public NhanVien nhanVien { get; set; }
    }

    public class ListHopDong
    {
        DBConnection db;

        public ListHopDong()
        {
            db = new DBConnection();
        }

        public List<HopDong> get(int ID = 0)
        {
            String sql;
            if (ID == 0)
                sql = "SELECT * FROM tblhopdonglaodong";
            else
                sql = "SELECT * FROM tblhopdonglaodong WHERE PK_HDLD_iMaHD = " + ID;

            List<HopDong> listHopDong = new List<HopDong>();

            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            HopDong hopDong;
            for (int i = 0, len = dt.Rows.Count; i < len; ++i)
            {
                hopDong = new HopDong();
                hopDong.ID = Convert.ToInt32(dt.Rows[i]["PK_HDLD_iMaHD"].ToString());
                hopDong.iSoHopDong = Convert.ToInt32(dt.Rows[i]["HDLD_iSoHopDong"].ToString());
                hopDong.dNgayKy = (DateTime)dt.Rows[i]["HDLD_dNgayKy"];
                hopDong.dNgayCoHieuLuc = (DateTime)dt.Rows[i]["HDLD_dNgayCoHieuLuc"];
                hopDong.dNgayHetHan = (DateTime)dt.Rows[i]["HDLD_dNgayHetHan"];
                hopDong.iLuongCoBan = Convert.ToInt32(dt.Rows[i]["HDLD_iLuongCoBan"].ToString());
                hopDong.iLuongDongBH = Convert.ToInt32(dt.Rows[i]["HDLD_iLuongDongBH"].ToString());
                hopDong.sGhiChu = dt.Rows[i]["HDLD_sGhiChu"].ToString();
                hopDong.sTepDinhKem = dt.Rows[i]["HDLD_sTepDinhKem"].ToString();
                hopDong.iMaNhanVien = Convert.ToInt32(dt.Rows[i]["FK_NhanVien_iIDNhanVien"].ToString());
                hopDong.nhanVien = new ListNhanVien().get(hopDong.iMaNhanVien).FirstOrDefault();
                hopDong.sTenNhanVien = hopDong.nhanVien.sTenNhanVien;

                listHopDong.Add(hopDong);
            }
            return listHopDong;
        }

        public bool add(HopDong hopDong)
        {
            string sql = "INSERT INTO [dbo].[tblhopdonglaodong] " +
                "([HDLD_iSoHopDong]" +
                ",[HDLD_dNgayKy]" +
                ",[HDLD_dNgayCoHieuLuc]" +
                ",[HDLD_dNgayHetHan]" +
                ",[HDLD_iLuongCoBan]" +
                ",[HDLD_iLuongDongBH]" +
                ",[HDLD_sGhiChu]" +
                ",[HDLD_sTepDinhKem]" +
                ",[FK_NhanVien_iIDNhanVien])" +
                " VALUES " +
                "(@SoHopDong" +
                ",@NgayKy" +
                ",@NgayCoHieuLuc" +
                ",@NgayHetHan" +
                ",@LuongCoBan" +
                ",@LuongDongBH" +
                ",@GhiChu" +
                ",@TepDinhKem" +
                ",@IDNhanVien)";
            SqlConnection con = db.getConnection();

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@SoHopDong", hopDong.iSoHopDong);
            cmd.Parameters.AddWithValue("@NgayKy", hopDong.dNgayKy);
            cmd.Parameters.AddWithValue("@NgayCoHieuLuc", hopDong.dNgayCoHieuLuc);
            cmd.Parameters.AddWithValue("@NgayHetHan", hopDong.dNgayHetHan);
            cmd.Parameters.AddWithValue("@LuongCoBan", hopDong.iLuongCoBan);
            cmd.Parameters.AddWithValue("@LuongDongBH", hopDong.iLuongDongBH);
            cmd.Parameters.AddWithValue("@GhiChu", hopDong.sGhiChu != null ? hopDong.sGhiChu : "");
            cmd.Parameters.AddWithValue("@TepDinhKem", hopDong.sTepDinhKem != null ? hopDong.sTepDinhKem : "");
            cmd.Parameters.AddWithValue("@IDNhanVien", hopDong.iMaNhanVien);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            
            return i > 0;
        }

        public bool update(HopDong hopDong)
        {
            string sql = "UPDATE [dbo].[tblhopdonglaodong]"
                        + " SET [HDLD_iSoHopDong] = @iSoHopDong"
                         + ",[HDLD_dNgayKy] = @dNgayKy"
                         + ",[HDLD_dNgayCoHieuLuc] = @dNgayCoHieuLuc"
                         + ",[HDLD_dNgayHetHan] = @dNgayHetHan"
                         + ",[HDLD_iLuongCoBan] = @iLuongCoBan"
                         + ",[HDLD_iLuongDongBH] = @iLuongDongBH"
                         + ",[HDLD_sGhiChu] = @sGhiChu"
                         + ",[HDLD_sTepDinhKem] = @sTepDinhKem"
                         + ",[FK_NhanVien_iIDNhanVien] = @iIDNhanVien"
                         + " WHERE [PK_HDLD_iMaHD] = @id";
            SqlConnection con = db.getConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@iSoHopDong", hopDong.iSoHopDong);
                cmd.Parameters.AddWithValue("@dNgayKy", hopDong.dNgayKy);
                cmd.Parameters.AddWithValue("@dNgayCoHieuLuc", hopDong.dNgayCoHieuLuc);
                cmd.Parameters.AddWithValue("@dNgayHetHan", hopDong.dNgayHetHan);
                cmd.Parameters.AddWithValue("@iLuongCoBan", hopDong.iLuongCoBan);
                cmd.Parameters.AddWithValue("@iLuongDongBH", hopDong.iLuongDongBH);
                cmd.Parameters.AddWithValue("@sGhiChu", hopDong.sGhiChu != null ? hopDong.sGhiChu : "");
                cmd.Parameters.AddWithValue("@sTepDinhKem", hopDong.sTepDinhKem != null ? hopDong.sTepDinhKem : "");
                cmd.Parameters.AddWithValue("@iIDNhanVien", hopDong.iMaNhanVien);
                cmd.Parameters.AddWithValue("@id", hopDong.ID);
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
            string sql = "DELETE FROM tblhopdonglaodong WHERE PK_HDLD_iMaHD = @id";
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