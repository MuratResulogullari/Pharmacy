using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pharmacy.Business.Abstract;
using Pharmacy.Business.Mvc.CurrentUser;
using Pharmacy.Business.Mvc.ModelHandler;
using Pharmacy.Business.Mvc.PasswordHash;
using Pharmacy.Core.CriteriaObjects.Bases;
using Pharmacy.Core.DataTransferObjects;
using Pharmacy.Core.DataTransferObjects.Users;
using Pharmacy.Core.Entities.Users;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Pharmacy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserSevice _userSevice;
        private readonly IRoleService _roleService;
        private readonly ICurrentUser _currentUser;
        private readonly IUserTokenService _userTokenService;
        public UserController(IConfiguration configuration
            , IUserSevice userSevice
            , IRoleService roleService
            , ICurrentUser currentUser
            , IUserTokenService userTokenService
            )
        {
            _configuration = configuration;
            _userSevice = userSevice;
            _roleService = roleService;
            _currentUser = currentUser;
            _userTokenService = userTokenService;
        }
        /// <summary>
        /// Get User infromation on claims When user was login
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        [HttpGet("GetUser")]
        public ActionResult<string> GetUser()
        {
            var userName = _currentUser.GetUserName();
            return Ok(userName);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(string tCKN, string password)
        {
            var requestResult = new RequestResult();
            var result =  _userSevice.GetByTCKN(tCKN);
            if (!result.Success)
            {
                requestResult.Success = false;
                requestResult.Result = result.Result;
                requestResult.Message = "User not found !";
            }
            else
            {
                User user = result.Result;
                if (!PasswordUtility.Verify(password, user.PasswordHash))
                {
                    requestResult.Success = false;
                    requestResult.Result = result.Result;
                    requestResult.Message = "Wrong password !";
                }
                else
                {
                    var newRefreshToken = GenerateRefreshToken();
                    newRefreshToken.Token = CreateToken(user);
                    SetRefreshToken(newRefreshToken, user);

                    requestResult.Success = true;
                    requestResult.Result = newRefreshToken.Token;
                    requestResult.Message = "Login Successfull.";
                }
            }
            return Ok(requestResult);


        }
        /// <summary>
        /// token add database and cookies
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <param name="user"></param>
        private async void SetRefreshToken(UserToken userToken, User user)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = userToken.ExpiryDate
            };
            // key = token,value = token add cookies
            Response.Cookies.Append("token", userToken.Token, cookieOptions);
            var result = _userTokenService.GetByUserId(user.Id);
            if (result.Success)
            {
                UserToken newToken = result.Result;
                newToken.Token = userToken.Token;
                newToken.ExpiryDate = userToken.ExpiryDate;
                var resultUpd = await _userTokenService.UpdateAsync(newToken);
            }
        }
        /// <summary>
        ///  create json web token and return jwt token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, string.Join(',',user.UserRoles.Select(x=>x.Role.Name).ToArray()))
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: creds);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
        /// <summary>
        /// create new token with  random token for dont not result  null
        /// </summary>
        /// <returns></returns>
        private UserToken GenerateRefreshToken()
        {
            var userToken = new UserToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                ExpiryDate = DateTime.Now.AddDays(7)
               
            };

            return userToken;
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
            var result = await _userSevice.GetByIdsAsync(new int[] { id });

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
        public async Task<ActionResult<RequestResult>> GetRoleById(int id)
        {
            return await _roleService.GetByIdsAsync(new int[] { id });
        }

    }
}