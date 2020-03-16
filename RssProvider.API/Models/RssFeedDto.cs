using System;

namespace RssProvider.API.Models
{
	public class RssFeedDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTimeOffset PublishingDate { get; set; }
		public Uri Link { get; set; }
	}
}
