/*
 *Name:GheEntity.cs
 *03/23/2023: Nguyễn Hồng Ngọc
 *DESC: Create
 */

namespace AudoraAPICore.Models
{
    public class GheEntity
    {
        private long m_PK_iGheID;
        private string m_sDay;
        private int m_iCot;
        private long m_FK_iPhongchieuID;
        private bool m_isTrangthai;

        public long PK_iGheID { get => m_PK_iGheID; set => m_PK_iGheID = value; }
        public string SDay { get => m_sDay; set => m_sDay = value; }
        public int ICot { get => m_iCot; set => m_iCot = value; }
        public long FK_iPhongchieuID { get => m_FK_iPhongchieuID; set => m_FK_iPhongchieuID = value; }
        public bool IsTrangthai { get => m_isTrangthai; set => m_isTrangthai = value; }
    }
}
