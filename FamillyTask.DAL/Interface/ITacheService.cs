using FamillyTask.Models;
using System.Collections.Generic;

namespace FamillyTask.DAL.Interface
{
    public interface ITacheService
    {
        bool Add(Tache obj);
        bool AddMembre(int idTache, int idMembre);
        bool Delete(Tache obj);
        IEnumerable<Tache> Get();
        Tache GetOne(int id);
        IEnumerable<Tache> GetTachesFromMembre(int idMembre);
        bool Update(Tache obj);
    }
}