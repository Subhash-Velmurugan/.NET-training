using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TrainReservationEntities.Models;
using System.Data;

namespace TrainReservationDAL
{
    public class TrainDAL
    {
        public bool AddTrain(Train train)
        {
            using (SqlConnection con =
                new SqlConnection(DBHelper.ConnectionString))
            {
                string query = @"INSERT INTO Train
                                VALUES
                                (@no,@name,@from,@to,
                                 @class,@avail,@charges,0)";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@no", train.TrainNo);
                cmd.Parameters.AddWithValue("@name", train.TrainName);
                cmd.Parameters.AddWithValue("@from", train.FromStation);
                cmd.Parameters.AddWithValue("@to", train.ToStation);
                cmd.Parameters.AddWithValue("@class", train.TrainClass);
                cmd.Parameters.AddWithValue("@avail", train.Availability);
                cmd.Parameters.AddWithValue("@charges", train.Charges);

                con.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteTrain(int trainNo)
        {
            using (SqlConnection con =
                new SqlConnection(DBHelper.ConnectionString))
            {
                string query =
                    @"UPDATE Train
                      SET IsDeleted = 1
                      WHERE TrainNo=@trainNo";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@trainNo",
                    trainNo);

                con.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public DataTable GetAllTrains()
        {
            using (SqlConnection con =
                new SqlConnection(DBHelper.ConnectionString))
            {
                string query =
                    @"SELECT TrainNo,
                     TrainName,
                     FromStation,
                     ToStation,
                     Class,
                     Availability,
                     Charges
              FROM Train
              WHERE IsDeleted = 0";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }
        public bool TrainExists(int trainNo)
        {
            using (SqlConnection con =
                new SqlConnection(DBHelper.ConnectionString))
            {
                string query =
                    @"SELECT COUNT(*)
              FROM Train
              WHERE TrainNo=@trainNo
              AND IsDeleted=0";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@trainNo", trainNo);

                con.Open();

                return (int)cmd.ExecuteScalar() > 0;
            }
        }
        public bool HasActiveBookings(int trainNo)
        {
            using (SqlConnection con =
                new SqlConnection(DBHelper.ConnectionString))
            {
                string query =
                @"SELECT COUNT(*)
          FROM Booking b
          WHERE b.TrainNo = @trainNo
          AND b.BookingId NOT IN
          (SELECT BookingId FROM Cancellation)";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@trainNo", trainNo);

                con.Open();

                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }
    }
}
