﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : Repository<BaseEntity>
    {
        public static readonly UserRepository Instance = new UserRepository();

        static UserRepository() { }

        public BaseEntity? GetByUsername(string username)
        {
            return _items.FirstOrDefault(item => item.Username == username);
        }

        public void ChangePassword(Guid userId, string newPassword)
        {
            var user = _items.FirstOrDefault(item => item.Id == userId);

            if (user != null)
            {
                user.Password = newPassword;
            }
            else
            {
                throw new Exception("User not found.");
            }
        }
    }
}
