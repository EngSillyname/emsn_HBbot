using emsn_TelegramBot.DB.MySQL;
using System.Collections.Generic;
using System.Threading;

namespace emsn_TelegramBot.RoleModel
{
    class Authenticator
    {
        #region Управление сессиями
        
        /// <summary>
        /// Режимы функции Session
        /// </summary>
        public enum Mode
        {
            Check,
            Start,
            Stop
        }

        /// <summary>
        /// Набор таймеров-сессий пользователей бота
        /// </summary>
        static Dictionary<Entity.User, Timer> timers = new();

        /// <summary>
        /// Функция управления сессиями для авторизованных пользователей бота
        /// </summary>
        /// <param name="botUser">Пользователь бота</param>
        /// <param name="mode">Режим работы функции</param>
        /// <returns>состояние для сессии требуемого пользователя</returns>
        public static bool Session(object botUser, Mode mode)
        {
            switch (mode)
            {
                case Mode.Check:    return (botUser as Entity.User).userIsActive;
                case Mode.Start:
                                {
                                    timers.Add(botUser as Entity.User, new Timer(StopSession, botUser, 0, 3600000));
                                    (botUser as Entity.User).userIsActive = true;
                                    Query.Item((Entity.User)botUser, Query.ItemQueryType.Edit);
                                    return true;
                                }
                case Mode.Stop:
                                {
                                    timers[(Entity.User)botUser].Dispose();
                                    timers.Remove(botUser as Entity.User);
                                    (botUser as Entity.User).userIsActive = false;
                                    Query.Item((Entity.User)botUser, Query.ItemQueryType.Edit);
                                    return true;
                                }
                    default:        return (botUser as Entity.User).userIsActive;
            }
        }

        /// <summary>
        /// Техническая функция для делегата класса Timer
        /// </summary>>
        static void StopSession(object timer)
        {
            Session(timer, Mode.Stop);
        }

        #endregion Управление сессиями
    }
}
