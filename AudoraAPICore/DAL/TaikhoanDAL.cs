using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.IO;
using AudoraAPICore.Models;
using System.Data;

namespace AudoraAPICore.DAL
{
    public class TaikhoanDAL
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
        public bool LoginTaikhoan(string sEMail, string sMatkhau)
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spTaikhoan_Check", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sEmail", sEMail);
                    cmd.Parameters.AddWithValue("@sMatkhau", sMatkhau);
                    SqlDataReader dt= cmd.ExecuteReader();
                    return dt.HasRows;
                }
            }

        }
    }
}
