using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using FamillyTask.DAL.Interface;
using FamillyTask.DAL.Services;
using FamillyTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamillyTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembreController : ControllerBase
    {
        IMembreService Service;
        ITacheService TService;
        public MembreController(IMembreService membreService, ITacheService tacheService)
        {
            Service = membreService;
            TService = tacheService;
        }


        /// <summary>
        /// Récupération de tous les Membres
        /// </summary>
        /// <returns>Une collection de <see cref="Membre"/></returns>
     
        [ProducesResponseType(typeof(IEnumerable<MembreModel>), 200)]
        [ProducesResponseType(404)]
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Membre> Membres = Service.Get();
            if (Membres.Count() == 0) return NotFound();
            else
                return Ok(Membres.Select(m => new MembreModel()
                {
                    Id = m.Id,
                    DateNaissance = m.DateNaissance,
                    Gsm = m.Gsm,
                    Prenom = m.Prenom

                }));
        }




        /// <summary>
        /// Récupération d'un membre à partir de son ID
        /// </summary>
        /// <param name="id">Identifiant unique du membre</param>
        /// <returns>Le <see cref="Membre"/> ou Null</returns>
        [ProducesResponseType(typeof(MembreModel), 200)]
        [ProducesResponseType(404)]
        [HttpGet]
        public IActionResult GetOne(int id)
        {
            Membre m = Service.GetOne(id);
            if (m == null) return NotFound();
            else
                return Ok(new MembreModel()
                {
                    Id = m.Id,
                    DateNaissance = m.DateNaissance,
                    Gsm = m.Gsm,
                    Prenom = m.Prenom

                });
        }

        /// <summary>
        /// Insertion d'un membre
        /// </summary>
        /// <param name="m">Le <see cref="MembreModel"/> a inserer</param>
        /// <returns>IActionResult</returns>
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(MembreModel),500)]
        [HttpPost]
        public IActionResult Post(MembreModel m)
        {
            Membre toAdd = new Membre()
            {
                Id = m.Id,
                DateNaissance = m.DateNaissance,
                Gsm = m.Gsm,
                Prenom = m.Prenom
            };

            if (!Service.Add(toAdd))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, toAdd);
            }
            else
            {
                return NoContent();
            }
        }
        /// <summary>
        /// Mise à jour d'un membre
        /// </summary>
        /// <param name="m">Le <see cref="MembreModel"/> a mettre à jour</param>
        /// <returns>IActionResult</returns>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(MembreModel), 500)]
        public IActionResult Put(Membre m)
        {
            Membre toUpdate = new Membre()
            {
                Id = m.Id,
                DateNaissance = m.DateNaissance,
                Gsm = m.Gsm,
                Prenom = m.Prenom
            };

            if (!Service.Update(toUpdate))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, toUpdate);
            }
            else
            {
                return NoContent();
            }
        }

        //Gestion des tâches        
        /// <summary>
        /// Récupération des tâches d'un membre
        /// </summary>
        /// <param name="idMembre">L'id du Membre</param>
        /// <returns>Un objet de Type <see cref="TacheModel"/></returns>
        [Route("api/Membre/{idMembre}/Taches")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TacheMembreModel>),200)]
        public IActionResult Get(int idMembre)
        {
            //Les infos du Membre
            Membre m = Service.GetOne(idMembre);
            if (m != null) return NotFound();
            return Ok(new TacheMembreModel()
            {
                Prenom = m.Prenom,
                Nom = TService.GetTachesFromMembre(idMembre).Select(t => t.Nom).ToList()
            });

        }
    }
}
