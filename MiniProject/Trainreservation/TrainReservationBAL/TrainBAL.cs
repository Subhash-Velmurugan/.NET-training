using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainReservationDAL;
using TrainReservationEntities.Models;
using System.Data;

namespace TrainReservationBAL
{
    public class TrainBAL
    {
        TrainDAL dal = new TrainDAL();
        public DataTable GetAllTrains()
        {
            return dal.GetAllTrains();
        }

        public bool AddTrain(Train train)
        {
            if (train.TrainNo <= 0)
                throw new Exception("Invalid Train Number");

            if (string.IsNullOrWhiteSpace(train.TrainName))
                throw new Exception("Train Name Required");

            if (string.IsNullOrWhiteSpace(train.FromStation))
                throw new Exception("Source Required");

            if (string.IsNullOrWhiteSpace(train.ToStation))
                throw new Exception("Destination Required");

            if (train.FromStation == train.ToStation)
                throw new Exception("Source and Destination cannot be same");

            if (train.Availability < 0)
                throw new Exception("Invalid Availability");

            if (train.Charges <= 0)
                throw new Exception("Invalid Charges");

            if (train.TrainClass != "2AC" &&
                train.TrainClass != "3AC" &&
                train.TrainClass != "Sleeper")
            {
                throw new Exception("Class must be 2AC / 3AC / Sleeper");
            }

            return dal.AddTrain(train);
        }

        public bool DeleteTrain(int trainNo)
        {
            if (trainNo <= 0)
                throw new Exception("Invalid Train Number");

            if (dal.HasActiveBookings(trainNo))
                throw new Exception(
                    "Cannot delete train: Active bookings exist");

            return dal.DeleteTrain(trainNo);
        }

    }
}