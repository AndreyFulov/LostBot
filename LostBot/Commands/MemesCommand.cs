using LostBot.Commands.Memes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LostBot.Commands
{
    class MemesCommand : Command
    {
        public override string Name => "/memes";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            string url = getMeme();
            url = url.Replace("amp;", "");
            await client.SendPhotoAsync(chatId: chatId, photo: url, caption: "/r/memes",parseMode: ParseMode.Html);
        }

        public string getMeme()
        {
            string url = "https://www.reddit.com/r/memes/top/.json?count=25";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse;
            try
            {
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Опа, а мема нет....";
            }
            string response;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            Random rnd = new Random();
            int i = rnd.Next(0, 24);
            memesJson memes = JsonConvert.DeserializeObject<memesJson>(response);
            return memes.data.childrens[i].data.preview.images[0].source.url;
        }
    }
}
