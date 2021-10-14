using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week4.Library.Core.Interfaces;
using Week4.Library.Core.Models;

namespace Week4.Library.LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestitiController : ControllerBase
    {
        private readonly IBusinessLayer bl;

        public PrestitiController(IBusinessLayer mainBL)
        {
            this.bl = mainBL;
        }

        [HttpPost]
        public IActionResult CreatePrestito([FromBody] Prestito newPrestito)
        {
            if (newPrestito == null)
                return BadRequest("Dati prestito non validi");

            bool isAdded = bl.AddPrestito(newPrestito);

            if (!isAdded)
                return StatusCode(500, "Prestito could not be saved");

            return CreatedAtAction("CreatePrestito", newPrestito);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePrestito(int id, Prestito prestito)
        {
            if (id <= 0 || prestito == null)
                return BadRequest("impiegato non valido"); //400-> bad request

            if (id != prestito.Id)
                return BadRequest("Gli id non combaciano");

            //update
            bl.EditPrestito(prestito);

            return Ok(prestito);
        }
    }
}
