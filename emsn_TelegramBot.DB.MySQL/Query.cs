using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emsn_TelegramBot.DB.MySQL
{
    public static class Query
    {

        public static void AddItem(IQueried entity)
        {
            using(DataBaseConfig config = new DataBaseConfig())
            {
                _ = config.Add(entity);
            }
        } 
    }
}
