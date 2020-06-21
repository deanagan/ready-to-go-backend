using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private ILogger<ItemController> _logger;
        public ItemController(ILogger<ItemController> logger)
        {
            _logger = logger;
        }


    }
}
