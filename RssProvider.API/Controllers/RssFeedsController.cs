using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

    [HttpGet("api/feeds/{id}")]
    public JsonResult GetRssFeedById()
    {
      return new JsonResult(new { id = 1, title = "feed 1", description = "blah blah blah", uri = "www.xyz.com", DateTime.UtcNow, });
    }
  }
}
