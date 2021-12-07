namespace _57BlocksApiRest.Controllers
{
    using _57BlocksApiRest.BL;
    using _57BlocksApiRest.Entities;
    using System.Net;
    using System.Threading;
    ///using System.Web.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {

        [HttpGet]
        [Route("echoping")]
        public ActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public ActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("Authenticate")]
        public ActionResult Authenticate(LoginRequest login)
        {
            if (login == null)
                throw new Exception(HttpStatusCode.BadRequest.ToString());

            bool isCredentialValid = (Seguridad._Autenticacion(login));
            if (isCredentialValid)
            {
                Configuration_ config = new Configuration_();
                config.JWT_SECRET_KEY = "rosOsewLfic3iwAstubrIthIMIsTIcRe";
                config.JWT_AUDIENCE_TOKEN = "https://localhost:44319";
                config.JWT_ISSUER_TOKEN = "https://localhost:44319";
                config.JWT_EXPIRE_MINUTES = 30.ToString();

                var token = TokenGenerator.GenerateTokenJwt(login.email, config);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}
