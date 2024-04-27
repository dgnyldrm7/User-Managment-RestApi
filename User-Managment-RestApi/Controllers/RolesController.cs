using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace User_Managment_RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        [HttpGet]
        public string GetRoles()
        {
            string message = "Roles list are here!";

            return message;
        }
    }
}
