using Microsoft.EntityFrameworkCore;
using System;

namespace emsn_TelegramBot.DB.MySQL
{
    public class DataBaseConfig : DbContext
    {

        string CONNECTION_STRING = Environment.GetEnvironmentVariable("CONNECTION_STRING");

        #region Create and Config DB

        public DataBaseConfig()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //В БУДУЩЕМ (подгрузка конфига из Json)
            optionsBuilder.UseMySql(CONNECTION_STRING, new MySqlServerVersion(new Version(8, 0, 25)));
        }

        #endregion Create and Config DB

    }
}
