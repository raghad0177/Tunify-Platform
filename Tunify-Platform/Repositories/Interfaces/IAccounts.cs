﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using Tunify_Platform.Models.DTO;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IAccounts
    {
        // Add register
        public Task<RegisterDto> Register(RegisterDto registerdUserDto, ModelStateDictionary modelState);
        // Add login
        public Task<RegisterDto> UserAuthentication(string username, string password);
        // LougOut
        public Task<RegisterDto> LogOut(LogOutDto user);
        //Generate JWT Token
        public Task<RegisterDto> GetToken(ClaimsPrincipal claimsPrincipal);
    }
}