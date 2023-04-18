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
    public class PhimAPI : ControllerBase
    {
        // GET: api/<PhimAPI>
      //  [RequireHttps]
        [HttpGet("GetAll")]
        public List<PhimEntity> GetAll()
        {
            List<PhimEntity> lstPhim = new List<PhimEntity>();
            PhimDAL phimDAL = new PhimDAL();
            lstPhim = phimDAL.Hienthidanhsachphim();

            return lstPhim;
        }
        [HttpGet("GetPhimCommingsoon")]
        public List<PhimEntity> GetPhimCommingsoon()
        {
            List<PhimEntity> lstPhim = new List<PhimEntity>();
            PhimDAL phimDAL = new PhimDAL();
            lstPhim = phimDAL.Hienthiphimsapchieu();
            return lstPhim;
        }
        // GET api/<PhimAPI>/5
        [HttpGet("{id}")]
        public PhimEntity GetPhimbyID(long PK_iPhimID)
        {
            PhimDAL phimDAL = new PhimDAL();
            //return "";
            return phimDAL.TimkiemphimtheoID(PK_iPhimID);
        }
        // POST api/<PhimAPI>
        [HttpPost]
        public void Post([FromBody] PhimEntity phimEntity)
        {
            PhimDAL phimDAL = new PhimDAL();
            phimDAL.Themphim(phimEntity);
        }

        // PUT api/<PhimAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PhimEntity phimEntity)
        {
            PhimDAL phimDAL = new PhimDAL();
            phimDAL.Suaphim(phimEntity);
        }

        // DELETE api/<PhimAPI>/5
        [HttpDelete("{id}")]
        public void Delete(long PK_iPhimID)
        {
             PhimDAL phimDAL = new PhimDAL();
            phimDAL.Xoaphim(PK_iPhimID);
        }
    }
}
