using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;

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
        public string LoginTaikhoan(string sEMail, string sMatkhau)
        {
            String sSDT="";
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("spTaikhoan_Check", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sEmail", sEMail);
                    cmd.Parameters.AddWithValue("@sMatkhau", sMatkhau);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            sSDT = rd["FK_sSoDienThoai"].ToString();
                            //glstPhim.Add(phimEntity);
                        }
                      
                    }
                    return sSDT;
                }
            }

        }
    }
}
