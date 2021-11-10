using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TamAnh.Models
{
    public class QuyetDinhThuyenChuyen
    {

        public int ID { set; get; }

        [Display(Name = "Thời gian lập")]
        public DateTime dThoiGianLap { get; set; }

        [Display(Name = "Thời gian duyệt")]
        public DateTime dThoiGianDuyet { set; get; }

        [Required(ErrorMessage = "Nhân viên lập không được để trống")]
        [Display(Name = "Mã nhân viên lập")]
        public int iMaNVLap { get; set; }

        [Display(Name = "Nhân viên")]
        public string sTenNVLap { get; set; }

        [Display(Name = "Mã nhân viên lập")]
        public int iMaNVDuyet { get; set; }

        [Display(Name = "Người duyệt")]
        public string sTenNVDuyet { get; set; }

        [Display(Name = "Mã vị trí công việc cũ")]
        public int iMaVTCV_Cu { get; set; }

        [Display(Name = "Vị trí công việc cũ")]
        public string sTenVTCV_Cu { get; set; }

        [Display(Name = "Bộ phận cũ")]
        public string sTenBoPhan_Cu { get; set; }

        [Required(ErrorMessage = "Vị trí công việc mới không được để trống")]
        [Display(Name = "Mã vị trí công việc mới")]
        public int iMaVTCV_Moi { get; set; }

        [Display(Name = "Vị trí công việc mới")]
        public string sTenVTCV_Moi { get; set; }

        [Display(Name = "Bộ phận mới")]
        public string sTenBoPhan_Moi { get; set; }

        [Display(Name = "Lý do")]
        public string sLyDo { get; set; }

        [Display(Name = "Trạng thái")]
        public int iTrangThai { get; set; }

    }

    public class ListQuyetDinhThuyenChuyen
    {
        public static int STATE_WAITING = 1;
        public static int STATE_APPROVED = 2;
        public static int STATE_NOT_APPROVED = 3;

        DBConnection db;

        public ListQuyetDinhThuyenChuyen()
        {
            db = new DBConnection();
        }

        public List<QuyetDinhThuyenChuyen> get(int ID = 0)
        {
            String sql;
            if (ID == 0)
                sql = "SELECT DISTINCT [PK_QĐCVTCV_iId]"
                        + " ,[QĐCVTCV_dThoigianlap]"
                        + " ,[QĐCVTCV_dThoigianduyet]"
                        + " ,[FK_NhanVien_iMaNhanVien]"
                        + " ,NV.NhanVien_sHoVaTen as [NV_ho_ten]"
                        + " ,[FK_NhanVien_iMaNhanVienDuyet]"
                        + " ,(CASE WHEN FK_NhanVien_iMaNhanVienDuyet = 0 THEN NULL ELSE NVDUYET.NhanVien_sHoVaTen END) as [NVDUYET_ho_ten]"
                        + " ,[FK_VTCV_iIdcu]"
                        + " ,VTCVCU.VCCV_sTenVCCV as [VTCVCU_ten]"
                        + " ,BOPHANCU.BoPhan_sTenBoPhan as [BOPHANCU_ten]"
                        + " ,[FK_VTCV_iIdmoi]"
                        + " ,VTCVMOI.VCCV_sTenVCCV as [VTCVMOI_ten]"
                        + " ,BOPHANMOI.BoPhan_sTenBoPhan as [BOPHANMOI_ten]"
                        + " ,[QĐCVTCV_sLyDo]"
                        + " ,[QĐCVTCV_dTrangThai]"
                        + " FROM tblquyetdinhchuyen_vtcongviec"
                  + " JOIN tblnhanvien as NV ON tblquyetdinhchuyen_vtcongviec.FK_NhanVien_iMaNhanVien = NV.PK_iIdNhanVien"
                  + " JOIN tblnhanvien as NVDUYET ON tblquyetdinhchuyen_vtcongviec.FK_NhanVien_iMaNhanVienDuyet = NVDUYET.PK_iIdNhanVien"
                  + " OR tblquyetdinhchuyen_vtcongviec.FK_NhanVien_iMaNhanVienDuyet = 0"
                  + " JOIN tblvitricongviec AS VTCVCU ON tblquyetdinhchuyen_vtcongviec.FK_VTCV_iIdcu = VTCVCU.PK_VCCV_iMaVCCV"
                  + " JOIN tblvitricongviec AS VTCVMOI ON tblquyetdinhchuyen_vtcongviec.FK_VTCV_iIdmoi = VTCVMOI.PK_VCCV_iMaVCCV"
                  + " JOIN tblbophan AS BOPHANCU ON VTCVCU.FK_BoPhan_MaBP = BOPHANCU.PK_BoPhan_iMaBoPhan"
                  + " JOIN tblbophan AS BOPHANMOI ON VTCVMOI.FK_BoPhan_MaBP = BOPHANMOI.PK_BoPhan_iMaBoPhan";
            else
                sql = "SELECT DISTINCT [PK_QĐCVTCV_iId]"
                        + " ,[QĐCVTCV_dThoigianlap]"
                        + " ,[QĐCVTCV_dThoigianduyet]"
                        + " ,[FK_NhanVien_iMaNhanVien]"
                        + " ,NV.NhanVien_sHoVaTen as [NV_ho_ten]"
                        + " ,[FK_NhanVien_iMaNhanVienDuyet]"
                        + " ,(CASE WHEN FK_NhanVien_iMaNhanVienDuyet = 0 THEN NULL ELSE NVDUYET.NhanVien_sHoVaTen END) as [NVDUYET_ho_ten]"
                        + " ,[FK_VTCV_iIdcu]"
                        + " ,VTCVCU.VCCV_sTenVCCV as [VTCVCU_ten]"
                        + " ,BOPHANCU.BoPhan_sTenBoPhan as [BOPHANCU_ten]"
                        + " ,[FK_VTCV_iIdmoi]"
                        + " ,VTCVMOI.VCCV_sTenVCCV as [VTCVMOI_ten]"
                        + " ,BOPHANMOI.BoPhan_sTenBoPhan as [BOPHANMOI_ten]"
                        + " ,[QĐCVTCV_sLyDo]"
                        + " ,[QĐCVTCV_dTrangThai]"
                        + " FROM tblquyetdinhchuyen_vtcongviec"
                  + " JOIN tblnhanvien as NV ON tblquyetdinhchuyen_vtcongviec.FK_NhanVien_iMaNhanVien = NV.PK_iIdNhanVien"
                  + " JOIN tblnhanvien as NVDUYET ON tblquyetdinhchuyen_vtcongviec.FK_NhanVien_iMaNhanVienDuyet = NVDUYET.PK_iIdNhanVien"
                  + " OR tblquyetdinhchuyen_vtcongviec.FK_NhanVien_iMaNhanVienDuyet = 0"
                  + " JOIN tblvitricongviec AS VTCVCU ON tblquyetdinhchuyen_vtcongviec.FK_VTCV_iIdcu = VTCVCU.PK_VCCV_iMaVCCV"
                  + " JOIN tblvitricongviec AS VTCVMOI ON tblquyetdinhchuyen_vtcongviec.FK_VTCV_iIdmoi = VTCVMOI.PK_VCCV_iMaVCCV"
                  + " JOIN tblbophan AS BOPHANCU ON VTCVCU.FK_BoPhan_MaBP = BOPHANCU.PK_BoPhan_iMaBoPhan"
                  + " JOIN tblbophan AS BOPHANMOI ON VTCVMOI.FK_BoPhan_MaBP = BOPHANMOI.PK_BoPhan_iMaBoPhan WHERE [PK_QĐCVTCV_iId] = " + ID;

            List<QuyetDinhThuyenChuyen> list = new List<QuyetDinhThuyenChuyen>();

            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            QuyetDinhThuyenChuyen item;
            for (int i = 0, len = dt.Rows.Count; i < len; ++i)
            {
                item = new QuyetDinhThuyenChuyen();
                item.ID = Convert.ToInt32(dt.Rows[i]["PK_QĐCVTCV_iId"].ToString());
                item.dThoiGianLap = (DateTime)dt.Rows[i]["QĐCVTCV_dThoigianlap"];
                item.dThoiGianDuyet = (DateTime)dt.Rows[i]["QĐCVTCV_dThoigianduyet"];
                item.iMaNVLap = Convert.ToInt32(dt.Rows[i]["FK_NhanVien_iMaNhanVien"].ToString());
                item.sTenNVLap = dt.Rows[i]["NV_ho_ten"].ToString();
                item.iMaNVDuyet = Convert.ToInt32(dt.Rows[i]["FK_NhanVien_iMaNhanVienDuyet"].ToString());
                item.sTenNVDuyet = dt.Rows[i]["NVDUYET_ho_ten"].ToString();
                item.iMaVTCV_Cu = Convert.ToInt32(dt.Rows[i]["FK_VTCV_iIdcu"].ToString());
                item.sTenVTCV_Cu = dt.Rows[i]["VTCVCU_ten"].ToString();
                item.sTenBoPhan_Cu = dt.Rows[i]["BOPHANCU_ten"].ToString();
                item.iMaVTCV_Moi = Convert.ToInt32(dt.Rows[i]["FK_VTCV_iIdmoi"].ToString());
                item.sTenVTCV_Moi = dt.Rows[i]["VTCVMOI_ten"].ToString();
                item.sTenBoPhan_Moi = dt.Rows[i]["BOPHANMOI_ten"].ToString();
                item.sLyDo = dt.Rows[i]["QĐCVTCV_sLyDo"].ToString();
                item.iTrangThai = Convert.ToInt32(dt.Rows[i]["QĐCVTCV_dTrangThai"].ToString());

                list.Add(item);
            }
            return list;
        }

        public bool add(QuyetDinhThuyenChuyen item)
        {
            string sql = "INSERT INTO [dbo].[tblquyetdinhchuyen_vtcongviec]"
                           + " ([QĐCVTCV_dThoigianlap]"
                           + " ,[QĐCVTCV_dThoigianduyet]"
                           + " ,[FK_NhanVien_iMaNhanVien]"
                           + " ,[FK_NhanVien_iMaNhanVienDuyet]"
                           + " ,[FK_VTCV_iIdcu]"
                           + " ,[FK_VTCV_iIdmoi]"
                           + " ,[QĐCVTCV_sLyDo]"
                           + " ,[QĐCVTCV_dTrangThai])"
                        + " VALUES"
                           + " (@QĐCVTCV_dThoigianlap"
                           + " ,@QĐCVTCV_dThoigianduyet"
                           + " ,@FK_NhanVien_iMaNhanVien"
                           + " ,@FK_NhanVien_iMaNhanVienDuyet"
                           + " ,@FK_VTCV_iIdcu"
                           + " ,@FK_VTCV_iIdmoi"
                           + " ,@QĐCVTCV_sLyDo"
                           + " ,@QĐCVTCV_dTrangThai)";
            SqlConnection con = db.getConnection();

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@QĐCVTCV_dThoigianlap", item.dThoiGianLap);
            cmd.Parameters.AddWithValue("@QĐCVTCV_dThoigianduyet", item.dThoiGianDuyet);
            cmd.Parameters.AddWithValue("@FK_NhanVien_iMaNhanVien", item.iMaNVLap);
            cmd.Parameters.AddWithValue("@FK_NhanVien_iMaNhanVienDuyet", item.iMaNVDuyet);
            cmd.Parameters.AddWithValue("@FK_VTCV_iIdcu", item.iMaVTCV_Cu);
            cmd.Parameters.AddWithValue("@FK_VTCV_iIdmoi", item.iMaVTCV_Moi);
            cmd.Parameters.AddWithValue("@QĐCVTCV_sLyDo", item.sLyDo != null ? item.sLyDo : "");
            cmd.Parameters.AddWithValue("@QĐCVTCV_dTrangThai", item.iTrangThai);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i > 0;
        }

        public bool aproved(QuyetDinhThuyenChuyen quyetDinh)
        {
            ListNhanVien listNhanVien = new ListNhanVien();
            NhanVien nv = listNhanVien.get(quyetDinh.iMaNVLap).FirstOrDefault();
            nv.iMaVTCV = quyetDinh.iMaVTCV_Moi;
            bool success = listNhanVien.update(nv);

            if (success)
            {
                string sql = "UPDATE tblquyetdinhchuyen_vtcongviec SET [QĐCVTCV_dTrangThai] = " + STATE_APPROVED 
                    + ", [QĐCVTCV_dThoigianduyet] = @thoiGianDuyet, [FK_NhanVien_iMaNhanVienDuyet] = @nguoiDuyet"
                    + " WHERE [PK_QĐCVTCV_iId] = @id";
                SqlConnection con = db.getConnection();

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@thoiGianDuyet", DateTime.Now);
                cmd.Parameters.AddWithValue("@nguoiDuyet", quyetDinh.iMaNVDuyet);
                cmd.Parameters.AddWithValue("@id", quyetDinh.ID);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                return i > 0;
            }
            else
            {
                return false;
            }
        }

        public bool notAproved(QuyetDinhThuyenChuyen quyetDinh)
        {
            string sql = "UPDATE tblquyetdinhchuyen_vtcongviec SET [QĐCVTCV_dTrangThai] = " + STATE_NOT_APPROVED
                                + ", [QĐCVTCV_dThoigianduyet] = @thoiGianDuyet, [FK_NhanVien_iMaNhanVienDuyet] = @nguoiDuyet"
                                + " WHERE [PK_QĐCVTCV_iId] = @id"; 
            SqlConnection con = db.getConnection();

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@thoiGianDuyet", DateTime.Now);
            cmd.Parameters.AddWithValue("@nguoiDuyet", quyetDinh.iMaNVDuyet);
            cmd.Parameters.AddWithValue("@id", quyetDinh.ID);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i > 0;
        }
    }
}