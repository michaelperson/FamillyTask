using System;
using System.Collections.Generic;

namespace FamillyTask.Models
{
    public class Membre
    {
        private int _id;
        private string _prenom, _gsm;
        private DateTime _dateNaissance;
       
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

        public string Gsm
        {
            get
            {
                return _gsm;
            }

            set
            {
                _gsm = value;
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
