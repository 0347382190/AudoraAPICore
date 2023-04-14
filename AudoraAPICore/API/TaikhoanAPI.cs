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
        //[RequireHttps]
        public string login(string sEmail, string sMatkhau)
        {
            TaikhoanDAL taikhoanDAL = new TaikhoanDAL();
            return taikhoanDAL.LoginTaikhoan(sEmail, sMatkhau);
        }
    }
}

