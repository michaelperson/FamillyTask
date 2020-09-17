using FamillyTask.DAL.Repositories;
using FamillyTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamillyTask.DAL.Services
{
    public class UsersService : BaseService<Users, int>, IUsersService
    {
        UsersReposiotry repo;
        public UsersService(string ConnectionString) : base(ConnectionString)
        {
            repo = new UsersReposiotry(connection);
        }

        public override bool Add(Users id)
        {
            throw new NotImplementedException();
        }

        public Users CheckLogin(string Login, String Passwd)
        {
            Users users = new Users() { Login = Login, Password = Passwd };
            return repo.GetByLoginPass(users);
        }

        public override bool Delete(Users id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Users> Get()
        {
            throw new NotImplementedException();
        }

        public override Users GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Users obj)
        {
            throw new NotImplementedException();
        }
    }
}
