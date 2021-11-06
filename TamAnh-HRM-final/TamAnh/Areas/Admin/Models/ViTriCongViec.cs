using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentManager.Areas.Admin.Models
{
    public class ViTriCongViec
    {
        public int ID { set; get; }
        [Display(Name = "Vị trí")]
        public string sTenViTri { get; set; }
        [Display(Name = "Mô tả")]
        public string sMoTa { set; get; }
        [Display(Name = "Mã bộ phận")]
        public int iMaBoPhan { get; set; }
        [Display(Name = "Tên bộ phận")]
        public string sTenBoPhan { get; set; }
    }

    class ListViTri
    {
        DBConnection db;

        public ListViTri()
        {
            db = new DBConnection();
        }

        public List<ViTriCongViec> get(int ID = 0)
        {
            String sql;
            if (ID == 0)
                sql = "SELECT * FROM tblvitricongviec JOIN tblbophan ON tblvitricongviec.FK_BoPhan_MaBP = tblbophan.PK_BoPhan_iMaBoPhan";
            else
                sql = "SELECT * FROM tblvitricongviec JOIN tblbophan ON tblvitricongviec.FK_BoPhan_MaBP = tblbophan.PK_BoPhan_iMaBoPhan WHERE PK_VCCV_iMaVCCV = " + ID;

            List<ViTriCongViec> viTriCongViecs = new List<ViTriCongViec>();

            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            ViTriCongViec viTriCongViec;
            for (int i = 0, len = dt.Rows.Count; i < len; ++i)
            {
                viTriCongViec = new ViTriCongViec();
                viTriCongViec.ID = Convert.ToInt32(dt.Rows[i]["PK_VCCV_iMaVCCV"].ToString());
                viTriCongViec.sTenViTri = dt.Rows[i]["VCCV_sTenVCCV"].ToString();
                viTriCongViec.sMoTa = dt.Rows[i]["VCCV_sMoTaVCCV"].ToString();
                viTriCongViec.iMaBoPhan = Convert.ToInt32(dt.Rows[i]["FK_BoPhan_MaBP"].ToString());
                viTriCongViec.sTenBoPhan = dt.Rows[i]["BoPhan_sTenBoPhan"].ToString();

                viTriCongViecs.Add(viTriCongViec);
            }
            return viTriCongViecs;
        }
    }
}