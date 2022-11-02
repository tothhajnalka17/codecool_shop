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
            ConnectionString =
                "Server=(LocalDb)\\MSSQLLocalDB;Database=codecoolshop;Trusted_Connection=True;MultipleActiveResultSets=true";
            Connection = new SqlConnection(ConnectionString);
        }

        public static DbConnectionService Singleton
        {
            get { return instance; }
        }
    }
}
