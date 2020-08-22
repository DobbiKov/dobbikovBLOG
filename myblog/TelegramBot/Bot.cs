using myblog.TelegramBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace myblog.TelegramBot
{
    public static class Bot
    {
        private static TelegramBotClient client;

        public static async Task<TelegramBotClient> Get()
        {
            if (client != null) return client;
            client = new TelegramBotClient(BotSettings.Token);
            return client;
        }
    }
}
