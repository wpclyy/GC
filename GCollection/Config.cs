using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCollection
{
    public class Config
    {
        private static string connection= "server=192.168.2.88;user id=Fany;password=wang198912;database=gcollection";//数据库连接字符串

        public static string Connection
        {
            get { return connection; }
        }
    }
}
