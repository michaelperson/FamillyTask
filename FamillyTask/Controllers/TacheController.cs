using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamillyTask.DAL.Interface;
using FamillyTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamillyTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacheController : ControllerBase
    {
        ITacheService Service;
        public TacheController(ITacheService service)
        {
            Service = service;
        }
        /// <summary>
        /// Récupération de tous les tâches
        /// </summary>
        /// <returns>Une collection de <see cref="TacheModel"/></returns>
         [HttpGet]
         [ProducesResponseType(typeof(IEnumerable<TacheModel>),200)]
         [ProducesResponseType(404)]
        public IActionResult Get()
        {
            IEnumerable<Tache> Taches = Service.Get();
            if (Taches.Count() == 0) return NotFound();
            return Ok(Taches.Select(m => new TacheModel()
            {
                Id = m.Id,
                DateCreation = m.DateCreation,
                DateFinAttendue = m.DateFinAttendue,
                DateFinReel = m.DateFinReel,
                Description = m.Description,
                Lieu = m.Lieu,
                Nom = m.Nom,
                Status = m.Status

            }));
        }


        /// <summary>
        /// Récupération d'une Tâche à partir de son ID
        /// </summary>
        /// <param name="id">Identifiant unique de la Tâche</param>
        /// <returns>La <see cref="TacheModel"/> ou Null</returns>
        [HttpGet]
        [ProducesResponseType(typeof(TacheModel), 200)]
        [ProducesResponseType(404)]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            Tache m = Service.GetOne(id);
            if (m == null) return NotFound(); 
            return Ok( new TacheModel()
            {
                Id = m.Id,
                DateCreation = m.DateCreation,
                DateFinAttendue = m.DateFinAttendue,
                DateFinReel = m.DateFinReel,
                Description = m.Description,
                Lieu = m.Lieu,
                Nom = m.Nom,
                Status = m.Status

            });
        }
        /// <summary>
        /// Insertion d'une tâche
        /// </summary>
        /// <param name="m">La <see cref="TacheModel"/> a inserer</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(TacheModel), 500)]
        public IActionResult Post(TacheModel m)
        {
            Tache toAdd = new Tache()
            {
                Id = m.Id,
                DateCreation = m.DateCreation,
                DateFinAttendue = m.DateFinAttendue,
                DateFinReel = m.DateFinReel,
                Description = m.Description,
                Lieu = m.Lieu,
                Nom = m.Nom,
                Status = m.Status
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
        /// Mise à jour d'une tâche
        /// </summary>
        /// <param name="m">La <see cref="TacheModel"/> a mettre à jour</param>
        /// <returns>IActionResult</returns>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(TacheModel), 500)]
        public IActionResult Put(TacheModel m)
        {
            Tache toUpdate = new Tache()
            {
                Id = m.Id,
                DateCreation = m.DateCreation,
                DateFinAttendue = m.DateFinAttendue,
                DateFinReel = m.DateFinReel,
                Description = m.Description,
                Lieu = m.Lieu,
                Nom = m.Nom,
                Status = m.Status
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


        //Ajouter un membre à une tache
        // api/Tache/1/Membre/5        
        /// <summary>
        /// Permet d'attribuer une tâche à un membre
        /// </summary>
        /// <param name="idTache">L'id de la tâche</param>
        /// <param name="idMembre">L'id du membre.</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(TacheModel), 500)]
        [Route("api/Tache/{idTache}/Membre/{idMembre}")]
        public IActionResult Post(int idTache, int idMembre)
        {
            bool success = Service.AddMembre(idTache, idMembre);
            if (success) return NoContent();
            else return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}

