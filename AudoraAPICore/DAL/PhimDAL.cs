using AudoraAPICore.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace AudoraAPICore.DAL
{
    public class PhimDAL
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

        public List<PhimEntity> Hienthidanhsachphim()
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                List<PhimEntity> glstPhim = new List<PhimEntity>();
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spPhim_GetAll", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            PhimEntity phimEntity = new PhimEntity();
                            phimEntity.PK_iPhimID = Convert.ToInt32(rd["PK_iPhimID"]);
                            phimEntity.sTenphim = rd["sTenphim"].ToString();
                            phimEntity.sThoiluong = rd["sThoiluong"].ToString();
                            phimEntity.dNgaykhoichieu = Convert.ToDateTime(rd["dNgaykhoichieu"]);
                            phimEntity.sDaodien = rd["sDaodien"].ToString();
                            phimEntity.sDienvien = rd["sDienvien"].ToString();
                            phimEntity.sMota = rd["sMota"].ToString();
                            phimEntity.sNgonngu = rd["sNgonngu"].ToString();
                            phimEntity.sAnh = rd["sAnh"].ToString();
                            glstPhim.Add(phimEntity);
                        }
                    }
                }
                cnn.Close();
                return glstPhim;
            }
        }
        public long Themphim(PhimEntity phimEntity)
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spPhim_Insert", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sTenphim", phimEntity.sTenphim);
                    cmd.Parameters.AddWithValue("@sThoiluong", phimEntity.sThoiluong);
                    cmd.Parameters.AddWithValue("@dNgaykhoichieu", phimEntity.dNgaykhoichieu);
                    cmd.Parameters.AddWithValue("@sDaodien", phimEntity.sDaodien);
                    cmd.Parameters.AddWithValue("@sDienvien", phimEntity.sDienvien);
                    cmd.Parameters.AddWithValue("@sMota", phimEntity.sMota);
                    cmd.Parameters.AddWithValue("@sNgonngu", phimEntity.sNgonngu);
                    cmd.Parameters.AddWithValue("@sAnh", phimEntity.sAnh);
                    long IDPhim = Convert.ToInt64(cmd.ExecuteScalar());
                    cnn.Close();
                    return IDPhim;
                }
            }
        }
        public bool Suaphim(PhimEntity phimEntity)
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spPhim_Update", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PK_iPhimID", phimEntity.PK_iPhimID);
                    cmd.Parameters.AddWithValue("@sTenphim", phimEntity.sTenphim);
                    cmd.Parameters.AddWithValue("@sThoiluong", phimEntity.sThoiluong);
                    cmd.Parameters.AddWithValue("@dNgaykhoichieu", phimEntity.dNgaykhoichieu);
                    cmd.Parameters.AddWithValue("@sDaodien", phimEntity.sDaodien);
                    cmd.Parameters.AddWithValue("@sDienvien", phimEntity.sDienvien);
                    cmd.Parameters.AddWithValue("@sMota", phimEntity.sMota);
                    cmd.Parameters.AddWithValue("@sNgonngu", phimEntity.sNgonngu);
                    cmd.Parameters.AddWithValue("@sAnh", phimEntity.sAnh);
                    long i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    if (i > 0)
                        return true;
                    else
                        return false;
                }
            }
        }
        public bool deleteKhachhang(PhimEntity phimEntity)
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spPhim", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PK_iPhimID", phimEntity.PK_iPhimID);
                    long i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    if (i > 0)
                        return true;
                    else
                        return false;
                }

            }
        }
        public List<PhimEntity> Hienthiphimsapchieu()
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                List<PhimEntity> glstPhim = new List<PhimEntity>();
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spPhim_GetAll", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            PhimEntity phimEntity = new PhimEntity();
                            phimEntity.PK_iPhimID = Convert.ToInt32(rd["PK_iPhimID"]);
                            phimEntity.sTenphim = rd["sTenphim"].ToString();
                            phimEntity.sThoiluong = rd["sThoiluong"].ToString();
                            phimEntity.dNgaykhoichieu = Convert.ToDateTime(rd["dNgaykhoichieu"]);
                            phimEntity.sDaodien = rd["sDaodien"].ToString();
                            phimEntity.sDienvien = rd["sDienvien"].ToString();
                            phimEntity.sMota = rd["sMota"].ToString();
                            phimEntity.sNgonngu = rd["sNgonngu"].ToString();
                            phimEntity.sAnh = rd["sAnh"].ToString();
                            glstPhim.Add(phimEntity);
                        }
                    }
                }
                cnn.Close();
                return glstPhim;
            }
        }
        public List<PhimEntity> TimkiemphimtheoID(long PK_iPhimID)
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                List<PhimEntity> glstPhim = new List<PhimEntity>();
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spPhim_GetAll", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PK_iPhimID", PK_iPhimID);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            PhimEntity phimEntity = new PhimEntity();
                            phimEntity.PK_iPhimID = Convert.ToInt32(rd["PK_iPhimID"]);
                            phimEntity.sTenphim = rd["sTenphim"].ToString();
                            phimEntity.sThoiluong = rd["sThoiluong"].ToString();
                            phimEntity.dNgaykhoichieu = Convert.ToDateTime(rd["dNgaykhoichieu"]);
                            phimEntity.sDaodien = rd["sDaodien"].ToString();
                            phimEntity.sDienvien = rd["sDienvien"].ToString();
                            phimEntity.sMota = rd["sMota"].ToString();
                            phimEntity.sNgonngu = rd["sNgonngu"].ToString();
                            phimEntity.sAnh = rd["sAnh"].ToString();
                            glstPhim.Add(phimEntity);
                        }
                    }
                }
                cnn.Close();
                return glstPhim;
            }
        }
    }
}
