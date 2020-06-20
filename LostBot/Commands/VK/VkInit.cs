using System;
using System.Collections.Generic;
using System.Text;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace LostBot.Commands.VK
{
    class VkInit
    {
         VkApi api = new VkApi();

        public void Login()
        {
            api.Authorize(new ApiAuthParams
            {
                ApplicationId = 7516634,
                Login = "fufloplay@gmail.com",
                Password = "andreim2013",
                Settings = Settings.All
            });
            Console.WriteLine(api.Token);
        }
        public void GetGroups()
        {
            //var groups = api.Groups.Get();
        }
    }
}
