using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace LostBot.Commands
{
    public class News
    {
        public static string GetNews(string url, int i)
        {
            Random rnd = new Random();
            WebClient webClient = new WebClient();
            string result = webClient.DownloadString(url);
            XDocument document = XDocument.Parse(result);
            List<Rss> a = (from descendant in document.Descendants("item")
                           select new Rss()
                           {
                               Description = descendant.Element("description").Value,
                               Title = descendant.Element("title").Value,
                               PublicationDate = descendant.Element("pubDate").Value
                           }
                           ).ToList();
            string news = "";
            if (a != null)
            {
                news = "🔥" + a[i].Title+ Environment.NewLine+"-----------------------------------"+Environment.NewLine +a[i].Description + Environment.NewLine
                    + "-----------------------------------" + Environment.NewLine + a[i].PublicationDate;
                byte[] bytes = Encoding.Default.GetBytes(news);
                news = Encoding.UTF8.GetString(bytes);
                return news;
            }
            else
                return "Новостей нет =(";
        }
    }
    public class Rss
    {
        public string Title;
        public string PublicationDate;
        public string Description;
    }
}
