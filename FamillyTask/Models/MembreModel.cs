using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FamillyTask.Models
{
    public class MembreModel
    {
        private int _id;
        private string _prenom, _gsm;
        private DateTime _dateNaissance;
       
        [JsonIgnore]
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
        [Required]
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
        [Required]
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
        [Required]
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
   
        public int Age
        {
            get { return (DateTime.Now - DateNaissance).Days/365 ; }
        }
    
    }
}
