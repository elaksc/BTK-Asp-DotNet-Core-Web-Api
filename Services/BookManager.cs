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

        public Book CreateOneBook(Book book) { 
            _manager.Book.CreateOneBook(book);
            _manager.Save(); 
            return book;
        }

        public void DeleteOneBook(int id, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookByID(id, trackChanges);

            if (entity is null)
            {
                throw new BookNotFoundException(id);
            }
               
            _manager.Book.DeleteOneBook(entity);
            _manager.Save();

            
        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            return _manager.Book.GetAllBooks(trackChanges);
        }

        public Book GetOneBokById(int id, bool trackChanges)
        {
            var book = _manager.Book.GetOneBookByID(id,trackChanges);
            if(book is null)
            {
                throw new BookNotFoundException(id);
            }
            return book;
        }

        public void UpdateOneBook(int id, BookDtoForUpdate bookDto,bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookByID(id, trackChanges);

            if (entity is null)
            {
                throw new BookNotFoundException(id);
            }
            //entity.Title = book.Title;
            //entity.Price = book.Price;

            //mapping
            entity = _mapper.Map<Book>(bookDto);
            _manager.Book.Update(entity);
            _manager.Save();

        }
    }
}
