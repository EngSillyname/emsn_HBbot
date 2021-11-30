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
        public enum QueryType
        {
            Add,
            Edit,
            Delete
        }

        /// <summary>
        /// Метод обращения к БД для консолидации открытия соединения с БД в одном месте
        /// </summary>
        /// <param name="queryableEntity">Сущность, чьи данные будут использоваться в запросе</param>
        /// <param name="queryType">Тип запроса</param>
        public static void Item(IQueryable queryableEntity, QueryType queryType)
        {
            using (DataBaseConfig config = new DataBaseConfig())
            {
                switch (queryType)
                {
                    case QueryType.Add: config.Add(queryableEntity); break;
                    case QueryType.Edit: config.Update(queryableEntity); break;
                    case QueryType.Delete: config.Remove(queryableEntity); break;
                }

                config.SaveChanges();
            }
        }

        public static void InitializationDB()
        {
            using (DataBaseConfig config = new DataBaseConfig())
            {
                config.SaveChanges();
            }
        }
    }
}
