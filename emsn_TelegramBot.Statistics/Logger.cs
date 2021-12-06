using emsn_TelegramBot.RoleModel;
using emsn_TelegramBot.DB.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emsn_TelegramBot.Statistics
{
    public class Logger : Entity.Log
    {
        public static bool Add(string actionName, string difference = null, Entity.User user = null)
        {
            return false;
        }
    }
}
