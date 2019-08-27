using Lands.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Helpers
{
    public static class Converter
    {
        public static UserLocal ToUserLocal(UserInfo user)
        {
            return new UserLocal()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Telephone = user.Telephone,
                ImagePath = (string) user.ImagePath,
                UserId = (int) user.UserId,
                UserTypeId = user.UserTypeId
            };
        }

        public static UserInfo ToUserInfo(UserLocal user)
        {
            return new UserInfo()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Telephone = user.Telephone,
                ImagePath = user.ImagePath,
                UserId = user.UserId,
                UserTypeId = user.UserTypeId
            };
        }
    }
}
