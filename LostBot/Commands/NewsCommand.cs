using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LostBot.Commands
{
    class NewsCommand : Command
    {
        public override string Name => "/news";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            string msg = "";
            string newsI;
            int i;
            if (words.Length == 1 || words.Length > 2)
            {
                i = 0;
                msg = News.GetNews("https://lenta.ru/rss/top7", i);
            }
            else
            {
                try
                {
                    i = int.Parse(words[1]);
                    msg = News.GetNews("https://lenta.ru/rss/top7", i);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    msg = "Неизвестный символ!";
                }

            }
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId: chatId, text: msg).ConfigureAwait(false);
        }
    }
}
