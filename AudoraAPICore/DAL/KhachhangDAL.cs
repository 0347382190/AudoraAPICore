using AudoraAPICore.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace AudoraAPICore.DAL
{
    public class KhachhangDAL
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
        public List<KhachhangEntity> Danhsachkhachhang()
        {
            List<KhachhangEntity> glstKhachhang = new List<KhachhangEntity>();
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spKhachang_GetALL", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            KhachhangEntity khachhangEntity = new KhachhangEntity();
                            khachhangEntity.PK_sSodienthoai = rd["PK_sSodienthoai"].ToString();
                            khachhangEntity.sHoten = rd["sTen"].ToString();
                            khachhangEntity.dNgaysinh = Convert.ToDateTime(rd["dNgaysinh"]);                            
                            khachhangEntity.bGioitinh = Convert.ToBoolean(rd["bGioitinh"]);                            
                            khachhangEntity.sDiachi = rd["sDiachi"].ToString();
                            khachhangEntity.sAnh = rd["sAnh"].ToString();
                            glstKhachhang.Add(khachhangEntity);
                        }
                    }
                }
                cnn.Close();
            }
            return glstKhachhang;
        }
        public List<KhachhangEntity> Timkiemkhachhang(long PK_sSodienthoai)
        {
            List<KhachhangEntity> glstKhachhang = new List<KhachhangEntity>();
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spKhachhang_GetbyPK", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PK_sSodienthoai", PK_sSodienthoai);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            KhachhangEntity khachhangEntity = new KhachhangEntity();
                            khachhangEntity.PK_sSodienthoai = rd["PK_sSodienthoai"].ToString();
                            khachhangEntity.sHoten = rd["sHoten"].ToString();
                            khachhangEntity.dNgaysinh = Convert.ToDateTime(rd["dNgaysinh"]);
                            khachhangEntity.bGioitinh = Convert.ToBoolean(rd["bGioitinh"]);
                            khachhangEntity.sDiachi = rd["sDiachi"].ToString();
                            khachhangEntity.sAnh = rd["sAnh"].ToString();
                            glstKhachhang.Add(khachhangEntity);
                        }
                    }
                }
                cnn.Close();
            }
            return glstKhachhang;
        }
        public long Themkhachhang(KhachhangEntity khachhangEntity)
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spKhachhang_Insert", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PK_sSodienthoai", khachhangEntity.PK_sSodienthoai);
                    cmd.Parameters.AddWithValue("@sHoten", khachhangEntity.sHoten);
                    cmd.Parameters.AddWithValue("@dNgaysinh", khachhangEntity.dNgaysinh);
                    cmd.Parameters.AddWithValue("@bGioitinh", khachhangEntity.bGioitinh);
                    cmd.Parameters.AddWithValue("@sDiachi", khachhangEntity.sDiachi);
                    cmd.Parameters.AddWithValue("@sAnh", khachhangEntity.sAnh);
                    long IDKhachhang = Convert.ToInt64(cmd.ExecuteScalar());
                    cnn.Close();
                    return IDKhachhang;
                }
            }
        }
        public bool Suakhachhang(KhachhangEntity khachhangEntity)
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spKhachhang_Update", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PK_sSodienthoai", khachhangEntity.PK_sSodienthoai);
                    cmd.Parameters.AddWithValue("@sHoten", khachhangEntity.sHoten);
                    cmd.Parameters.AddWithValue("@dNgaysinh", khachhangEntity.dNgaysinh);
                    cmd.Parameters.AddWithValue("@bGioitinh", khachhangEntity.bGioitinh);
                    cmd.Parameters.AddWithValue("@sDiachi", khachhangEntity.sDiachi);
                    cmd.Parameters.AddWithValue("@sAnh", khachhangEntity.sAnh);
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
