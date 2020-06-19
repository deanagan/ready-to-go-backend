using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckListController : ControllerBase
    {

        private readonly ILogger<CheckListController> _logger;

        public CheckListController(ILogger<CheckListController> logger)
        {
            _logger = logger;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllLists()
        {
            return Ok();
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetList(int id)
        {
            return Ok();
        }
    }
}
