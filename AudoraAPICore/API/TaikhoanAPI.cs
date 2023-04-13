using AudoraAPICore.DAL;
using AudoraAPICore.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AudoraAPICore.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaikhoanAPI : ControllerBase
    {
        // GET: api/<TaikhoanAPI>
        [HttpGet("{sEmail}/{sMatkhau}")]
        [RequireHttps]
        public string login(string sEmail, string sMatkhau)
        {
            TaikhoanDAL taikhoanDAL = new TaikhoanDAL();
            return taikhoanDAL.LoginTaikhoan(sEmail, sMatkhau);
        }
        // GET api/<TaikhoanAPI>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // POST api/<TaikhoanAPI>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TaikhoanAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TaikhoanAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

