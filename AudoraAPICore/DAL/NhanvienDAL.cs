using AudoraAPICore.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using System.IO;

namespace AudoraAPICore.DAL
{
    public class NhanvienDAL
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
        public List<NhanvienEntity> Danhsachnhanvien()
        {
            List<NhanvienEntity> glstNhanvien = new List<NhanvienEntity>();
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spNhanvien_GetAll", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            NhanvienEntity nhanvienEntity = new NhanvienEntity();
                            nhanvienEntity.PK_sCCCD = rd["PK_sCCCD"].ToString();
                            nhanvienEntity.sHoten = rd["sHoten"].ToString();
                            nhanvienEntity.sSodienthoai = rd["sSodienthoai"].ToString();
                            nhanvienEntity.dNgaysinh = Convert.ToDateTime(rd["dNgaysinh"]);
                            nhanvienEntity.bGioitinh = Convert.ToBoolean(rd["bGioitinh"]);
                            nhanvienEntity.sDiachi = rd["sDiachi"].ToString();
                            nhanvienEntity.sAnh = rd["sAnh"].ToString();
                            glstNhanvien.Add(nhanvienEntity);
                        }
                    }
                }
                cnn.Close();
            }
            return glstNhanvien;
        }
        public List<NhanvienEntity> Timkiemnhanvien(long PK_sCCCD)
        {
            List<NhanvienEntity> glstNhanvien = new List<NhanvienEntity>();
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spNhanvien_GetbyPK", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PK_sCCCD", PK_sCCCD);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            NhanvienEntity nhanvienEntity = new NhanvienEntity();
                            nhanvienEntity.PK_sCCCD = rd["PK_sCCCD"].ToString();
                            nhanvienEntity.sHoten = rd["sHoten"].ToString();
                            nhanvienEntity.sSodienthoai = rd["sSodienthoai"].ToString();
                            nhanvienEntity.dNgaysinh = Convert.ToDateTime(rd["dNgaysinh"]);
                            nhanvienEntity.bGioitinh = Convert.ToBoolean(rd["bGioitinh"]);
                            nhanvienEntity.sDiachi = rd["sDiachi"].ToString();
                            nhanvienEntity.sAnh = rd["sAnh"].ToString();
                            glstNhanvien.Add(nhanvienEntity);
                        }
                    }
                }
                cnn.Close();
            }
            return glstNhanvien;
        }
        public long Themnhanvien(NhanvienEntity nhanvienEntity)
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spNhanvien_Insert", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PK_sCCCD", nhanvienEntity.PK_sCCCD);
                    cmd.Parameters.AddWithValue("@sHoten", nhanvienEntity.sHoten);
                    cmd.Parameters.AddWithValue("@sSodienthoai", nhanvienEntity.sSodienthoai);
                    cmd.Parameters.AddWithValue("@dNgaysinh", nhanvienEntity.dNgaysinh);
                    cmd.Parameters.AddWithValue("@bGioitinh", nhanvienEntity.bGioitinh);
                    cmd.Parameters.AddWithValue("@sDiachi", nhanvienEntity.sDiachi);
                    cmd.Parameters.AddWithValue("@sAnh", nhanvienEntity.sAnh);
                    long IDNhanvien = Convert.ToInt64(cmd.ExecuteScalar());
                    cnn.Close();
                    return IDNhanvien;
                }
            }
        }
        public bool Suanhanvien(NhanvienEntity nhanvienEntity)
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spNhanvien_Update", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PK_sCCCD", nhanvienEntity.PK_sCCCD);
                    cmd.Parameters.AddWithValue("@sHoten", nhanvienEntity.sHoten);
                    cmd.Parameters.AddWithValue("@sSodienthoai", nhanvienEntity.sSodienthoai);
                    cmd.Parameters.AddWithValue("@dNgaysinh", nhanvienEntity.dNgaysinh);
                    cmd.Parameters.AddWithValue("@bGioitinh", nhanvienEntity.bGioitinh);
                    cmd.Parameters.AddWithValue("@sDiachi", nhanvienEntity.sDiachi);
                    cmd.Parameters.AddWithValue("@sAnh", nhanvienEntity.sAnh);
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
