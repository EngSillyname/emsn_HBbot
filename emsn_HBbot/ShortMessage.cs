using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace emsn_TelegramBot
{
    class ShortMessage
    {
        public static ITelegramBotClient Bot;
        public ShortMessage()
        {

        }
        public ShortMessage(ITelegramBotClient bot)
        {
            Bot = bot;
        }

        public static void Send(long chatId, string text, IReplyMarkup markup = null)
        {
            Bot.SendTextMessageAsync
            (
                chatId: chatId,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                text: text,
                replyMarkup: markup
            );
        }
        public static void Edit(long chatId, int messageId, string text)
        {
            Bot.EditMessageTextAsync
            (
                chatId: chatId,
                messageId: messageId,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                text: text
            );
        }
    }
}
