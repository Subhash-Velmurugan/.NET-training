using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainReservationDAL;
using TrainReservationEntities.Models;

namespace TrainReservationBAL
{
    public class UserBAL
    {
        UserDAL dal = new UserDAL();

        public bool Register(User user)
        {
            if (!ValidationHelper.IsValidUsername(
                user.Username))
                throw new Exception("Invalid Username");

            if (!ValidationHelper.IsValidPassword(user.Password))
            {
                throw new Exception(
                    "Password must contain uppercase, lowercase, number and be 6-15 characters long");
            }
            return dal.Register(user);
        }

        public string Login(string username,
                            string password)
        {
            return dal.Login(username, password);
        }
    }
}