/*
 *Name:LoaiveEntity.cs
 *03/20/2023: Nguyễn Thị Thu Hoài
 *DESC: Create
 */
namespace AudoraAPICore.Models
{
    public class LoaiveEntity
    {
        private int m_PK_iLoaiveID;
        private string m_sTenloaive;
        private string m_fGiave;

        public int PK_iLoaiveID { get => m_PK_iLoaiveID; set => m_PK_iLoaiveID = value; }
        public string sTenloaive { get => m_sTenloaive; set => m_sTenloaive = value; }
        public string sGiave { get => m_fGiave; set => m_fGiave = value; }
    }
}
