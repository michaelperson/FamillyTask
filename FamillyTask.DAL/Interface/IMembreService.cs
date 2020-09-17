using FamillyTask.Models;
using System.Collections.Generic;

namespace FamillyTask.DAL.Interface
{
    public interface IMembreService
    {
        bool Add(Membre obj);
        bool Delete(Membre obj);
        IEnumerable<Membre> Get();
        Membre GetOne(int id);
        bool Update(Membre obj);
    }
}