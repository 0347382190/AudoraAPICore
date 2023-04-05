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
    public class PhongchieuAPI : ControllerBase
    {
        // GET: api/<PhongchieuAPI>
        [HttpGet]
        public List<PhongchieuEntity> GetAll()
        {
            List<PhongchieuEntity> lstPhongchieu = new List<PhongchieuEntity>();
            PhongchieuDAL phongchieuDAL = new PhongchieuDAL();
            lstPhongchieu = phongchieuDAL.Danhsachphongchieu();
            return lstPhongchieu;
        }

        // GET api/<PhongchieuAPI>/5
        [HttpGet("{id}")]
        public List<PhongchieuEntity> Get(long PK_iPhongchieuID)
        {
            PhongchieuDAL phongchieuDAL = new PhongchieuDAL();
            //return "";
            return phongchieuDAL.Timkiemphongchieu(PK_iPhongchieuID);
        }

        // POST api/<PhongchieuAPI>
        [HttpPost]
        public void Post([FromBody] PhongchieuEntity phongchieuEntity)
        {
            PhongchieuDAL phongchieuDAL = new PhongchieuDAL();
            phongchieuDAL.Themphongchieu(phongchieuEntity);
        }

        // PUT api/<PhongchieuAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PhongchieuEntity phongchieuEntity)
        {
            PhongchieuDAL phongchieuDAL = new PhongchieuDAL();
            phongchieuDAL.Suaphongchieu(phongchieuEntity);
        }

        // DELETE api/<PhongchieuAPI>/5
        [HttpDelete("{id}")]
        public void Delete(long PK_iPhongchieuID)
        {
            PhongchieuDAL phongchieuDAL = new PhongchieuDAL();
            phongchieuDAL.Xoaphongchieu(PK_iPhongchieuID);
        }
    }
}
