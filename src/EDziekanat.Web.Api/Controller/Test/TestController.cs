using Microsoft.AspNetCore.Mvc;
using EDziekanat.Web.Core.Controllers;

namespace EDziekanat.Web.Api.Controller.Test
{
    public class TestController : BaseController
    {
        [HttpGet("[action]")]
        public ObjectResult Get(string userNameOrEmail)
        {
            return Ok(new { TestMessage = "Test success!" });
        }
    }
}