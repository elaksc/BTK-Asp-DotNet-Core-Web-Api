using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BookDto> CreateOneBookAsync(BookDtoForInsertion bookDto) {
            var entity =  _mapper.Map<Book>(bookDto);
            _manager.Book.CreateOneBook(entity);
            await _manager.SaveAsync(); 
            return _mapper.Map<BookDto>(entity);
        }

        public async Task DeleteOneBookAsync(int id, bool trackChanges)
        {
            var entity = await _manager.Book.GetOneBookByIDAsync(id, trackChanges);

            if (entity is null)
            {
                throw new BookNotFoundException(id);
            }
               
            _manager.Book.DeleteOneBook(entity);
            await _manager.SaveAsync();

            
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync(bool trackChanges)
        {
            var books = await _manager.Book.GetAllBooksAsync(trackChanges); 
            return _mapper.Map<IEnumerable<BookDto>>(books); //ilgili map işlemi gerçekleştirildi. 
        }

        public async Task<BookDto> GetOneBokByIdAsync(int id, bool trackChanges)
        {
            var book = await _manager.Book.GetOneBookByIDAsync(id, trackChanges);
            if (book is null)
            {
                throw new BookNotFoundException(id);
            }
            return _mapper.Map<BookDto>(book);
        }

        public async Task<(BookDtoForUpdate bookDtoForUpdate, Book book)> GetOneBookForPatchAsync(int id, bool trackChanges)
        {
            var book = await _manager.Book.GetOneBookByIDAsync(id, trackChanges);
            if(book is null)
            {
                throw new BookNotFoundException(id);
            }
            var bookDtoForUpdate = _mapper.Map<BookDtoForUpdate>(book);
            return (bookDtoForUpdate, book);

        }

        public async Task SaveChancesForPatchAsync(BookDtoForUpdate bookDtoForUpdate, Book book)
        {
            _mapper.Map(bookDtoForUpdate, book);
            await _manager.SaveAsync();
        }

        public async Task UpdateOneBookAsync(int id, BookDtoForUpdate bookDto,bool trackChanges)
        {
            var entity = await _manager.Book.GetOneBookByIDAsync(id, trackChanges);

            if (entity is null)
            {
                throw new BookNotFoundException(id);
            }
            //entity.Title = book.Title;
            //entity.Price = book.Price;

            //mapping
            entity = _mapper.Map<Book>(bookDto);
            _manager.Book.Update(entity);
            await _manager.SaveAsync();

        }
    }
}
