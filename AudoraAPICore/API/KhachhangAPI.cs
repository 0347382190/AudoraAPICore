using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
//using System.Web.Http;
using AudoraAPICore.DAL;
using AudoraAPICore.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AudoraAPICore.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachhangAPI : ControllerBase
    {
        // GET: api/<KhachhangAPI>
        [HttpGet]
        public List<KhachhangEntity> GetAll()
        {
            List<KhachhangEntity> lstKhachhang = new List<KhachhangEntity>();
            KhachhangDAL khachhangDAL = new KhachhangDAL();
            lstKhachhang = khachhangDAL.Danhsachkhachhang();
            return lstKhachhang;
        }

        // GET api/<KhachhangAPI>/5
        [HttpGet("{id}")]
        public List<KhachhangEntity> Get(string PK_sSodienthoai)
        {
            KhachhangDAL khachhangDAL = new KhachhangDAL();
            //return "";
            return khachhangDAL.Timkiemkhachhang(PK_sSodienthoai);
        }

        // POST api/<KhachhangAPI>
        [HttpPost]
        public void Post([FromBody] KhachhangEntity khachhangEntity)
        {
            KhachhangDAL khachhangDAL = new KhachhangDAL();
            khachhangDAL.Themkhachhang(khachhangEntity);
        }

        // PUT api/<KhachhangAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] KhachhangEntity khachhangEntity)
        {
            KhachhangDAL khachhangDAL = new KhachhangDAL();
            khachhangDAL.Suakhachhang(khachhangEntity);
        }

        // DELETE api/<KhachhangAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
