using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace RssProvider.API.Controllers
{
  [ApiController]
  public class RssFeedsController : ControllerBase
  {
    [HttpGet("api/feeds")]
    public JsonResult GetRssFeeds()
    {
      string url = "http://rss.cnn.com/rss/edition.rss";
      XmlReader reader = XmlReader.Create(url);
      SyndicationFeed feed = SyndicationFeed.Load(reader);
      reader.Close();

      var result = new List<object>();
      int count = 0;

      foreach (SyndicationItem item in feed.Items)
        result.Add(new { id = ++count, title = item.Title.Text, publishingDate = item.PublishDate.UtcDateTime });
                     
      return new JsonResult(result);
    }

    [HttpGet("api/feeds/{id}")]
    public JsonResult GetRssFeedById()
    {
      return new JsonResult(new { id = 1, title = "feed 1", description = "blah blah blah", uri = "www.xyz.com", DateTime.UtcNow, });
    }
  }
}
