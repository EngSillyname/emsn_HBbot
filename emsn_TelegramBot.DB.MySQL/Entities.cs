using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            [Key]
            public int userID { get; set; } //Идентификатор пользователя (в соответствии с Telegram API)
            [Required, MaxLength(4)]
            public string authCode { get; set; } //Код авторизации от бота
            public Role role { get; set; } //Роль пользователя с точки зрения функционала

        }

        [Table("role")]
        public class Role //Роль пользователя в соответствии с ролевой моделью
        {
            [Required, MaxLength(15)]
            public string roleName { get; set; } //Наименование роли пользователя в системе
        }

        [Table("alertsSet")]
        public class AlertsSet 
        {
            public string roleName { get; set; } 
        }

        [Table("alert")]
        public class Alert //Оповещение
        {
            [Key]
            public int alertID { get; set; }
            [Required]
            public int chatID { get; set; }
        }
    }
}
