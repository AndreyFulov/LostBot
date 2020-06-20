using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LostBot.Commands
{
    class HelpCommand : Command
    {
        public override string Name => "/help";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            string msg = "Помощь\n/weather (Город) - Узнать погоду🌤";
            await client.SendTextMessageAsync(chatId: chatId, text: msg).ConfigureAwait(false);
        }
    }
}
