using RssProvider.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;

namespace RssProvider.API.DAL
{
	public class RssFeedDS
	{
		private Uri _uri = new Uri("http://rss.cnn.com/rss/edition.rss");

		public static RssFeedDS Current { get; } = new RssFeedDS();

		public List<RssFeedDto> RssFeeds { get; set; }

		public RssFeedDS()
		{
			XmlReader reader = XmlReader.Create(_uri.AbsoluteUri);
			SyndicationFeed feed = SyndicationFeed.Load(reader);
			reader.Close();

			int count = 0;
			if (feed != null)
			{
				RssFeeds = new List<RssFeedDto>();

				foreach (SyndicationItem item in feed.Items)
				  RssFeeds.Add(new RssFeedDto
					{
						Id = ++count,
						Title = item.Title.Text,
						Description = ("Description is hard to write"),
						PublishingDate = item.PublishDate.UtcDateTime,
						Link = new Uri(item.Id)
					});
			}
		}
	}
}
