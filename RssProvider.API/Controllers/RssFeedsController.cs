using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RssProvider.API.Controllers
{
  [ApiController]
  public class RssFeedsController : ControllerBase
  {
    [HttpGet("api/feeds")]
    public JsonResult GetRssFeeds()
    {
      return new JsonResult(
        new List<object>()
        {
          new { id = 1, title = "feed 1", DateTime.UtcNow },
          new { id = 2, title = "feed 453", DateTime.UtcNow }
        });
    }
  }
}
