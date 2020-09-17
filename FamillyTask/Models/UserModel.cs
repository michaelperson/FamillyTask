using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamillyTask.Models
{
    public class UserModel
    {
        private int _id;
        private string _nom, _prenom, _login;
        private DateTime _dateNaissance; 
        public string Token { get; set; }

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return _prenom;
            }

            set
            {
                _prenom = value;
            }
        }

        public string Login
        {
            get
            {
                return _login;
            }

            set
            {
                _login = value;
            }
        }

        public DateTime DateNaissance
        {
            get
            {
                return _dateNaissance;
            }

            set
            {
                _dateNaissance = value;
            }
        }
    }
}
