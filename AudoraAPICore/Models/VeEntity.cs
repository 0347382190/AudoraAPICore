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
        private int m_FK_iHoadonID;
        private int m_FK_iGheID;

        public int PK_iVeID { get => m_PK_iVeID; set => m_PK_iVeID = value; }
        public int FK_iHoadonID { get => m_FK_iHoadonID; set => m_FK_iHoadonID = value; }
        public int FK_iGheID { get => m_FK_iGheID; set => m_FK_iGheID = value; }
    }
}
