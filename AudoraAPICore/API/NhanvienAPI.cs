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
    public class NhanvienAPI : ControllerBase
    {
        // GET: api/<NhanvienAPI>
        [HttpGet]
        public List<NhanvienEntity> GetAll()
        {
            List<NhanvienEntity> lstNhanvien = new List<NhanvienEntity>();
            NhanvienDAL nhanvienDAL = new NhanvienDAL();
            lstNhanvien = nhanvienDAL.Danhsachnhanvien();
            return lstNhanvien;
        }

        // GET api/<NhanvienAPI>/5
        [HttpGet("{id}")]
        public List<NhanvienEntity> Get(string PK_sCCCD)
        {
            NhanvienDAL nhanvienDAL = new NhanvienDAL();
            //return "";
            return nhanvienDAL.Timkiemnhanvien(PK_sCCCD);
        }

        // POST api/<NhanvienAPI>
        [HttpPost]
        public void Post([FromBody] NhanvienEntity nhanvienEntity)
        {
            NhanvienDAL nhanvienDAL = new NhanvienDAL();
            nhanvienDAL.Themnhanvien(nhanvienEntity);
        }


        // PUT api/<NhanvienAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] NhanvienEntity nhanvienEntity)
        {
            NhanvienDAL nhanvienDAL = new NhanvienDAL();
            nhanvienDAL.Themnhanvien(nhanvienEntity);
        }

        // DELETE api/<NhanvienAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
