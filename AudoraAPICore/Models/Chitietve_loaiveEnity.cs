/*
 *Name:Chitietve_loaiveEnity.cs
 *03/23/2023: Nguyễn Hồng Ngọc
 *DESC: Create
 */
using System;

namespace AudoraAPICore.Models
{
    public class Chitietve_loaiveEnity
    {
        private long m_PKChitietve_loaiveID;
        private long m_FK_iVeID;
        private long m_FK_iLoaiveID;
        private DateTime m_dNgayban;

        public long PKChitietve_loaiveID { get => m_PKChitietve_loaiveID; set => m_PKChitietve_loaiveID = value; }
        public long FK_iVeID { get => m_FK_iVeID; set => m_FK_iVeID = value; }
        public long FK_iLoaiveID { get => m_FK_iLoaiveID; set => m_FK_iLoaiveID = value; }
        public DateTime dNgayban { get => m_dNgayban; set => m_dNgayban = value; }
    }
}
