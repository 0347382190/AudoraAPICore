/*
 *Name:NhanvienEntity.cs
 *03/20/2023: Nguyễn Thị Thu Hoài
 *DESC: Create
 */
using System;

namespace AudoraAPICore.Models
{
    public class NhanvienEntity
    {
        private string m_PK_sCCCD;
        private string m_sHoten;
        private string m_sSodienthoai;
        private DateTime m_dNgaysinh;
        private Boolean m_bGioitinh;
        private string m_sDiachi;
        private string m_sAnh;

        public string PK_sCCCD { get => m_PK_sCCCD; set => m_PK_sCCCD = value; }
        public string sHoten { get => m_sHoten; set => m_sHoten = value; }
        public string sSodienthoai { get => m_sSodienthoai; set => m_sSodienthoai = value; }
        public DateTime dNgaysinh { get => m_dNgaysinh; set => m_dNgaysinh = value; }
        public Boolean bGioitinh { get => m_bGioitinh; set => m_bGioitinh = value; }
        public string sDiachi { get => m_sDiachi; set => m_sDiachi = value; }
        public string sAnh { get => m_sAnh; set => m_sAnh = value; }
    }
}
