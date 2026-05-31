using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TrainReservationDAL;
using TrainReservationEntities.Models;

namespace TrainReservationBAL
{
    public class BookingBAL
    {
        BookingDAL dal = new BookingDAL();

        public bool BookTicket(Booking booking)
        {
            if (booking.Passengers < 1 ||
                booking.Passengers > 3)
            {
                throw new Exception(
                    "Passengers must be between 1 and 3");
            }

            if (booking.TravelDate.Date <
                DateTime.Today)
            {
                throw new Exception(
                    "Travel date cannot be in past");
            }

            DataTable dt =
                dal.GetTrainDetails(
                    booking.TrainNo);

            if (dt.Rows.Count == 0)
                throw new Exception(
                    "Train Not Found");

            int available =
                Convert.ToInt32(
                    dt.Rows[0]["Availability"]);

            decimal charges =
                Convert.ToDecimal(
                    dt.Rows[0]["Charges"]);

            if (available < booking.Passengers)
            {
                throw new Exception(
                    "Seats Not Available");
            }

            booking.Amount =
                booking.Passengers * charges;

            return dal.BookTicket(booking);
        }
        public bool CancelTicket(int bookingId)
        {
            if (dal.IsAlreadyCancelled(bookingId))
            {
                throw new Exception("Ticket already cancelled");
            }

            DataTable dt =
                dal.GetBookingById(bookingId);

            if (dt.Rows.Count == 0)
                throw new Exception("Booking Not Found");

            int trainNo =
                Convert.ToInt32(dt.Rows[0]["TrainNo"]);

            int passengers =
                Convert.ToInt32(dt.Rows[0]["Passengers"]);

            return dal.CancelTicket(
                bookingId,
                trainNo,
                passengers);
             }
        }
    }