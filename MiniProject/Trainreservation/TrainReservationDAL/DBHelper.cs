using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TrainReservationDAL
{
    public class DBHelper
    {
        public static string ConnectionString =
            @"Server=(localdb)\MSSQLLocalDB;
              Database=TrainReservationDB;
              Trusted_Connection=True;";
    }
}