namespace FirstAPI.IServieces
{
    using FirstAPI.DTOs;
    using FirstAPI.Serviece;

    public interface IAuthServiece
    {
        Task<AuthResult> RegisterAsync(RegisterDto userDto);
        Task<AuthResult> LoginAsync(LoginUserDto userDto);
    }
}

