using System;
using System.Collections.Generic;
using System.Text;

namespace FamillyTask.Models
{
    public class Users
    {
        private int _id;
        private string _nom, _prenom, _login;
        private DateTime _dateNaissance;
        private string _password;

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

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }
    }
}
