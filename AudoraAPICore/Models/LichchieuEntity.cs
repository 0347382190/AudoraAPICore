/*
 *Name:LichchieuEntity.cs
 *03/23/2023: Nguyễn Hồng Ngọc
 *DESC: Create
 */
using System;
using System.Threading;

namespace AudoraAPICore.Models
{
    public class LichchieuEntity
    {
        private long m_PK_iLichchieuID;
        private long m_FK_iPhongchieuID;
        private long m_FK_iVeID;
        private long m_FK_iPhim;
        private DateTime m_tGiobatdau;

        public long PK_iLichchieuID { get => m_PK_iLichchieuID; set => m_PK_iLichchieuID = value; }
        public long FK_iPhongchieuID { get => m_FK_iPhongchieuID; set => m_FK_iPhongchieuID = value; }
        public long FK_iVeID { get => m_FK_iVeID; set => m_FK_iVeID = value; }
        public long FK_iPhim { get => m_FK_iPhim; set => m_FK_iPhim = value; }
        public DateTime TGiobatdau { get => m_tGiobatdau; set => m_tGiobatdau = value; }
    }
}
