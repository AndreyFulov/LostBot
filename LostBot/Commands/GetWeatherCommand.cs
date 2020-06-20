using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LostBot.Commands
{
    class GetWeatherCommand : Command
    {
        HttpClient httpClient = new HttpClient();
        public override string Name => "/weather";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId: chatId, text: GetWeather()).ConfigureAwait(false);
        }
        public string GetWeather()
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=Dzhubga&units=metric&appid=4292447e0e5ac7340a328459cca86914";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string response;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

            return $"🌤Погода в городе: Джубга\n🌡Температура в Цельсиях: {weatherResponse.Main.Temp}";
        }
    }
}
