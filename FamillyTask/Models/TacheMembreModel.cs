using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamillyTask.Models
{
    public class TacheMembreModel
    {
        private string _prenom; // Vient de la table Membre
        private List<string> _nom;//Vient de la table Tache
        

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

        public List<string> Nom
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

        
    }
}