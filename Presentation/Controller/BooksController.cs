﻿using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [ServiceFilter(typeof(LogFilterAttribute))]
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
        public async Task<IActionResult> GetAllBooksAsync([FromQuery]BookParameters bookParameters) // FromQuery kullandığımız zaman biliyoruz ki bu ifadeler bir query string üzerinden gelicek.
        {
            var pagedResult = await _manager
                .BookService
                .GetAllBooksAsync(bookParameters, false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.books);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBookAsync([FromRoute(Name = "id")] int id)
        {
            var book = await _manager.BookService.GetOneBokByIdAsync(id, false);
            if (book is null)
                throw new BookNotFoundException(id);
            return Ok(book);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))] //Bunun sayesinde aşağıdaki kod bloklarına ihtiyaç olmayacak
        [HttpPost]
        public async Task<IActionResult> CreateOneBookAsync([FromBody] BookDtoForInsertion bookDto)
        {
            var book = await _manager.BookService.CreateOneBookAsync(bookDto);
            return StatusCode(201, book); //CreatedAtRoute()
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))] //Bunun sayesinde aşağıdaki kod bloklarına ihtiyaç olmayacak
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBookAsync([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
        {
          
            await _manager.BookService.UpdateOneBookAsync(id, bookDto, false);
            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneBookAsync([FromRoute(Name = "id")] int id)
        {
            await _manager.BookService.DeleteOneBookAsync(id, false);
            return NoContent();
        }


        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateOneBookAsync([FromRoute] int id, [FromBody] JsonPatchDocument<BookDtoForUpdate> bookPatch)
        {
            if(bookPatch is null)
            {
                return BadRequest();
            }
            var result = await _manager.BookService.GetOneBookForPatchAsync(id, false);

            bookPatch.ApplyTo(result.bookDtoForUpdate,ModelState);

            TryValidateModel(result.bookDtoForUpdate);
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            await _manager.BookService.SaveChancesForPatchAsync(result.bookDtoForUpdate, result.book);
            return NoContent();
        }

    }

}
