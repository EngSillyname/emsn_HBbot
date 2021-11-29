namespace emsn_TelegramBot.DB.MySQL
{
    public interface IQueried
    {
        public void AddItem(Entities entities);
        public void EditItem(int itemID);
        public void DeleteItem(int itemID);
    }
}
