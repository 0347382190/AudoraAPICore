/*
 *Name:KhachhangEntity.cs
 *03/23/2023: Nguyễn Hồng Ngọc
 *DESC: Create
 */
using System;

namespace AudoraAPICore.Models
{
    public class KhachhangEntity
    {
        private string m_sSodienthoai;
        private string m_sHoten;
        private DateTime m_dNgaysinh;
        private bool m_bGioitinh;
        private string m_sDiachi;
        private string m_sAnh;

        public string SSodienthoai { get => m_sSodienthoai; set => m_sSodienthoai = value; }
        public string SHoten { get => m_sHoten; set => m_sHoten = value; }
        public DateTime DNgaysinh { get => m_dNgaysinh; set => m_dNgaysinh = value; }
        public bool BGioitinh { get => m_bGioitinh; set => m_bGioitinh = value; }
        public string SDiachi { get => m_sDiachi; set => m_sDiachi = value; }
        public string SAnh { get => m_sAnh; set => m_sAnh = value; }
    }
}
