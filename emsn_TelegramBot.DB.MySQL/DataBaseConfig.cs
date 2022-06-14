using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace emsn_TelegramBot.DB.MySQL
{
    public class DataBaseConfig : DbContext
    {

        string CONNECTION_STRING = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        
        #region set DB entities
        public DbSet<Entity.Alert> Alerts { get; set; }
        public DbSet<Entity.AlertSet> AlertSets { get; set; }
        public DbSet<Entity.BirthdayUser> BirthdayUsers { get; set; }
        public DbSet<Entity.BirthdayUserList> BirthdayUserLists { get; set; }
        public DbSet<Entity.BirthdayUserListSet> BirthdayUserListSets { get; set; }
        public DbSet<Entity.Desire> Desires { get; set; }
        public DbSet<Entity.Hobbie> Hobbies { get; set; }
        public DbSet<Entity.HobbieSet> HobbieSets { get; set; }
        public DbSet<Entity.Log> Logs { get; set; }
        public DbSet<Entity.Role> Roles { get; set; }
        public DbSet<Entity.TimeMode> TimeModes { get; set; }
        public DbSet<Entity.TimeModeSet> TimeModeSets { get; set; }
        public DbSet<Entity.User> Users { get; set; }
        public DbSet<Entity.CommandState> CommandStates { get; set; }

        #endregion set DB entities

        #region Create and Config DB

        public DataBaseConfig()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //В БУДУЩЕМ (подгрузка конфига из Json)
            optionsBuilder.UseMySql(CONNECTION_STRING, new MySqlServerVersion(new Version(8, 0, 29)));
        }

        #endregion Create and Config DB

    }
}
