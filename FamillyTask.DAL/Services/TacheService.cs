using FamillyTask.DAL.Interface;
using FamillyTask.DAL.Repositories;
using FamillyTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamillyTask.DAL.Services
{
    public class TacheService : BaseService<Tache, int>, ITacheService
    {
        TacheRepository repo;
        public TacheService(string ConnectionString) : base(ConnectionString)
        {
            repo = new TacheRepository(connection);
        }

        public override bool Add(Tache obj)
        {
            return repo.Add(obj);
        }

        public override bool Delete(Tache obj)
        {
            return repo.Delete(obj);
        }

        public override IEnumerable<Tache> Get()
        {
            return repo.Get();
        }

        public override Tache GetOne(int id)
        {
            return repo.GetOne(id);
        }

        public override bool Update(Tache obj)
        {
            return repo.Update(obj);
        }


        //Gestion Membre
        public bool AddMembre(int idTache, int idMembre)
        {
            return repo.AddMembre(idTache, idMembre);
        }

        public IEnumerable<Tache> GetTachesFromMembre(int idMembre)
        {
            return repo.GetFromMembre(idMembre);
        }
    }
}
