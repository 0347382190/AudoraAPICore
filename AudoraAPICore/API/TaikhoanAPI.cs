using AudoraAPICore.DAL;
using AudoraAPICore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AudoraAPICore.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaikhoanAPI : ControllerBase
    {
        TaikhoanDAL taikhoanDAL = new TaikhoanDAL();
        // GET: api/<TaikhoanAPI>
        [HttpGet("{sEmail}/{sMatkhau}")]
        //[RequireHttps]
        public string login()
        {

            // Lấy tiêu đề Authorization từ yêu cầu HTTP
            string authHeader = Request.Headers["Authorization"];

            // Nếu tiêu đề Authorization không tồn tại hoặc không bắt đầu bằng "Basic", trả về mã trạng thái 401 Unauthorized
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Basic "))
            {
                Response.Headers["WWW-Authenticate"] = "Basic";
                // return (int)HttpStatusCode.Unauthorized;
            }
            // Giải mã chuỗi thông tin xác thực
            string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
            byte[] decodedBytes = Convert.FromBase64String(encodedUsernamePassword);
            string[] usernamePassword = Encoding.UTF8.GetString(decodedBytes).Split(':');
            string username = usernamePassword[0];
            string password = usernamePassword[1];

            // Kiểm tra tên đăng nhập và mật khẩu trong cơ sở dữ liệu hoặc các phương tiện lưu trữ khác
            bool isAuthenticated = taikhoanDAL.LoginTaikhoan(username, password)!=null?true:false;
            if (isAuthenticated == true)
            {
                 return username;
            }
            return "sai rồi";
        }
    }
   
}

