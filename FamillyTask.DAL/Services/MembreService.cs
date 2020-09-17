using FamillyTask.DAL.Interface;
using FamillyTask.DAL.Repositories;
using FamillyTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamillyTask.DAL.Services
{
    public class MembreService : BaseService<Membre, int>, IMembreService
    {
        MembreRepository repo;
        public MembreService(string ConnectionString) : base(ConnectionString)
        {
            repo = new MembreRepository(connection);
        }

        public override bool Add(Membre obj)
        {
            return repo.Add(obj);
        }

        public override bool Delete(Membre obj)
        {
            return repo.Delete(obj);
        }

        public override IEnumerable<Membre> Get()
        {
            return repo.Get();
        }

        public override Membre GetOne(int id)
        {
            return repo.GetOne(id);
        }

        public override bool Update(Membre obj)
        {
            return repo.Update(obj);
        }
    }
}
