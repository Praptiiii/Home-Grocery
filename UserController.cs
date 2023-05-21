using AutoMapper;
using HomeGrocery.DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HomeGrocery.BLL.DTO;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Net;
using HomeGrocery.DAL.Models;
using HomeGrocery.DAL.Repository.Interface;


namespace HomeGrocery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _dbUser;
        private readonly IMapper _mapper;
        public UserController(IUser dbUser, IMapper mapper)
        {
            _dbUser = dbUser;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserDTO dto)
        {
            User model = _mapper.Map<User>(dto);
            await _dbUser.CreateAsync(model);

            return Ok(model);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            IEnumerable<User> userlist = await _dbUser.GetAllAsync();
            return Ok(_mapper.Map<List<UserDTO>>(userlist));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var pro = await _dbUser.GetByIDAsync(x => x.UserID == id);
            if (pro == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserDTO>(pro));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var prod = await _dbUser.GetByIDAsync(x => x.UserID == id);
            if (prod == null)
            {
                return NotFound();
            }

            await _dbUser.RemoveAsync(prod);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO dto)
        {
            if (dto == null || id != dto.UserID)
            {
                return BadRequest();
            }
            User model = _mapper.Map<User>(dto);

            await _dbUser.UpdateAsync(model);
            return NoContent();



        }
    }
}
