using FamillyTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FamillyTask.DAL.Repositories
{
    public class UsersReposiotry : BaseRepository<Users, int>
    {
        public UsersReposiotry(IDbConnection connection) : base(connection)
        {

        }

        public override bool Add(Users obj)
        {
            throw new NotImplementedException();
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

        public  Users GetByLoginPass(Users partialUser)
        {
            return base.ExecuteReaderWithParameters("Select * from Users Where Login=@Login and Password=@Password", System.Data.CommandType.Text, partialUser).FirstOrDefault();
        }

        public override bool Update(Users obj)
        {
            throw new NotImplementedException();
        }
    }
}
