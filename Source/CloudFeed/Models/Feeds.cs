using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Xml;

namespace CloudFeed.Models
{
    public class Feeds
    {
        public static IEnumerable<Uri> GetFeeds(string path)
        {
            string line;
            var feeds = new List<Uri>();

            StreamReader file = new StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                feeds.Add(new Uri(line));
            }

            file.Close();

            return feeds;
        }

        public static IEnumerable<SyndicationItem> GetFeedItems(Uri feed)
        {
            var r = XmlReader.Create(feed.ToString());
            var feedData = SyndicationFeed.Load(r);
            r.Close();
            return feedData.Items;
        }
    }
}