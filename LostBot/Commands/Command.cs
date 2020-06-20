using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LostBot.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public static string[] words;
        public static void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var text = e?.Message?.Text;
            words = text.Split(' ');
            var message = e.Message;
            var commands = Program.Commands;
            var client = Program.GetClient();

            if (text == null)
            {
                return;
            }

            foreach (var command in commands) {
                if(words[0] == command.Name)
                {
                    command.Execute(message, client);
                }
            }
            Console.WriteLine($"Принято сообщение: '{text}' в чате: {e.Message.Chat.Id}");
        }
        public abstract void Execute(Message message, TelegramBotClient client);
    }
}
