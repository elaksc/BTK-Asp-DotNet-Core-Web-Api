using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryservice;
        private readonly IAuthenticationService _authenticationService;

        public ServiceManager(IBookService bookService, 
            ICategoryService categoryservice, 
            IAuthenticationService authenticationService)
        {
            _bookService = bookService;
            _categoryservice = categoryservice;
            _authenticationService = authenticationService;
        }

        public IBookService BookService => _bookService;

        public IAuthenticationService AuthenticationService => _authenticationService;

        public ICategoryService CategoryService => _categoryservice;
    }
}
