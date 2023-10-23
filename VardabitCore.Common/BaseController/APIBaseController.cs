using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VardabitCore.Common.BaseController
{
        [Authorize]
        [ApiController]
        [Route("[controller]/[action]")]
        public class APIBaseController : ControllerBase
        {
        }
}