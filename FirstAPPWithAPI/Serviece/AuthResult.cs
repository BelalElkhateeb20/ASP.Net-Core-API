namespace FirstAPI.Serviece
{
    public class AuthResult
    {
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
        public string _token { get; set; }
    }

}
