using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
//using System.Web.Http;
using AudoraAPICore.DAL;
using AudoraAPICore.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AudoraAPICore.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoadonAPI : ControllerBase
    {
        // GET: api/<HoadonAPI>
        [HttpGet]
        public List<HoadonEntity> GetAll()
        {
            List<HoadonEntity> lstHoadon = new List<HoadonEntity>();
            HoadonDAL hoadonDAL = new HoadonDAL();
            lstHoadon = hoadonDAL.Danhsachhoadon();
            return lstHoadon;
        }

        // GET api/<HoadonAPI>/5
        [HttpGet("{id}")]
        public List<HoadonEntity> Get(long PK_iHoadonID)
        {
            HoadonDAL hoadonDAL = new HoadonDAL();
            //return "";
            return hoadonDAL.Xemthongtinhoadon(PK_iHoadonID);
        }

        // POST api/<HoadonAPI>
        [HttpPost]
        public void Post([FromBody] HoadonEntity hoadonEntity)
        {
            HoadonDAL hoadonDAL = new HoadonDAL();
            hoadonDAL.Themthongtinhoadon(hoadonEntity);
        }

        // PUT api/<HoadonAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] HoadonEntity hoadonEntity)
        {
            HoadonDAL hoadonDAL = new HoadonDAL();
            hoadonDAL.Suathongtinhoadon(hoadonEntity);
        }

        // DELETE api/<HoadonAPI>/5
        [HttpDelete("{id}")]
        public void Delete(long PK_iHoadonID)
        {
            HoadonDAL hoadonDAL = new HoadonDAL();
            hoadonDAL.Xoahoadon(PK_iHoadonID);
        }
    }
}
