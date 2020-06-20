using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VkNet.Model;

namespace LostBot.Commands.Memes
{
    public class memesJson
    {
        [JsonProperty("data")]
        public Post data { get; set; }
    }
    public class Post
    {
        [JsonProperty("children")]
        public Children[] childrens { get; set; }
    }
    public class Children
    {
        [JsonProperty("data")]
        public Preview data { get; set; }
    }
    public class Preview
    {
        [JsonProperty("preview")]
        public Images preview { get; set; }
    }
    public class Images
    {
        [JsonProperty("images")]
        public Source[] images { get; set; }
    }
    public class Source
    {
        [JsonProperty("source")]
        public Url source { get; set; }
    }
    public class Url
    {
        [JsonProperty("url")]
        public string url { get; set; }
    }
}
