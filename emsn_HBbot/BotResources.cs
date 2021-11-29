using Newtonsoft.Json;
using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace emsn_TelegramBot
{
    public class BotResources
    {

        /// <summary>
        /// Строковые ресурсы, подгружаемые с файлов на сервере <команда, набор вариантов ответной реакции>
        /// </summary>
        public static Dictionary<string, List<string>> Strings = new();

        /// <summary>
        /// Ресурсы клавиатур для сообщений, подгружаемые с файлов на сервере <имя клавиатуры, набор клавиш для неё>
        /// </summary>
        public static Dictionary<string, ReplyKeyboardMarkup> ReplyKeyboards = new();

        public BotResources()
        {
        }


        /// <summary>
        /// Структуры файлов ресурсов для бота
        /// </summary>
        public static void loadStructures()
        {
            Strings = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(System.IO.File.ReadAllText(@"Strings.json"));
            ReplyKeyboards = JsonConvert.DeserializeObject<Dictionary<string, ReplyKeyboardMarkup>>(System.IO.File.ReadAllText(@"Keyboards.json"));
        }
    }
}
