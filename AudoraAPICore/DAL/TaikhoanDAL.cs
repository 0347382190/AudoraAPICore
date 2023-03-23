using Microsoft.Extensions.Configuration;
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
        public void LoginTaikhoan()
        {
            using (SqlConnection cnn = new SqlConnection(GetconnectString()))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("",cnn))
                {

                }
            }
        }
       
    }
}
