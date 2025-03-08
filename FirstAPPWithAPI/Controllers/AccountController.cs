using AutoMapper;
using FirstAPI.Data.IdentityMangement;
using FirstAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(UserManager <ApplicationUser> userManager, IMapper mapper) : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        [Route("Register")]//api/Account/Register
        public async Task <IActionResult> Register(RegisterDto userdto)
        {
            //Create Account for user [post]
            if (ModelState.IsValid)//User Data is valid username, password, email  Requirements
            {
                //save the user to the database
                var user = _mapper.Map<ApplicationUser>(userdto);
                IdentityResult result= await _userManager.CreateAsync(user, userdto.Password); //userdto.Password to be hashed

                if (result.Succeeded)
                {
                    return Ok("User Created Successfully");
                }
                    return BadRequest(result.Errors.FirstOrDefault());
            }
            return BadRequest(ModelState);
        }
        // check if the user is already exist
    }
}
