namespace FirstAPI.Serviece
{
    using AutoMapper;
    using FirstAPI.Data.IdentityMangement;
    using FirstAPI.DTOs;
    using FirstAPI.IServieces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class AuthService(UserManager<ApplicationUser> userManager, IMapper mapper,IConfiguration configuration) : IAuthServiece
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IMapper _mapper = mapper;
        private readonly IConfiguration configuration = configuration;

        public async Task<AuthResult> RegisterAsync(RegisterDto userDto)
        {
            var user = _mapper.Map<ApplicationUser>(userDto);
            IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);
            if (result.Succeeded)
            {
                return new AuthResult { IsSuccess = true };
            }

            return new AuthResult
            {
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description).ToList()
            };
        }

        public async Task<AuthResult> LoginAsync(LoginUserDto userDto)
        {
            ApplicationUser? user = await _userManager.FindByNameAsync(userDto.UserName);
            if (user != null) //Found
            {
                var found = await _userManager.CheckPasswordAsync(user, userDto.Password);
                if (found)
                {
                    //create Token
                    var token = GenerateJwtToken(user);
                    return new AuthResult { IsSuccess = true, _token =token };
                }
                return new AuthResult { IsSuccess = false, Errors = ["Invalid UserName or password"] };
            }
            return new AuthResult { IsSuccess = false, Errors = ["Invalid UserName or password"] };
        }
        private string GenerateJwtToken(ApplicationUser user)
        {
            var claims = new List<Claim>{
            new (ClaimTypes.Name, user.UserName!),
            new (ClaimTypes.NameIdentifier, user.Id),
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())}; 
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            SigningCredentials signingCredentials = new (securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken mytoken = new(
                issuer: configuration["Jwt:ValidIssuer"],
                audience: configuration["Jwt:ValidAudience"],
                claims: claims,
                 expires: DateTime.Now.AddMinutes(Convert.ToDouble(configuration["Jwt:ExpiresInMinutes"])),
                 signingCredentials: signingCredentials
                );
            return new JwtSecurityTokenHandler().WriteToken(mytoken);

        }

    }
}
