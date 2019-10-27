using System.Web.Http;

namespace TicketMaster.Controllers
{
    [RoutePrefix("api/todos")]
    public class TodosController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var user = new { name = User.Identity.Name };
            
            return Ok(user);
        }
    }
}
