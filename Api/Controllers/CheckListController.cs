using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api.Interfaces;
using Api.Data.Models;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("v1/readytogo/api")]
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
        public IActionResult CheckLists()
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
        public IActionResult CheckLists(int id)
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

        // TODO: async-await eventually
        [HttpPost("[action]")]
        public IActionResult CheckLists(CheckListView checkListView)
        {
            if (checkListView != null)
            {
                try
                {
                    _checkListService.CreateCheckList(checkListView);
                    // TODO: Because we use a view model approach, we may not have
                    // any id to pass
                    return CreatedAtAction(nameof(CheckListView), new { id = 1 }, checkListView);
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return BadRequest("Checklist creation failed.");

        }
    }
}
