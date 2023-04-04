using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }


        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _manager.BookService.GetAllBooks(false);
            return Ok(books);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            var book = _manager.BookService.GetOneBokById(id, false);
            if (book is null)
                throw new BookNotFoundException(id);
            return Ok(book);
        }


        [HttpPost]
        public IActionResult CreateOneBook([FromBody] BookDtoForInsertion bookDto)
        {
            if (bookDto is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var book = _manager.BookService.CreateOneBook(bookDto);
            return StatusCode(201, book); //CreatedAtRoute()
            return Ok();
        }


        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
        {
            if (bookDto is null)
                return BadRequest(); //400
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            _manager.BookService.UpdateOneBook(id, bookDto, false);
            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            _manager.BookService.DeleteOneBook(id, false);
            return NoContent();
        }


        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute] int id, [FromBody] JsonPatchDocument<BookDto> bookPatch)
        {
            var bookDto = _manager.BookService.GetOneBokById(id, true);
            bookPatch.ApplyTo(bookDto);
            _manager.BookService.UpdateOneBook(id, new BookDtoForUpdate()
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                Price = bookDto.Price
            }, true);
            return NoContent();
        }

    }

}
