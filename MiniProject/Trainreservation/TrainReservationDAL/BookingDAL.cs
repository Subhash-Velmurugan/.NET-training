using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TrainReservationEntities.Models;

namespace TrainReservationDAL
{
    public class BookingDAL
    {
        public DataTable GetTrainDetails(int trainNo)
        {
            using (SqlConnection con =
                new SqlConnection(DBHelper.ConnectionString))
            {
                string query =
                    @"SELECT *
                      FROM Train
                      WHERE TrainNo=@trainNo
                      AND IsDeleted=0";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, con);

                da.SelectCommand.Parameters
                    .AddWithValue("@trainNo", trainNo);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public bool BookTicket(Booking booking)
        {
            using (SqlConnection con =
                new SqlConnection(DBHelper.ConnectionString))
            {
                con.Open();

                SqlTransaction transaction =
                    con.BeginTransaction();

                try
                {
                    string insertQuery =
                    @"INSERT INTO Booking
                    (
                        TravelDate,
                        TrainNo,
                        TravelClass,
                        Passengers,
                        Amount
                    )
                    VALUES
                    (
                        @date,
                        @trainNo,
                        @class,
                        @passengers,
                        @amount
                    )";

                    SqlCommand cmd =
                        new SqlCommand(insertQuery,
                                       con,
                                       transaction);

                    cmd.Parameters.AddWithValue("@date",
                        booking.TravelDate);

                    cmd.Parameters.AddWithValue("@trainNo",
                        booking.TrainNo);

                    cmd.Parameters.AddWithValue("@class",
                        booking.TravelClass);

                    cmd.Parameters.AddWithValue("@passengers",
                        booking.Passengers);

                    cmd.Parameters.AddWithValue("@amount",
                        booking.Amount);

                    cmd.ExecuteNonQuery();

                    string updateQuery =
                    @"UPDATE Train
                      SET Availability =
                      Availability - @passengers
                      WHERE TrainNo=@trainNo";

                    SqlCommand updateCmd =
                        new SqlCommand(updateQuery,
                                       con,
                                       transaction);

                    updateCmd.Parameters.AddWithValue(
                        "@passengers",
                        booking.Passengers);

                    updateCmd.Parameters.AddWithValue(
                        "@trainNo",
                        booking.TrainNo);

                    updateCmd.ExecuteNonQuery();

                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public DataTable GetBookingById(int bookingId)
        {
            using (SqlConnection con =
                new SqlConnection(DBHelper.ConnectionString))
            {
                string query =
                    @"SELECT *
              FROM Booking
              WHERE BookingId=@bookingId";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, con);

                da.SelectCommand.Parameters.AddWithValue(
                    "@bookingId",
                    bookingId);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }
        public bool CancelTicket(int bookingId,
                         int trainNo,
                         int passengers)
        {
            using (SqlConnection con =
                new SqlConnection(DBHelper.ConnectionString))
            {
                con.Open();

                SqlTransaction transaction =
                    con.BeginTransaction();

                try
                {
                    string insertCancel =
                    @"INSERT INTO Cancellation
              (BookingId,NoTickets)
              VALUES
              (@bookingId,@tickets)";

                    SqlCommand cancelCmd =
                        new SqlCommand(
                            insertCancel,
                            con,
                            transaction);

                    cancelCmd.Parameters.AddWithValue(
                        "@bookingId",
                        bookingId);

                    cancelCmd.Parameters.AddWithValue(
                        "@tickets",
                        passengers);

                    cancelCmd.ExecuteNonQuery();

                    string updateTrain =
                    @"UPDATE Train
              SET Availability =
              Availability + @passengers
              WHERE TrainNo=@trainNo";

                    SqlCommand updateCmd =
                        new SqlCommand(
                            updateTrain,
                            con,
                            transaction);

                    updateCmd.Parameters.AddWithValue(
                        "@passengers",
                        passengers);

                    updateCmd.Parameters.AddWithValue(
                        "@trainNo",
                        trainNo);

                    updateCmd.ExecuteNonQuery();

                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public bool IsAlreadyCancelled(int bookingId)
        {
            using (SqlConnection con =
                new SqlConnection(DBHelper.ConnectionString))
            {
                string query =
                    @"SELECT COUNT(*)
              FROM Cancellation
              WHERE BookingId=@bookingId";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@bookingId", bookingId);

                con.Open();

                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }
    }
}