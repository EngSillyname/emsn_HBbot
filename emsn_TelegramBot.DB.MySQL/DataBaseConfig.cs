using Microsoft.EntityFrameworkCore;
using System;

namespace emsn_TelegramBot.DB.MySQL
{
    public class DataBaseConfig : DbContext
    {

        string CONNECTION_STRING = Environment.GetEnvironmentVariable("CONNECTION_STRING");

        #region set DB entities
        public DbSet<Entities.Alert> Alerts { get; set; }
        public DbSet<Entities.AlertSet> AlertSets { get; set; }
        public DbSet<Entities.BirthdayUser> BirthdayUsers { get; set; }
        public DbSet<Entities.BirthdayUserList> BirthdayUserLists { get; set; }
        public DbSet<Entities.BirthdayUserListSet> BirthdayUserListSets { get; set; }
        public DbSet<Entities.Desire> Desires { get; set; }
        public DbSet<Entities.Hobbie> Hobbies { get; set; }
        public DbSet<Entities.HobbieSet> HobbieSets { get; set; }
        public DbSet<Entities.Log> Logs { get; set; }
        public DbSet<Entities.Role> Roles { get; set; }
        public DbSet<Entities.TimeMode> TimeModes { get; set; }
        public DbSet<Entities.TimeModeSet> TimeModeSets { get; set; }
        public DbSet<Entities.User> Users { get; set; }
        #endregion set DB entities

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
