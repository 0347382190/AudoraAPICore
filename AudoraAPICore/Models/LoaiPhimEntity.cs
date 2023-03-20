/*
 *Name:LoaiPhimEntity.cs
 *03/20/2023: Nguyễn Thị Thu Hoài
 *DESC: Create
 */
namespace AudoraAPICore.Models
{
    public class LoaiPhimEntity
    {
        private int m_PK_iLoaiphimID;
        private string m_sTenloaiphim;

        public int PK_iLoaiphimID { get => m_PK_iLoaiphimID; set => m_PK_iLoaiphimID = value; }
        public string sTenloaiphim { get => m_sTenloaiphim; set => m_sTenloaiphim = value; }
    }
}
