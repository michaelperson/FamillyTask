using FamillyTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FamillyTask.DAL.Repositories
{
    /// <summary>
    /// Repository encapsulatn la lo
    /// </summary>
    /// <seealso cref="FamillyTask.DAL.BaseRepository{FamillyTask.Models.Membre, System.Int32}" />
    public class MembreRepository : BaseRepository<Membre,int>
    {
        public MembreRepository(IDbConnection connection) : base(connection)
        {
        }
        public override IEnumerable<Membre> Get()
        {
            return base.ExecuteReader("select * from Membre");

        }
        public override Membre GetOne(int id)
        {
            return base.ExecuteReader($"select * from Membre where Id={id}").FirstOrDefault();
        }
        public override bool Add(Membre obj)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[Membre]
                           ([Prenom]
                           ,[DateNaissance]
                           ,[Gsm])
                     VALUES
                           (@Prenom,@DateNaissance,@Gsm)";

                base.InsertOrUpdateData(query, obj);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public override bool Update(Membre obj)
        {
            try
            {
                string query = @"UPDATE [dbo].[Membre]
                                   SET [Prenom] = @Prenom
                                      ,[DateNaissance] = @DateNaissance
                                      ,[Gsm] = @Gsm
                                 WHERE Id=@Id";

                base.InsertOrUpdateData(query, obj);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public override bool Delete(Membre id)
        {
            try
            {
                base.ExecuteNonQuery($"Delete from Membre where Id={id}");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
