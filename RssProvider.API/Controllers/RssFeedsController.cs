using Microsoft.AspNetCore.Mvc;
using RssProvider.API.DAL;
using System.Linq;

namespace RssProvider.API.Controllers
{
  [ApiController]
  [Route("api/feeds/")]
  public class RssFeedsController : ControllerBase
  {
    [HttpGet]
    public IActionResult GetRssFeeds()
    {
      if (RssFeedDS.Current.RssFeeds == null)
        return NotFound();
      else
        return Ok(RssFeedDS.Current.RssFeeds);
    }

    [HttpGet("{id}")]
    public IActionResult GetRssFeed(int id)
    {

      var rssFeed = RssFeedDS.Current.RssFeeds.FirstOrDefault(f => f.Id == id);

      if (rssFeed == null)
        return NotFound();
      else
        return Ok(rssFeed);
    }
  }
}