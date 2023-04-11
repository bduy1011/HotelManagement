﻿using Hotel_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection= GetConnection())
            using (var command =new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from [User] cwhere username=@username and [password]=@password";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        void IUserRepository.Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        void IUserRepository.Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        IEnumerable<UserModel> IUserRepository.GetByAll()
        {
            throw new NotImplementedException();
        }

        UserModel IUserRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        UserModel IUserRepository.GetByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
