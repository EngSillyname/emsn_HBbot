﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace emsn_TelegramBot.DB.MySQL
{
    /// <summary>
    /// Класс основных сущностей как предметной области бота так и системных
    /// </summary>
    class Entities
    {
        /// <summary>
        /// Пользователь бота
        /// </summary>
        [Table("user")]
        public class User
        {
            /// <summary>
            /// Идентификатор пользователя (в соответствии с Telegram API)
            /// </summary>
            [Key]
            public int userID { get; set; }
            /// <summary>
            /// Код авторизации от бота
            /// </summary>
            [Required, MaxLength(4)]
            public string authCode { get; set; }
            /// <summary>
            /// Роль пользователя с точки зрения функционала
            /// </summary>
            [Required]
            public Role role { get; set; }

        }

        /// <summary>
        /// Роль пользователя в соответствии с ролевой моделью
        /// </summary>
        [Table("role")]
        public class Role
        {
            /// <summary>
            /// Наименование роли пользователя в системе
            /// </summary>
            [Key, MaxLength(15)]
            public string roleName { get; set; }
        }

        /// <summary>
        /// Набор оповещений для пользователя 
        /// </summary>
        [Table("alertSet")]
        public class AlertSet
        {
            /// <summary>
            /// Идентификатор оповещения
            /// </summary>
            [Key]
            public int alertSetID { get; set; }
            /// <summary>
            /// Пользователь, привязанный к оповещению
            /// </summary>
            [Required]
            public User user { get; set; }
            /// <summary>
            /// Оповещение, связанные с пользователем
            /// </summary>
            [Required]
            public Alert alert { get; set; }
        }

        /// <summary>
        /// Указание об оповещении конкретного чата данными из конкретного списка или набора списков
        /// </summary>
        [Table("alert")]
        public class Alert
        {
            /// <summary>
            /// Идентификатор оповещения
            /// </summary>
            [Key]
            public int alertID { get; set; }
            /// <summary>
            /// Чат, который планируется оповещать
            /// </summary>
            [Required]
            public int chatID { get; set; }
            /// <summary>
            /// Набор списков пользователей, проверяемых при определении списка именинников
            /// </summary>
            public BirthdayUserListSet birthdayUserListSet { get; set; }
            /// <summary>
            /// Список пользователей, проверяемых при определении списка именинников
            /// </summary>
            public BirthdayUserList birthdayUserList { get; set; }
        }

        /// <summary>
        /// Временной интервал цикла оповещений
        /// </summary>
        [Table("timeMode")]
        public class TimeMode
        {
            /// <summary>
            /// Идентификатор интервала
            /// </summary>
            [Key]
            public int timeModeID { get; set; }
            /// <summary>
            /// Наименование интервала
            /// </summary>
            [Required, MaxLength(15)]
            public string name { get; set; }
            /// <summary>
            /// Краткое описание/сокращение интервала
            /// </summary>
            [Required, MaxLength(255)]
            public byte[] description { get; set; }
        }

        /// <summary>
        /// Набор временных интервалов, привязанных к оповещениям
        /// </summary>
        [Table("timeModeSet")]
        public class TimeModeSet
        {
            /// <summary>
            /// Оповещение, привязанное к временному интервалу
            /// </summary>
            [Key]
            public Alert alert { get; set; }
            /// <summary>
            /// Временной интервал, привязанный к оповещению
            /// </summary>
            [Required]
            public TimeMode timeMode { get; set; }
        }

        /// <summary>
        /// Лог действий пользователей бота (для сбора и анализа статистики)
        /// </summary>
        [Table("log")]
        public class Log
        {
            /// <summary>
            /// Идентификатор записи лога
            /// </summary>
            [Key]
            public UInt64 logID { get; set; }
            /// <summary>
            /// Временная отметка записи
            /// </summary>
            [Required, Timestamp]
            public DateTime time { get; set; }
            /// <summary>
            /// Совершенное действие
            /// </summary>
            [Required, MaxLength(255)]
            public byte[] action { get; set; }
            /// <summary>
            /// Разница данных
            /// </summary>
            public string difference { get; set; }
            /// <summary>
            /// Пользователь, совершивший данное действие (если это действие не совершил сам бот)
            /// </summary>
            public User user { get; set; }
        }

        /// <summary>
        /// Именинник
        /// </summary>
        [Table("birthdayUser")]
        public class BirthdayUser
        {
            /// <summary>
            /// Идентификатор именинника
            /// </summary>
            [Key]
            public int birthdayUserID { get; set; }
            /// <summary>
            /// Идентификатор пользователя Telegram (если существует)
            /// </summary>
            public User user { get; set; }
            /// <summary>
            /// ФИО или понятное пользователю имя именинника
            /// </summary>
            [Required, MaxLength(100)]
            public string strongName { get; set; }
            /// <summary>
            /// Дата рождения (ДД\ММ\ГГГГ или ДД\ММ)
            /// </summary>
            [Required, Timestamp]
            public DateTime dateOfBirth { get; set; }
        }

        /// <summary>
        /// Список именинников
        /// </summary>
        [Table("birthdayUserList")]
        public class BirthdayUserList
        {
            /// <summary>
            /// Идентификатор списка именинников
            /// </summary>
            [Key]
            public int birthdayUserListID { get; set; }
            /// <summary>
            /// Идентификатор имменинника
            /// </summary>
            [Required]
            public BirthdayUser birthdayUser { get; set; }
            /// <summary>
            /// Наименование списка
            /// </summary>
            [Required, MaxLength(30)]
            public string name { get; set; }
        }

        /// <summary>
        /// Набор списков именинников, привязанных к пользователю
        /// </summary>
        [Table("birthdayUserListSet")]
        public class BirthdayUserListSet
        {
            /// <summary>
            /// Идентификатор набора списков именинников
            /// </summary>
            [Key]
            public int birthdayUserListSetID { get; set; }
            /// <summary>
            /// Идентификатор списка именинников
            /// </summary>
            [Required]
            public BirthdayUserList birthdayUserList { get; set; }
            /// <summary>
            /// Идентификатор пользователя бота
            /// </summary>
            [Required]
            public User user { get; set; }
        }

        /// <summary>
        /// Желание именинника
        /// </summary>
        [Table("desire")]
        public class Desire
        {
            /// <summary>
            /// Идентификатор именинника (пользователя бота)
            /// </summary>
            [Key]
            public BirthdayUser birthdayUser { get; set; }
            /// <summary>
            /// Название желания
            /// </summary>
            [Required, MaxLength(100)]
            public string name { get; set; }
            /// <summary>
            /// Описание желания
            /// </summary>
            public string description { get; set; }
            /// <summary>
            /// Ссылка товар/услугу (при наличи)
            /// </summary>
            [Url]
            public string url { get; set; }
            /// <summary>
            /// Цена (при наличии)
            /// </summary>
            public int price { get; set; }
        }

        /// <summary>
        /// Хобби именинника
        /// </summary>
        [Table("hobbie")]
        public class Hobbie
        {
            /// <summary>
            /// Идентификатор хобби
            /// </summary>
            [Key]
            public int hobbieID { get; set; }
            /// <summary>
            /// Наименование хобби
            /// </summary>
            [Required]
            public string name { get; set; }
            /// <summary>
            /// Популярность хобби (0-100% или место в статистике-отчете)
            /// </summary>
            [Required]
            public byte popularity { get; set; }
        }

        /// <summary>
        /// Набор хобби, привязанных к имениннику
        /// </summary>
        [Table("hobbieSet")]
        public class HobbieSet
        {
            /// <summary>
            /// Идентификатор именинника (или пользователя бота), привязанного к хобби
            /// </summary>
            [Key]
            public BirthdayUser birthdayUser { get; set; }
            /// <summary>
            /// Идентификатор хобби, привязанному к имениннику (или пользователю бота)
            /// </summary>
            [Required]
            public Hobbie hobbie { get; set; }
        }

    }
}
