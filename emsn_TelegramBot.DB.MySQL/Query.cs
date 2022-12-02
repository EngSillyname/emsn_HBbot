using System.Linq;

namespace emsn_TelegramBot.DB.MySQL
{
    /// <summary>
    /// Интерфейс, означающий, что указанная сущность пригодна для выполнения запросов к БД
    /// с использованием её данных
    /// </summary>
    public interface IQueryable { }

    /// <summary>
    /// Класс для обработки запросов к БД, не засоряя строки основного класса бизнес-логики (Bot.cs)
    /// </summary>
    public static class Query
    {
        /// <summary>
        /// Возможные типы запросов для сущностей бота
        /// </summary>
        public enum ItemQueryType
        {
            Add,
            Edit,
            Delete
        }

        public enum CheckQueryType
        {
            User,
            Active
        }

        /// <summary>
        /// Метод обращения к БД для консолидации открытия соединения с БД в одном месте
        /// </summary>
        /// <param name="queryableEntity">Сущность, чьи данные будут использоваться в запросе</param>
        /// <param name="queryType">Тип запроса</param>
        public static void Item(IQueryable queryableEntity, ItemQueryType queryType)
        {
            using (DataBaseConfig config = new())
            {
                switch (queryType)
                {
                    case ItemQueryType.Add: config.Add(queryableEntity); break;
                    case ItemQueryType.Edit: config.Update(queryableEntity); break;
                    case ItemQueryType.Delete: config.Remove(queryableEntity); break;
                }

                config.SaveChanges();
            }
        }

        public static bool Check(CheckQueryType queryType, long idItem)
        {
            using(DataBaseConfig config = new())
            {
                switch (queryType)
                {
                    case CheckQueryType.User: return config.Users.Any(user => user.userID == idItem);
                    case CheckQueryType.Active: return config.Users.Any(user => (user.userID == idItem) && user.userIsActive);

                    default: return false;
                }
            }
        }

        public static void InitializationDB()
        {
            using (DataBaseConfig config = new())
            {
                config.SaveChanges();
            }
        }

        public static object GetUser(long idItem)
        {
            using (DataBaseConfig config = new())
            {
                return config.Users.ToList().Find(user => user.userID == idItem);
            }
        }

    }
}
