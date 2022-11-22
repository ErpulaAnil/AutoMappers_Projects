using AutoMapper;
using AutoMappers_Project.Dtos;
using AutoMappers_Project.Entities;
using AutoMappers_Project.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMappers_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        //[HttpPost]  
        //public ActionResult<int> UserAdd(User user)
        //{
        //    var result = _userRepository.CreateUser(user);
        //    if (result == 200)
        //    {
        //        return result;
        //    }
        //    else
        //    {
        //        return 500;
        //    }
        //}

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<UserReadDto> Post(UserCreateDto user)
        {
            var userToCreate = _mapper.Map<User>(user);
            var createdUser = _userRepository.CreateUser(userToCreate);

            return Ok(_mapper.Map<UserReadDto>(createdUser));
        }

        [HttpGet("{id}")]
        public ActionResult<UserReadDto> UserGet(Guid id)
        {
            var result = _userRepository.GetUserById(id);
            //var userReadDto = new UserReadDto()
            //{
            //    Email = user.Email,
            //    FullName = $"{user.FirstName} {user.LastName}",
            //    Age = HelperFunctions.HelperFunctions.GetCurrentAge(user.DateOfBirth)
            //};

            var _userReadDto = _mapper.Map<UserReadDto>(result);
            return Ok(_userReadDto);
        }


        [HttpGet]
        public ActionResult<List<UserReadDto>> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
           var _userReadDto = _mapper.Map<List<UserReadDto>>(users);
            return Ok(_userReadDto);
        }
    }
}
