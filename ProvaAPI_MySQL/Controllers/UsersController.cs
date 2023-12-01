using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProvaAPI_MySQL.Database;
using ProvaAPI_MySQL.Entity;
using ProvaAPI_MySQL.Model;
using ProvaAPI_MySQL.Model.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProvaAPI_MySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UsersController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("{idUser}")]
        public IActionResult GetUserById(int idUser)
        {
            UserEntity user = _userRepository.GetUserById(idUser);

            if (user == null)
                return NotFound();

            UserModel u = MapUserEntityToUserModel(user);

            return Ok(u);
        }

        [HttpGet]
        public IActionResult AllUsers(string? name)
        {
            if (name == null)
            {
                List<UserEntity> allUsers = _userRepository.GetAllUsers();
                List<UserModel> us = allUsers.Select(MapUserEntityToUserModel).ToList();

                if (us.Count == 0)
                    return NotFound();

                return Ok(us);
            }

            List<UserEntity> users = _userRepository.GetUsersByName(name);

            if (users == null)
            {
                return NotFound();
            }

            List<UserModel> u = users.Select(MapUserEntityToUserModel).ToList();

            return Ok(u);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserRequest userRequest)
        {
            var user = new UserEntity
            {
                UserName = userRequest.UserName,
                Password = userRequest.Password,
                Name = userRequest.Name,
                Surname = userRequest.SurName
            };

            _userRepository.AddUser(user);

            return Ok();
        }

        [HttpPut]
        [Route("{idUser}")]
        public IActionResult UpdateUser([FromBody] UserEntity user, int idUser)
        {
            bool result = _userRepository.UpdateUser(user, idUser);

            if (!result)
                return NotFound();

            return Ok(idUser);
        }

        [HttpDelete]
        [Route("{idUser}")]
        public IActionResult DeleteUser([FromRoute] int idUser)
        {
            bool result = _userRepository.DeleteUser(idUser);

            if (!result)
                return NotFound();

            return Ok();
        }

        private UserModel MapUserEntityToUserModel(UserEntity user)
        {
            return new UserModel
            {
                IdUser = user.IdUser,
                UserName = user.UserName,
                Password = user.Password,
                Name = user.Name,
                Surname = user.Surname
            };
        }
    }
}

