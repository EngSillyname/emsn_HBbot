using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emsn_TelegramBot.DB.MySQL
{
    class Entities
    {
        [Table("user")]
        public class User //Пользователь бота
        {
            public int id { get; set; } //Идентификатор пользователя (в соответствии с Telegram API)
            public string authCode { get; set; } //Код авторизации от бота

        }

        [Table("role")]
        public class Role //Роль пользователя в соответствии с ролевой моделью
        {
            public string roleName { get; set; } //наименование роли пользователя в системе
        }
    }
}
