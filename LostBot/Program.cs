using System;
using Telegram.Bot;
using LostBot.Commands;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Threading.Tasks;
using LostBot.Commands.VK;

namespace LostBot
{
    class Program
    {
        private static ITelegramBotClient botClient;


        private static List<Command> commandsList;
        public static IReadOnlyList<Command> Commands { get => commandsList.AsReadOnly(); }
        static void Main(string[] args)
        {
            botClient = new TelegramBotClient("1149814876:AAH4COgEK8ZXkd2h4EKV5XVNkeMtIk0t7uw") {Timeout = TimeSpan.FromSeconds(10)};
            commandsList = new List<Command>();

            //Добавить Комманды
            commandsList.Add(new HelloCommand());
            commandsList.Add(new TestCommand());
            commandsList.Add(new GetWeatherCommand());

            botClient.OnMessage += Command.BotClient_OnMessage;
            botClient.StartReceiving();
            VkInit vkInit = new VkInit();
            vkInit.Login();
            Console.ReadKey();
        }
        public static TelegramBotClient GetClient()
        {
            return (TelegramBotClient)botClient;
        }

    }
}
