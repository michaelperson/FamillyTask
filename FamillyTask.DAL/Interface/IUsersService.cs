using FamillyTask.Models;
using System.Collections.Generic;

namespace FamillyTask.DAL.Interface
{
    public interface IUsersService
    {
        bool Add(Users id);
        Users CheckLogin(string Login, string Passwd);
        bool Delete(Users id);
        IEnumerable<Users> Get();
        Users GetOne(int id);
        bool Update(Users obj);
    }
}