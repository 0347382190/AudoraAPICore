using AudoraAPICore.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System;

namespace AudoraAPICore.DAL
{
    public class LichchieuDAL
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

        public List<LichchieuEntity> Hienthidanhsachlichchieuphim(int FK_iPhim)
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                List<LichchieuEntity> glstPhim = new List<LichchieuEntity>();
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spLichchieu_GetbyFK_iPhimID", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FK_iPhimID", FK_iPhim);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            LichchieuEntity LichchieuEntity = new LichchieuEntity();
                            LichchieuEntity.PK_iLichchieuID = Convert.ToInt32(rd["PK_iLichchieuID"]);
                            LichchieuEntity.FK_iPhongchieuID = Convert.ToInt32(rd["FK_iPhongchieuID"]);
                            LichchieuEntity.FK_iPhimID = Convert.ToInt32(rd["FK_iPhimID"]);
                            LichchieuEntity.tNgaybatdau = Convert.ToDateTime(rd["tNgaybatdau"]);
                            LichchieuEntity.hGiochieu = Convert.ToString(rd["hGiochieu"]);
                            glstPhim.Add(LichchieuEntity);
                        }
                    }
                }
                cnn.Close();
                return glstPhim;
            }
        }
    }
}
