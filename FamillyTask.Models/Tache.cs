using System;
using System.Collections.Generic;
using System.Text;

namespace FamillyTask.Models
{
    public class Tache
    {
		private int _id, _status, _idMembre;
		private string _nom, _lieu, _description;
		private DateTime _dateCreation, _dateFinAttendue;
		private DateTime? _dateFinReel; 
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

        public int Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
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

        public string Lieu
        {
            get
            {
                return _lieu;
            }

            set
            {
                _lieu = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        public DateTime DateCreation
        {
            get
            {
                return _dateCreation;
            }

            set
            {
                _dateCreation = value;
            }
        }

        public DateTime DateFinAttendue
        {
            get
            {
                return _dateFinAttendue;
            }

            set
            {
                _dateFinAttendue = value;
            }
        }

        public DateTime? DateFinReel
        {
            get
            {
                return _dateFinReel;
            }

            set
            {
                _dateFinReel = value;
            }
        }

        public int IdMembre
        {
            get
            {
                return _idMembre;
            }

            set
            {
                _idMembre = value;
            }
        }
    }
}
