﻿using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        private User? _user;

        public AuthenticationManager(ILoggerService logger,
            IMapper mapper, 
            UserManager<User> userManager, 
            IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> RegisterUser(UserForRegistirationDto userForRegistirationDto)
        {
            var user = _mapper.Map<User>(userForRegistirationDto);
            var result = await _userManager.CreateAsync(user, userForRegistirationDto.Password);

            if(result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, userForRegistirationDto.Roles);
            }
            return result;
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto)
        {
            _user = await _userManager.FindByNameAsync(userForAuthenticationDto.UserName);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuthenticationDto.Password));
            if (!result)
                _logger.LogWarning($"{nameof(ValidateUser)} : Authentication failder. Wrong username or password");
            return result;
        }
    }
}