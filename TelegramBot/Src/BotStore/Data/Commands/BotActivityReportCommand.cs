﻿using System;
using System.Text;
using System.Threading.Tasks;
using BotApplication.Bot.Code;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace BotApplication.BotStore.Data.Commands
{
    public class BotActivityReportCommand : Bot.Code.BotCommand
    {
        public BotActivityReportCommand(string str) : base(str)
        {
            
        }

        public override async Task<Hop> ExecCommand(UpdateBotModel data)
        {
            if (data.user.Id.ToString() != AppConstants.SupportUserId) return null;
            
            var _db = data.dbBot;
            StringBuilder sb = new StringBuilder();
            var usersCount = await _db.User.CountAsync();
            var activityCount = await _db.Message.CountAsync();
            var todayNewUsers = await _db.User.CountAsync(u => u.CreateTime >= DateTime.Today);
            var todayActivity = await _db.Message.CountAsync(m => m.CreateTime >= DateTime.Today);

            sb.AppendLine($"<b>Пользователи</b> : {usersCount}");
            sb.AppendLine($"<b>Активность</b> : {activityCount}");
            sb.AppendLine($"<b>Новые пользователи</b> : {todayNewUsers}");
            sb.AppendLine($"<b>Активность сегодня</b> : {todayActivity}");
            await data.bot.SendTextMessageAsync(data.chat.Id, sb.ToString(), ParseMode.Html);
            return null;
        }
    }
}