using AudoraAPICore.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AudoraAPICore.DAL
{
    public class GheDAL
    {
        public IConfigurationRoot GetConfiguration()
        {
            var buider = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return buider.Build();
        }
        public string GetconnectString()
        {
            var configuation = GetConfiguration();
            string chuoiketnoi = configuation.GetSection("ConnectionStrings").GetSection("db_Audora").Value;
            return chuoiketnoi;
        }
        public List<GheEntity> Hienthidanhsachghetheongaygio(int giochieu, DateTime ngaychieu, int FK_iPhongchieuID)
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                List<GheEntity> glstPhim = new List<GheEntity>();
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spGhe_GetbyPhongChieu", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FK_iPhongchieuID", FK_iPhongchieuID);
                    cmd.Parameters.AddWithValue("@giochieu", giochieu);
                    cmd.Parameters.AddWithValue("@ngaychieu", ngaychieu);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            GheEntity GheEntity = new GheEntity();
                            GheEntity.PK_iGheID = Convert.ToInt32(rd["PK_iGheID"]);
                            GheEntity.iDay = Convert.ToInt32(rd["iDay"]);
                            GheEntity.iCot = Convert.ToInt32(rd["iCot"]);
                            GheEntity.FK_iPhongchieuID = Convert.ToInt32(rd["FK_iPhongchieuID"]);
                            GheEntity.isTrangthai = Convert.ToBoolean(rd["isTrangthai"]);
                            glstPhim.Add(GheEntity);
                        }
                    }
                }
                cnn.Close();
                return glstPhim;
            }
        }
        public List<HoadonEntity> DatVe( /*int FK_iPhimID,*/ int PK_Ghe, string sSoDienThoai, int PK_iPhongchieuID)
        {
            List<HoadonEntity> lst_Ve = new List<HoadonEntity>();
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_BookVe", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PK_Ghe", PK_Ghe);
                    cmd.Parameters.AddWithValue("@sSoDienThoai", sSoDienThoai);
                    cmd.Parameters.AddWithValue("@PK_iLichchieu", PK_iPhongchieuID);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            HoadonEntity hoadonEntity = new HoadonEntity();
                            hoadonEntity.FK_iPhongchieuID = Convert.ToInt32(rd["FK_iPhongchieuID"]);
                            hoadonEntity.sThoiluong = Convert.ToString(rd["sThoiluong"]);
                            hoadonEntity.sTenphim = Convert.ToString(rd["sTenphim"]);
                            hoadonEntity.tNgaybatdau = Convert.ToDateTime(rd["tNgaybatdau"]);
                            hoadonEntity.hGiochieu = Convert.ToString(rd["hGiochieu"]);
                            hoadonEntity.FK_iGheID = Convert.ToInt32(rd["FK_iGheID"]);
                            lst_Ve.Add(hoadonEntity);
                        }
                    }
                }
                cnn.Close();
                return lst_Ve;
            }
        }
        public bool Thanhtoan(string sSoDienThoai)
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("sptblHoadon_Payment_Ghe", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FK_sSoDienThoai", sSoDienThoai);
                    var rd = cmd.ExecuteNonQuery();
                    if (rd>0)
                    {
                       return true;
                    }
                }
            }
            return false ;
        }
    }
}
