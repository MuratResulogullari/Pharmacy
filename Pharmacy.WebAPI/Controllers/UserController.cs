using Microsoft.AspNetCore.Mvc;
using Pharmacy.Business.Abstract;
using Pharmacy.Business.Mvc.ModelHandler;
using Pharmacy.Business.Mvc.PasswordHash;
using Pharmacy.Core.CriteriaObjects.Bases;
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
        private readonly IRoleService _roleService;

        public UserController(IUserSevice userSevice
            , IRoleService roleService)
        {
            _userSevice = userSevice;
            _roleService = roleService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RequestResult>> Register(UserDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return Ok(InvalidModelHandler.GetErrorMessages(ModelState));
            }
            User entity = new User();
            PasswordUtility.Hash(dto.Password, out string passwordHash);
            if (dto.RoleIds == null || dto.RoleIds.Length == 0)
                dto.RoleIds = new int[] { 2 };

            entity.UserName = dto.UserName;
            entity.Name = dto.Name;
            entity.Surname = dto.Surname;
            entity.Email = dto.Email;
            entity.PasswordHash = passwordHash;
            entity.PhoneNumber = dto.PhoneNumber;
            entity.UserRoles = dto.RoleIds.Select(x => new UserRole { RoleId = x, UserId = entity.Id, Enable = true }).ToList();

            var result = await _userSevice.CreateAsync(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<RequestResult>> UpdateUser(UserDTO dto)
        {
            PasswordUtility.Hash(dto.Password, out string passwordHash);
            var user = new User
            {
                TCKN = dto.TCKN,
                Name = dto.Name,
                Surname = dto.Surname,
                UserName = dto.UserName,
                PasswordHash = passwordHash,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Enable = dto.Enable,
                LanguageId = dto.LanguageId,
                CreatedBy = 0
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

        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<RequestResult>> GetUserById(int id)
        {
            var result = await _userSevice.FirstOrDefaultAsync(x=>x.Id==id,new CriteriaObject { });

            return result;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<RequestResult<PagedResult>>> GetUsers()
        {
            var result = await _userSevice.GetAllAsync();
            return result;
        }

        [HttpPost("CreateRole")]
        public async Task<ActionResult<RequestResult>> CreateRoleAsync(RoleDTO dto)
        {
            RequestResult requestResult = new();
            if (!ModelState.IsValid)
                return InvalidModelHandler.GetErrorMessages(ModelState);

            var resultRole = _roleService.GetByName(dto.Name);
            if (resultRole.Success)
            {
                resultRole.Success = false;
                return BadRequest(resultRole);
            }
            else
            {
                var role = new Role
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Enable = dto.Enable,
                    NormalizedName = dto.Name.Normalize(),
                };
                return await _roleService.CreateAsync(role);
            }
        }

        [HttpPut("UpdateRole")]
        public async Task<ActionResult<RequestResult>> UpdateRoleAsync(RoleDTO dto)
        {
            if (!ModelState.IsValid)
                return InvalidModelHandler.GetErrorMessages(ModelState);
            var role = new Role
            {
                Id = dto.Id,
                Name = dto.Name,
                Enable = dto.Enable,
            };
            return await _roleService.UpdateAsync(role);
        }

        [HttpDelete("DeleteRole")]
        public async Task<ActionResult<RequestResult>> DeleteRoleAsync(RoleDTO dto)
        {
            var resultRequest = new RequestResult();
            var role = new Role
            {
                Id = dto.Id,
                Name = dto.Name,
            };
            return await _roleService.DeleteAsync(role);
        }

        [HttpGet("getRoleById/{id}")]
        public async Task<ActionResult<RequestResult>> GetRoleById(int id, string tableName)
        {
            return await _roleService.FirstOrDefaultAsync(x => x.Id == id, new CriteriaObject { });
        }

        [HttpGet("getRoles")]
        public async Task<ActionResult<RequestResult<List<Role>>>> GetRoles()
        {
            return await _roleService.ToListAsync(x => x.Enable, new ToListCriteriaObject { });
        }
    }
}