using emsn_TelegramBot.DB.MySQL;
using emsn_TelegramBot.RoleModel;
using System;
using System.Collections.Generic;
using System.Threading;
using Telegram.Bot;

namespace emsn_TelegramBot
{
    class Bot
    {
        static string API_TOKEN = Environment.GetEnvironmentVariable("API_TOKEN");
        static ITelegramBotClient botClient;
        static void Main(string[] args)
        {
            //Инициализация БД
            Query.InitializationDB();

            //Подключение к боту по токену
            botClient = new TelegramBotClient(API_TOKEN);
            var me = botClient.GetMeAsync().Result;
            

            //Приветственное сообщение о запусек бота
            Console.WriteLine($"Привет! Бот с id {me.Id} под именем {me.FirstName} успешно запущен!");

            //Добавление обрабатываемых событий
            botClient.OnMessage += BotClient_OnMessage;

            //Запуск загрузки ресурсов и внутренних классов и самого бота
            BotResources.LoadStructures();
            ShortMessage.bot = botClient;
            botClient.StartReceiving();
            
            //Простой работы
            //Пока сделано через обычное консольное приложение, после первого релиза планируется преобразование в службу Windows
            Thread.Sleep(int.MaxValue);
        }

        static void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            #region Пользовательская сессия

            //Базовая проверка наличия пользователя в системе и наличия у пользователя активной сессии
            if (!Query.Check(Query.CheckQueryType.User, e.Message.From.Id))
            {
                ShortMessage.Send(e.Message.Chat.Id, BotResources.GetString("checkUserFalse"));
                return;
            }
            else
            {
                ShortMessage.Send(e.Message.Chat.Id, BotResources.GetString("checkUserTrue"));
                if (!Authenticator.Session(Query.GetUser(e.Message.From.Id), Authenticator.Mode.Check))
                {
                    ShortMessage.Send(e.Message.Chat.Id, BotResources.GetString("getAuthCode"));
                    return;
                }

            }

            #endregion Пользовательская сессия

            #region Команды

            //Парсинг сообщения
            //TODO [общий рефакторинг вступительной части метода]
            string resultText = "";
            List<char> textMessage = new(e.Message.Text.ToCharArray());
            if (textMessage.FindIndex(x => x == '@') != -1)
            {
                textMessage.RemoveRange(textMessage.FindIndex(x => x == '@'), textMessage.Count - textMessage.FindIndex(x => x == '@'));
                foreach (var letter in textMessage)
                {
                    resultText += letter;
                }
            }
            else
            {
                resultText = e.Message.Text;
            }

            //Список команд
            //TODO [resultText.StartWith('/')]
            if (resultText[0] == '/')
            {
                switch (resultText.ToLower().Trim(new char[] { ' ', '/' }))
                {
                    case "start": 
                        {
                            
                        }
                        break;
                    default:
                        {

                        }
                        break;
                }
            }

            #endregion Команды
        }
    }
}
