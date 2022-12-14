using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDImporterXML.Entities;

namespace TDImporterXML.Business.Abstract
{
    public interface IUsersService
    {
        List<MBI_Users> GetAllUsers();
        MBI_Users GetUser(int userId);
        MBI_Users AddUser(MBI_Users user);
        MBI_Users UpdateUser(MBI_Users user);
        bool DeleteUser(MBI_Users user);


    }
}