namespace FirstAPI.DTOs
{
    public class LoginUserDto
    {
        [Required]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
