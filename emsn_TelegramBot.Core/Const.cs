using emsn_TelegramBot.DB.MySQL;

namespace emsn_TelegramBot.Common
{
    public interface IState
    {
        void Execute(IQueryable Item, Telegram.Bot.Args.MessageEventArgs e);
    }

    public interface ICommand
    {
        void ChangeState(BotResources.commandState commandState);
    }
  
}
