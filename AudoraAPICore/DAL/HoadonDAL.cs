using AudoraAPICore.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using System.IO;

namespace AudoraAPICore.DAL
{
    public class HoadonDAL
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
        public List<HoadonEntity> Danhsachhoadon()
        {
            List<HoadonEntity> glstHoadon = new List<HoadonEntity>();
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spHoadon_Getall", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            HoadonEntity hoadonEntity = new HoadonEntity();
                            hoadonEntity.PK_iHoadonID = Convert.ToInt32(rd["PK_iHoadonID"]);
                            hoadonEntity.dNgaylap = Convert.ToDateTime(rd["dNgaylap"]);
                            hoadonEntity.FK_sSodienthoai = rd["sSodienthoai"].ToString();
                            hoadonEntity.FK_sCCCD = rd["sCCCD"].ToString();
                            glstHoadon.Add(hoadonEntity);
                        }
                    }
                }
                cnn.Close();
            }
            return glstHoadon;
        }
        public List<HoadonEntity> Xemthongtinhoadon(long PK_iHoadonID)
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                List<HoadonEntity> glstHoadon = new List<HoadonEntity>();
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spHoadon_GetbyPK", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PK_iHoadonID", PK_iHoadonID);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            HoadonEntity hoadonEntity = new HoadonEntity();
                            hoadonEntity.PK_iHoadonID = Convert.ToInt32(rd["PK_iHoadonID"]);
                            hoadonEntity.dNgaylap = Convert.ToDateTime(rd["dNgaylap"]);
                            hoadonEntity.FK_sSodienthoai = rd["FK_sSodienthoai"].ToString();
                            hoadonEntity.FK_sCCCD = rd["FK_sCCCD"].ToString();
                            glstHoadon.Add(hoadonEntity);
                        }
                    }
                }
                cnn.Close();
                return glstHoadon;
            }
        }
        public long Themthongtinhoadon(HoadonEntity hoadonEntity)
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spHoadon_Insert", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@dNgaylap", hoadonEntity.dNgaylap);
                    cmd.Parameters.AddWithValue("@FK_sSodienthoai", hoadonEntity.FK_sSodienthoai);
                    cmd.Parameters.AddWithValue("@FK_sCCCD", hoadonEntity.FK_sCCCD);
                    long IDPhim = Convert.ToInt64(cmd.ExecuteScalar());
                    cnn.Close();
                    return IDPhim;
                }
            }
        }
        public bool Suathongtinhoadon(HoadonEntity hoadonEntity)
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spHoadon_Update", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PK_iHoadonID", hoadonEntity.PK_iHoadonID);
                    cmd.Parameters.AddWithValue("@dNgaylap", hoadonEntity.dNgaylap);
                    cmd.Parameters.AddWithValue("@FK_sSodienthoai", hoadonEntity.FK_sSodienthoai);
                    cmd.Parameters.AddWithValue("@FK_sCCCD", hoadonEntity.FK_sCCCD);
                    long i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    if (i > 0)
                        return true;
                    else
                        return false;
                }
            }
        }
        public bool Xoahoadon(long PK_iHoadonID)
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spHoadon_Delete", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PK_iHoadonID", PK_iHoadonID);
                    long i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    if (i > 0)
                        return true;
                    else
                        return false;
                }

            }
        }
    }
}
