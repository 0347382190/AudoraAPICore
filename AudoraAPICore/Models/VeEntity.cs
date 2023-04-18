/*
 *Name:VeEntity.cs
 *03/20/2023: Nguyễn Thị Thu Hoài
 *DESC: Create
 */
namespace AudoraAPICore.Models
{
    public class VeEntity
    {
        private int m_PK_iVeID;
        private string m_FK_HoadonID;
        private int m_FK_iGheID;
        private int m_FK_iPhongchieuID;
        private string m_sTenphim;
        public int PK_iVeID { get => m_PK_iVeID; set => m_PK_iVeID = value; }
        public string FK_HoadonID { get => m_FK_HoadonID; set => m_FK_HoadonID = value; }
        public int FK_iGheID { get => m_FK_iGheID; set => m_FK_iGheID = value; }
        public int FK_iPhongchieuID { get => m_FK_iPhongchieuID; set => m_FK_iPhongchieuID = value; }
        public string sTenphim { get => m_sTenphim; set => m_sTenphim = value; }
    }
}
