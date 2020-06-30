using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckListController : ControllerBase
    {
        private ICheckListService _checkListService;
        private readonly ILogger<CheckListController> _logger;

        public CheckListController(ILogger<CheckListController> logger, ICheckListService checkListService)
        {
            _logger = logger;
            _checkListService = checkListService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllLists()
        {
            try
            {
                return Ok(_checkListService.GetCheckLists());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetList(int id)
        {
            try
            {
                var result = _checkListService.GetCheckList(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
