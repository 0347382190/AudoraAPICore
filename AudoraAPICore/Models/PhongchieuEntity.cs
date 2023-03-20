/*
 *Name:PhongchieuEntity.cs
 *03/20/2023: Nguyễn Thị Thu Hoài
 *DESC: Create
 */
namespace AudoraAPICore.Models
{
    public class PhongchieuEntity
    {
        private int m_PK_iPhongchieuID;
        private string m_sDay;
        private int m_iCot;
        private int m_iSoluong;
        private bool m_isTrangthai;

        public int PK_iPhongchieuID { get => m_PK_iPhongchieuID; set => m_PK_iPhongchieuID = value; }
        public string sDay { get => m_sDay; set => m_sDay = value; }
        public int sCot { get => m_iCot; set => m_iCot = value; }
        public int iSoluong { get => m_iSoluong; set => m_iSoluong = value; }
        public bool isTrangthai { get => m_isTrangthai; set => m_isTrangthai = value; }
    }
}
