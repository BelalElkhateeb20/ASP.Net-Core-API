namespace FirstAPI.Serviece
{
    using FirstAPPWithAPI.Data.Models;

    public interface IGenresServiece
    {
        Task<Genre> Add(Genre genre);
        Task<IEnumerable<Genre>> GetAll();
        Task<Genre> GetByID(byte id);
        Genre Update(Genre genre);
        Genre Delete(Genre genre);
    }
}
