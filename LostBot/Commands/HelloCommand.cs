using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LostBot.Commands
{
    class HelloCommand : Command
    {
        public override string Name => "/hello";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId: chatId, text: "Привет)").ConfigureAwait(false);
        }
    }
}
