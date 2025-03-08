namespace FirstAPI.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(5, ErrorMessage = "Password must be at least 5 characters long")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }



    }
}
