using FirstAPI.DTOs;
using FirstAPI.IServieces;


namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAuthServiece authServiece) : ControllerBase
    {
        private readonly IAuthServiece _authServiece = authServiece;

        [HttpPost]
        [Route("Register")]//api/Account/Register
        public async Task<IActionResult> Register(RegisterDto userdto)
        {
            //Create Account for user [post]
            if (ModelState.IsValid)//User Data is valid username, password, email  Requirements
            {
                ////save the user to the database
                var result = await _authServiece.RegisterAsync(userdto);
                if (result.IsSuccess)
                {
                    return Ok("User Created Successfully");
                }
                return BadRequest(result.Errors);
            }
            return BadRequest(ModelState);
        }
        // check if the user is already exist
        [HttpPost]
        [Route("Login")]//api/Account/Register
        public async Task<IActionResult> Login(LoginUserDto userdto)
        {
            var result = await _authServiece.LoginAsync(userdto);
            if (result.IsSuccess)
            {
                return Ok(new { Token = result._token });
            }
            return BadRequest(result.Errors);
        }

    }
}
