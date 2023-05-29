using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Business.Abstract;
using Pharmacy.Core.CriteriaObjects.Bases;
using Pharmacy.Core.DataTransferObjects;

namespace Pharmacy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpPost("getLogPagedList")]
        public async Task<ActionResult<RequestResult<PagedResult>>> GetLogPagedList(PagedCriteriaObject pagedCriteria)
        {
            return await _logService.PagedListAsync(x => x.Id>0, pagedCriteria);
        }
    }
}
