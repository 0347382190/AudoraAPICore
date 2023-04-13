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
        public List<GheEntity> Hienthidanhsachghetheongaygio(int giochieu,DateTime ngaychieu,int FK_iPhongchieuID)
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
                            GheEntity.iDay = Convert.ToInt32( rd["iDay"]);
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
        public List<VeEntity> DatVe (int PK_Ghe, string sSoDienThoai, int PK_iPhongchieuID)
        {
            List<VeEntity> lst_Ve= new List<VeEntity>();
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_BookVe", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PK_Ghe", PK_Ghe);
                    cmd.Parameters.AddWithValue("@sSoDienThoai", sSoDienThoai);
                    cmd.Parameters.AddWithValue("@PK_iPhongchieu", PK_iPhongchieuID);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            VeEntity veEntity = new VeEntity();
                            veEntity.FK_HoadonID = Convert.ToString(rd["PK_HoadonID"]);
                            veEntity.FK_iPhongchieuID = Convert.ToInt32( rd["FK_iPhongchieuID"]);
                            veEntity.FK_iGheID = Convert.ToInt32( rd["FK_iGheID"]);
                            veEntity.PK_iVeID = Convert.ToInt32(rd["PK_iVeID"]);
                            lst_Ve.Add(veEntity);
                        }
                    }
                }
                cnn.Close();
                return lst_Ve;
            }
        }
    }
}
