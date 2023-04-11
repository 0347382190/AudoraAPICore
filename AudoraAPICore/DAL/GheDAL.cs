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
        public List<GheEntity> Hienthidanhsachlichchieuphim(int FK_iPhongchieuID)
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                List<GheEntity> glstPhim = new List<GheEntity>();
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spGhe_GetbyPhongChieu", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FK_iPhongchieuID", FK_iPhongchieuID);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            GheEntity GheEntity = new GheEntity();
                            GheEntity.PK_iGheID = Convert.ToInt32(rd["PK_iGheID"]);
                            GheEntity.iDay = Convert.ToInt32( rd["sDay"]);
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
    }
}
