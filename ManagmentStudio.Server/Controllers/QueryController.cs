using ManagmentStudio.Server.Services;
using ManagmentStudio.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ManagmentStudio.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class QueryController : ControllerBase
    {
        private readonly IQueryService _queryService;

        public QueryController(IQueryService queryService)
        {
            this._queryService = queryService;
        }

        [HttpGet("{conType}")]
        public async Task<IActionResult> GetQueries(string conType)
        {
            var resault = await _queryService.GetQueries(conType);
            return Ok(resault);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuery(int id)
        {
            var resault = await _queryService.GetQuery(id);
            return Ok(resault);
        }

        [HttpGet("{name}/{conType}")]
        public async Task<IActionResult> CheckName(string name, string conType)
        {
            var resault =await _queryService.CheckName(name, conType);
            return Ok(resault);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuery([FromBody]Query query)
        {
            var resault =await _queryService.Create(query);
            return Ok(resault);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuery(int id)
        {
            await _queryService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuery([FromBody]Query query)
        {
            await _queryService.UpdateQuery(query);
            return Ok();
        }
    }
}
