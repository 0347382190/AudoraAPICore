using System;

namespace AudoraAPICore.Models
{
    public class HoadonEnity
    {
        private long m_iHoadonID;
        private DateTime m_dNgaylap;
        private string m_FK_sSodienthoai;
        private string m_FK_sCCCD;

        public long IHoadonID { get => m_iHoadonID; set => m_iHoadonID = value; }
        public DateTime DNgaylap { get => m_dNgaylap; set => m_dNgaylap = value; }
        public string FK_sSodienthoai { get => m_FK_sSodienthoai; set => m_FK_sSodienthoai = value; }
        public string FK_sCCCD { get => m_FK_sCCCD; set => m_FK_sCCCD = value; }
    }
}
