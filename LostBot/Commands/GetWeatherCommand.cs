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
            string city;
           if(words.Length == 1 || words.Length > 2)
            {
                city = "Москва";
            }else
            {
                city = words[1];
            }
           string url = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&units=metric&appid=4292447e0e5ac7340a328459cca86914";
           HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse;
           try
            {
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return "Опа, а города то нет...";
            }
           string response;
           using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
           {
                response = streamReader.ReadToEnd();
           }
           WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

           return $"🌤Погода в городе: {city}\n🌡Температура в Цельсиях: {weatherResponse.Main.Temp}\n🌬Скорость ветра: {weatherResponse.Wind.speed} м/с\n☁️Облачность: {weatherResponse.Clouds.All}%";
        }
    }
}
