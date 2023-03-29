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

    }
}
