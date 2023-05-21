using Microsoft.AspNetCore.Mvc;
using Pharmacy.Business.Abstract;
using Pharmacy.Business.Mvc.ModelHandler;
using Pharmacy.Business.Mvc.PasswordHash;
using Pharmacy.Core.DataTransferObjects;
using Pharmacy.Core.DataTransferObjects.Users;
using Pharmacy.Core.Entities.Users;

namespace Pharmacy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserSevice _userSevice;

        public UserController(IUserSevice userSevice)
        {
            _userSevice = userSevice;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<RequestResult>> CreateUser(UserDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return Ok(InvalidModelHandler.GetErrorMessages(ModelState));
            }
            User entity = new User();
            PasswordUtility.HMACSHA512Passworder(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            if (dto.RoleIds == null || dto.RoleIds.Length == 0)
                dto.RoleIds = new int[] { 2 };

            entity.UserName = dto.UserName;
            entity.Name = dto.Name;
            entity.Surname = dto.Surname;
            entity.EmailAddress = dto.EmailAddress;
            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;
            entity.Phone = dto.Phone;
            entity.UserRoles = dto.RoleIds.Select(x => new UserRole { RoleId = x, UserId = entity.Id, Enable = true }).ToList();

            var result = await _userSevice.CreateAsync(entity);

            return Ok(result);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<RequestResult>> UpdateUser(UserDTO dto)
        {
            PasswordUtility.HMACSHA512Passworder(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                Name = dto.Name,
                Surname = dto.Surname,
                UserName = dto.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                TCKN = dto.TCKN,
                EmailAddress = dto.EmailAddress,
                Phone = dto.Phone
            };
            var result = await _userSevice.UpdateAsync(user);

            return result;
        }

        [HttpDelete("DeleteUser")]
        public async Task<ActionResult<RequestResult>> DeleteUser(UserDTO dto)
        {
            var result = await _userSevice.DeleteAsync(new User { Id = dto.Id });
            return result;
        }

        //[HttpGet("GetUserById/{id}")]
        //public async Task<ActionResult<RequestResult>> GetUserById(int id)
        //{
        //    string[] properties = { "UserRoles" };
        //    var result = await _userSevice.FirstOrDefaultAsync(x => x.Id == id && x.Enable, new Domain.CriteriaObjects.Base.CriteriaObject
        //    {
        //        Includes = properties
        //    });

        //    return result;
        //}

        //[HttpGet("GetUsers")]
        //public async Task<ActionResult<RequestResult>> GetUsers()
        //{
        //    var result = await _userSevice.GetAllAsync();
        //    return result;
        //}
    }
}