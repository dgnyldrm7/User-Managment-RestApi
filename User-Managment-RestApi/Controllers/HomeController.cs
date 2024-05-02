using Microsoft.AspNetCore.Mvc;

namespace User_Managment_RestApi.Controllers
{

    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        
        //Links are here
        public Dictionary<string, string> myDictionary = new Dictionary<string, string>()
        {
            {"Users" , "https://localhost:7022/api/GetUsers/" },
            {"Roles" , "https://localhost:7022/api/GetRoles/"}

        };

        [HttpGet]
        public Dictionary<string , string> GetList()
        {
            return myDictionary;
        }

    }
}
