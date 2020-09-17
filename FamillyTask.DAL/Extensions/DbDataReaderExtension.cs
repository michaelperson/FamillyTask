using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FamillyTask.DAL.Extensions
{
    public static class DbDataReaderExtension
    {

        public static T ConvertTo<T>(this IDataReader odr)
        {
            T retour = (T)Activator.CreateInstance(typeof(T)); //si T est un membre, ==>New Membre
            PropertyInfo[] properties = typeof(T).GetProperties();// il va retrouver id, prenom,...
            for (int i = 0; i < odr.FieldCount; i++)
            {
                PropertyInfo pi = properties.FirstOrDefault(m => m.Name.ToLower() == odr.GetName(i).ToLower());// MonMembre.id =(int)odr[id];
                if (pi != null)
                {
                    if (odr.GetValue(i) == DBNull.Value) pi.SetValue(retour, null);//si dans la db c'est null,Membre.Id= null;
                    else
                    {
                        if (pi.PropertyType == typeof(int))
                        {
                            pi.SetValue(retour, int.Parse(odr.GetValue(i).ToString()));
                        }
                        if (pi.PropertyType == typeof(int?))
                        {
                            pi.SetValue(retour, int.Parse(odr.GetValue(i).ToString()));
                        }
                        if (pi.PropertyType == typeof(double))
                        {
                            pi.SetValue(retour, double.Parse(odr.GetValue(i).ToString()));
                        }
                        if (pi.PropertyType == typeof(float))
                        {
                            pi.SetValue(retour, float.Parse(odr.GetValue(i).ToString()));
                        }
                        if (pi.PropertyType == typeof(DateTime))
                        {


                            pi.SetValue(retour, odr.GetDateTime(i));


                        }
                        if (pi.PropertyType == typeof(DateTime?))
                        {


                            pi.SetValue(retour, odr.GetDateTime(i));


                        }
                        if (pi.PropertyType == typeof(string))
                        {
                            pi.SetValue(retour, odr.GetValue(i).ToString());
                        }
                    }

                }
            }
            return retour;
        }
    }
}
