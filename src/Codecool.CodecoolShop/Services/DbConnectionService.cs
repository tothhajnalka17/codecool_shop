using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace Codecool.CodecoolShop.Services
{
    internal class DbConnectionService
    {
        public static DbConnectionService instance = new DbConnectionService();

        public static string ConnectionString { get; set; }
        public SqlConnection Connection { get; set; }

        private DbConnectionService()
        {
            ConnectionString = Startup.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
            Connection = new SqlConnection(ConnectionString);
        }

        public static DbConnectionService Singleton
        {
            get { return instance; }
        }
    }
}
