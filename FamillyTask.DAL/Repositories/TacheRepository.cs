using FamillyTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FamillyTask.DAL.Repositories
{
    public class TacheRepository : BaseRepository<Tache, int>
    {

        public TacheRepository(IDbConnection connection) : base(connection)
        {

        }
        public override IEnumerable<Tache> Get()
        {
            return base.ExecuteReader("select * from Tache");
        }

        public override Tache GetOne(int id)
        {

            return base.ExecuteReader($"select * from Tache where Id={id}").FirstOrDefault();
        }
        public override bool Add(Tache obj)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[Tache]
                               ([Nom]
                               ,[Description]
                               ,[DateCreation]
                               ,[DateFinAttendue]
                               ,[DateFinReel]
                               ,[Lieu]
                               ,[Status])
                         VALUES
                               (@Nom,@Description,@DateCreation,@DateFinAttendue,@DateFinReel,@Lieu, @Status)";

                base.InsertOrUpdateData(query, obj);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public override bool Update(Tache obj)
        {
            try
            {
                string query = @"UPDATE [dbo].[Tache]
                                   SET [Nom] = @Nom 
                                      ,[Description] = @Description 
                                      ,[DateCreation] = @DateCreation 
                                      ,[DateFinAttendue] = @DateFinAttendue 
                                      ,[DateFinReel] = @DateFinReel 
                                      ,[Lieu] = @Lieu 
                                      ,[Status] = @Status 
                                 WHERE Id=@Id";

                base.InsertOrUpdateData(query, obj);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public override bool Delete(Tache id)
        {
            try
            {
                base.ExecuteNonQuery($"Delete From Tache Where Id={id}");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //Gestion des Membres
        public bool AddMembre(int idTache, int idMembre)
        {
            try
            {
                string Query = $"Update Tache SET idMembre={idMembre} WHERE Id={idTache}";
                base.ExecuteNonQuery(Query);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public IEnumerable<Tache> GetFromMembre(int IdMembre)
        {
            return base.ExecuteReader($"select * from Tache where IdMembre={IdMembre}");
        }
    }
}
