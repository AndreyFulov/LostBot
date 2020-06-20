using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LostBot.Commands
{
    class TestCommand : Command
    {
        public override string Name => "/test";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId: chatId, text: "Тест Проведён!🤖 Работает!").ConfigureAwait(false);
        }
    }
}
