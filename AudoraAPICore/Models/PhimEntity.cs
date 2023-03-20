/*
 *Name:PhimEntity.cs
 *03/20/2023: Nguyễn Thị Thu Hoài
 *DESC: Create
 */
namespace AudoraAPICore.Models
{
    public class PhimEntity
    {
        private int m_PK_iPhimID;
        private string m_sTenphim;
        private string m_sThoiluong;
        private string m_dNgaykhoichieu;
        private string m_sDaodien;
        private string m_sDienvien;
        private string m_sMota;
        private string m_sNgonngu;
        private string m_sAnh;

        public int PK_iPhimID { get => m_PK_iPhimID; set => m_PK_iPhimID = value; }
        public string sTenphim { get => m_sTenphim; set => m_sTenphim = value; }
        public string sThoiluong { get => m_sThoiluong; set => m_sThoiluong = value; }
        public string dNgaykhoichieu { get => m_dNgaykhoichieu; set => m_dNgaykhoichieu = value; }
        public string sDaodien { get => m_sDaodien; set => m_sDaodien = value; }
        public string sDienvien { get => m_sDienvien; set => m_sDienvien = value; }
        public string sMota { get => m_sMota; set => m_sMota = value; }
        public string sNgonngu { get => m_sNgonngu; set => m_sNgonngu = value; }
        public string sAnh { get => m_sAnh; set => m_sAnh = value; }
    }
}
