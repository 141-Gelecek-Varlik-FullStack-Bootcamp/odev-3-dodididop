using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Groot.API.Infrastructure;
using Groot.Model;
using Groot.Service.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Groot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        
        public UserController(IUserService _userService, IMapper _mapper, IMemoryCache _memoryCache) : base(_memoryCache)
        {
            userService = _userService;
            mapper = _mapper;
        }

        [HttpPost]
        [ServiceFilter(typeof(LoginFilter))]

        public General<Groot.Model.User.UserViewModel> Insert([FromBody] Groot.Model.User.UserViewModel newUser)
        {
            General<Groot.Model.User.UserViewModel> response = new General<Groot.Model.User.UserViewModel>();

            //if (CurrentUser is { Id: <= 0})
            //{
            //    response.ExceptionMessage = "Lütfen giriş yapınız.";
            //    return response;
            //}
            
            return userService.Insert(newUser);

        }
    }

    
}