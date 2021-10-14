using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week4.Library.Core;
using Week4.Library.Core.BusinessLayer;
using Week4.Library.Core.Interfaces;

namespace Week4.Library.LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBusinessLayer bl;

        public BooksController(IBusinessLayer mainBL)
        {
            this.bl = mainBL;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var books = bl.FetchBooks();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Id non valido");

            Book book = bl.GetById(id);

            if(book == null)
            {
                return NotFound("Book not found");
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody]Book newBook)
        {
            if (newBook == null)
                return BadRequest("Dati libro non validi");

            bool isAdded = bl.AddBook(newBook);

            if (!isAdded)
                return StatusCode(500, "Book could not be saved");

            return CreatedAtAction("CreateBook", newBook);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            if (id <= 0 || book == null)
                return BadRequest("impiegato non valido"); //400-> bad request

            if (id != book.Id)
                return BadRequest("Gli id non combaciano");

            //update
            book.Author = "Tonio";
            bl.EditBook(book);

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            if (id <= 0)
                return BadRequest("Id non valido");

            bool isAdded = bl.DeleteBook(id);

            if (!isAdded)
                return StatusCode(500, "Book could not be deleted");

            return Ok();
        }
    }
}
