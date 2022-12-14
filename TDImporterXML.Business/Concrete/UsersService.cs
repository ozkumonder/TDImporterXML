using System;
using System.Collections.Generic;
using TDImporterXML.Business.Abstract;
using TDImporterXML.DataLayer.Abstract;
using TDImporterXML.Entities;

namespace TDImporterXML.Business.Concrete
{
    public class UsersService : IUsersService
    {
        private readonly IUsersDal _usersService;

        public UsersService(IUsersDal usersService)
        {
            _usersService = usersService;
        }


        public List<MBI_Users> GetAllUsers()
        {
            return _usersService.GetList();
        }

        public MBI_Users GetUser(int userId)
        {
            return _usersService.Get(t => t.UserId == userId);
        }

        public MBI_Users AddUser(MBI_Users user)
        {
            return _usersService.Add(user);
        }

        public MBI_Users UpdateUser(MBI_Users user)
        {
            return _usersService.Update(user);
        }

        public bool DeleteUser(MBI_Users user)
        {
            return _usersService.Delete(user);
        }
    }
}