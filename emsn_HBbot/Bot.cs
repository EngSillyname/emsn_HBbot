using emsn_TelegramBot.DB.MySQL;
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
            ShortMessage.Bot = botClient;

            //Приветственное сообщение о запусек бота
            Console.WriteLine($"Привет! Бот с id {me.Id} под именем {me.FirstName} успешно запущен!");

            //Добавление обрабатываемых событий
            botClient.OnMessage += BotClient_OnMessage;

            //Запуск
            BotResources.loadStructures();
            botClient.StartReceiving();

            //Простой работы
            Thread.Sleep(int.MaxValue);
        }

        static void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            //Парсинг сообщения
            string resultText = "";
            List<char> textMessage = new List<char>(e.Message.Text.ToCharArray());
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
        }
    }
}
