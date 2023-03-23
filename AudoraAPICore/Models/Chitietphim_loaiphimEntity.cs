/*
 *Name:Chitietphim_loaiphimEntity.cs
 *03/23/2023: Nguyễn Hồng Ngọc
 *DESC: Create
 */

namespace AudoraAPICore.Models
{
    public class Chitietphim_loaiphimEntity
    {
        private long m_PK_iChitietphim_loaiphimID;
        private long m_FK_iPhimId;
        private long m_FK_iLoaiphimID;

        public long PK_iChitietphim_loaiphimID { get => m_PK_iChitietphim_loaiphimID; set => m_PK_iChitietphim_loaiphimID = value; }
        public long FK_iPhimId { get => m_FK_iPhimId; set => m_FK_iPhimId = value; }
        public long FK_iLoaiphimID { get => m_FK_iLoaiphimID; set => m_FK_iLoaiphimID = value; }
    }
}
