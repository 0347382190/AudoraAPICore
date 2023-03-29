using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AudoraAPICore.DAL;
using AudoraAPICore.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AudoraAPICore.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhimAPI : ControllerBase
    {
        // GET: api/<PhimAPI>
        [HttpGet]
        public string GetAll()
        {
            List<PhimEntity> lstPhim = new List<PhimEntity>();
            PhimDAL phimDAL = new PhimDAL();
            lstPhim = phimDAL.Hienthidanhsachphim();            
            return lstPhim;
        }
        public string GetPhimCommingsoon()
        {
            List<PhimEntity> lstPhim = new List<PhimEntity>();
            PhimDAL phimDAL = new PhimDAL();
            lstPhim = phimDAL.Hienthiphimsapchieu();
            return lstPhim;

        }
        // GET api/<PhimAPI>/5
        [HttpGet("{id}")]
        public string GetPhimbyID(long PK_iPhimID)
        {
            PhimDAL phimDAL = new PhimDAL();
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
        public void Delete(int id)
        {
            UserDAL userDAL = new UserDAL();
            userDAL.DeleteUser(id);
        }
    }
}
