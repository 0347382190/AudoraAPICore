using AudoraAPICore.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using System.IO;

namespace AudoraAPICore.DAL
{
    public class PhongchieuDAL
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
        public List<PhongchieuEntity> Danhsachphongchieu()
        {
            List<PhongchieuEntity> glstPhongchieu = new List<PhongchieuEntity>();
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spPhongchieu_GetALL", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            PhongchieuEntity phongchieuEntity = new PhongchieuEntity();
                            phongchieuEntity.PK_iPhongchieuID = Convert.ToInt32(rd["PK_iPhongchieuID"]); 
                            phongchieuEntity.sDay = rd["sDay"].ToString();
                            phongchieuEntity.iCot = Convert.ToInt32(rd["iCot"]);
                            phongchieuEntity.iSoluong = Convert.ToInt32(rd["iSoluong"]);
                            phongchieuEntity.isTrangthai = Convert.ToBoolean(rd["isTrangthai"]);
                            glstPhongchieu.Add(phongchieuEntity);
                        }
                    }
                }
                cnn.Close();

            }
            return glstPhongchieu;
        }
        public List<PhongchieuEntity> Timkiemphongchieu(long PK_iPhongchieuID)
        {
            List<PhongchieuEntity> glstPhongchieu = new List<PhongchieuEntity>();
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spPhongchieu_GetbyPK", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PK_iPhongchieuID", PK_iPhongchieuID);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            PhongchieuEntity phongchieuEntity = new PhongchieuEntity();
                            phongchieuEntity.PK_iPhongchieuID = Convert.ToInt32(rd["PK_iPhongchieuID"]);
                            phongchieuEntity.sDay = rd["sDay"].ToString();
                            phongchieuEntity.iCot = Convert.ToInt32(rd["iCot"]);
                            phongchieuEntity.iSoluong = Convert.ToInt32(rd["iSoluong"]);
                            phongchieuEntity.isTrangthai = Convert.ToBoolean(rd["isTrangthai"]);
                            glstPhongchieu.Add(phongchieuEntity);
                        }
                    }
                }
                cnn.Close();
            }
            return glstPhongchieu;
        }
        public long Themphongchieu(PhongchieuEntity phongchieuEntity)
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spPhongchieu_Insert", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sDay", phongchieuEntity.sDay);
                    cmd.Parameters.AddWithValue("@iCot", phongchieuEntity.iCot);
                    cmd.Parameters.AddWithValue("@iSoluong", phongchieuEntity.iSoluong);
                    cmd.Parameters.AddWithValue("@isTrangthai", phongchieuEntity.isTrangthai);
                    long IDPhongchieu = Convert.ToInt64(cmd.ExecuteScalar());
                    cnn.Close();
                    return IDPhongchieu;
                }
            }
        }
        public bool Suaphongchieu(PhongchieuEntity phongchieuEntity)
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spKhachhang_Update", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PK_iPhongchieuID", phongchieuEntity.PK_iPhongchieuID);
                    cmd.Parameters.AddWithValue("@sDay", phongchieuEntity.sDay);
                    cmd.Parameters.AddWithValue("@iCot", phongchieuEntity.iCot);
                    cmd.Parameters.AddWithValue("@iSoluong", phongchieuEntity.iSoluong);
                    cmd.Parameters.AddWithValue("@isTrangthai", phongchieuEntity.isTrangthai);
                    long i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    if (i > 0)
                        return true;
                    else
                        return false;
                }
            }
        }
        public bool Xoaphongchieu(PhongchieuEntity phongchieuEntity)
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spPhongchieu_Delete", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PK_iPhongchieuID", phongchieuEntity.PK_iPhongchieuID);
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
