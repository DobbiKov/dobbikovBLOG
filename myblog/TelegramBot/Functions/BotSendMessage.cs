using myblog.TelegramBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace myblog.TelegramBot.Functions
{
    public static class BotSendMessage
    {
        private static TelegramBotClient client;
        public static async Task ToDobbiKovBlog(string message)
        {
            client = await Bot.Get();
            await client.SendTextMessageAsync(BotSettings.GroupId, message);
        }
    }
}
