using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace LostBot.Commands.VK
{
    class VkInit
    {
        VkApi api = new VkApi();
        public static void Initialize()
        {
            VkInit init = new VkInit();
            init.Login();
            Console.WriteLine("Токен ВК: " +init.api.Token);
        }
        public void Login()
        {
            api.Authorize(new ApiAuthParams
            {
                AccessToken = "6580e1ec6580e1ec6580e1ec2d65f25036665806580e1ec3b6d768aa4560d2309449f30"
            });
        }
        public void GetGroups()
        {
            var post = api.Wall.Get(new WallGetParams
            {
                Domain = "reddit"
            });
            api.Photo.Get(new PhotoGetParams
            {
            });
            Console.WriteLine(post.ToString());
        }
    }
}
