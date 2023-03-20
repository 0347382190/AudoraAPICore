/*
 *Name:TaikhoanEntity.cs
 *03/20/2023: Nguyễn Thị Thu Hoài
 *DESC: Create
 */
namespace AudoraAPICore.Models
{
    public class TaikhoanEntity
    {
        private int m_PK_iTaikhoanID;
        private string m_sPhanquyen;
        private string m_sMatkhau;
        private string m_sEmail;

        public int PK_iTaikhoanID { get => m_PK_iTaikhoanID; set => m_PK_iTaikhoanID = value; }
        public string sPhanquyen { get => m_sPhanquyen; set => m_sPhanquyen = value; }
        public string sMatkhau { get => m_sMatkhau; set => m_sMatkhau = value; }
        public string sEmail { get => m_sEmail; set => m_sEmail = value; }
    }
}
