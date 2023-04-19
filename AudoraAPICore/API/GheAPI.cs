using AudoraAPICore.DAL;
using AudoraAPICore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AudoraAPICore.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class GheAPI : ControllerBase
    {
        // GET api/<GheAPI>/5
        [HttpGet("{igiochieu}/{dNgaychieu}/{phongchieuID}")]
        public IEnumerable<GheEntity> Get(int giochieu, DateTime ngaychieu, int FK_iPhongchieuID)
        {
            IEnumerable<GheEntity> lstGhe;
            GheDAL GheDAL = new GheDAL();
            lstGhe = GheDAL.Hienthidanhsachghetheongaygio(giochieu, ngaychieu, FK_iPhongchieuID);
            return lstGhe;
        }
        [HttpGet("getghebyphongchieu")]
        public IEnumerable<GheEntity> getghebyphongchieu(int FK_iPhongchieuID)
        {
            IEnumerable<GheEntity> lstGhe;
            GheDAL GheDAL = new GheDAL();
            lstGhe = GheDAL.Hienthidanhsachghetheophongchieu( FK_iPhongchieuID);
            return lstGhe;
        }
        [HttpGet("bookSticker")]
        public bool bookSticker(/*int FK_iPhimID,*/int PK_Ghe, string sSoDienThoai, int PK_iPhongchieuID)
        {
            GheDAL GheDAL = new GheDAL();
            return GheDAL.DatVe(/*FK_iPhimID,*/PK_Ghe, sSoDienThoai, PK_iPhongchieuID);
        }
        [HttpGet("GetAllHD")]
        public List<HoadonEntity> GetAllHD( string sSoDienThoai)
        {
            List<HoadonEntity> lstHoadon;
            GheDAL GheDAL = new GheDAL();
            lstHoadon = GheDAL.getAllHoadon( sSoDienThoai);
            return lstHoadon;
        }

        [HttpGet("Payments")]
        public bool Payments(string sSoDienThoai)
        {
            GheDAL GheDAL = new GheDAL();
            return GheDAL.Thanhtoan( sSoDienThoai);
        }

        // POST api/<GheAPI>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GheAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GheAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
