using ManagmentStudio.Server.Factory;
using ManagmentStudio.Server.Factory.Interfice;
using ManagmentStudio.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ManagmentStudio.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ServerController : ControllerBase
    {
        private static IConnector? _connector;

        [HttpPost]
        public IActionResult CheckConnect([FromBody]ServerSet serverSet)
        {
            var connector = new ConnectorFactory();
            _connector =  connector.GetConnector(serverSet.conType, serverSet.conString);
            if (_connector != null && _connector.CheckConnect())
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
        
        
        [HttpGet]
        public IActionResult GetDatabases()
        {
            List<string> list = new();
            if (_connector != null)
                list = _connector.GetDatabases();
            if (list.Count > 0)
            {
                return Ok(list);
            }
            else
            {
                return NotFound("baza topilmadi...");
            }
        }
        [HttpGet("{dbName}")]
        public IActionResult GetTables(string dbName)
        {
            List<string> list = new();
            if (_connector != null)
            {
                list = _connector.GetTables(dbName);
                if (list.Count > 0)
                    return Ok(list);
                else
                    return NotFound("jadval yuq");
            }
                
            else
                return NotFound("bazaga ulanmagansiz");
        }
        [HttpGet("{dbName}/{query}")]
        public IActionResult GetExecuteQuery(string dbName, string query)
        {
            ResultSet resaultSet = new ();
            if (_connector != null)
            {
                resaultSet = _connector.ExecuteQuery(dbName, query);
                if(resaultSet != null)
                    return Ok(resaultSet);
                else
                    return NotFound("siz qidirgan ma'lumot yuq");
            }
            else
                return NotFound("bazaga ulanmagansiz");
           
        }
    }
}
