using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace emsn_TelegramBot
{
    public class ShortMessage
    {
        public static ITelegramBotClient bot;
        public ShortMessage()
        {

        }
        public ShortMessage(ITelegramBotClient Bot)
        {
            bot = Bot;
        }

        public static void Send(long chatId, string text, IReplyMarkup markup = null)
        {
            bot.SendTextMessageAsync
            (
                chatId: chatId,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                text: text,
                replyMarkup: markup
            );
        }
        public static void Edit(long chatId, int messageId, string text)
        {
            bot.EditMessageTextAsync
            (
                chatId: chatId,
                messageId: messageId,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                text: text
            );
        }
    }
}
