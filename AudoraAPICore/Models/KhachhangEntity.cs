/*
 *Name:KhachhangEntity.cs
 *03/23/2023: Nguyễn Hồng Ngọc
 *DESC: Create
 *DB thiếu thông tin mail của khách hàng
 */
using System;

namespace AudoraAPICore.Models
{
    public class KhachhangEntity
    {
        private string m_PK_sSodienthoai;
        private string m_sHoten;
        private DateTime m_dNgaysinh;
        private bool m_bGioitinh;
        private string m_sDiachi;
        private string m_sAnh;

        public string PK_sSodienthoai { get => m_PK_sSodienthoai; set => m_PK_sSodienthoai = value; }
        public string sHoten { get => m_sHoten; set => m_sHoten = value; }
        public DateTime dNgaysinh { get => m_dNgaysinh; set => m_dNgaysinh = value; }
        public bool bGioitinh { get => m_bGioitinh; set => m_bGioitinh = value; }
        public string sDiachi { get => m_sDiachi; set => m_sDiachi = value; }
        public string sAnh { get => m_sAnh; set => m_sAnh = value; }
        
    }
}
