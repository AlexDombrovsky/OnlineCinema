using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineCinema.Models;

namespace OnlineCinema.Interfaces
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAll();
        Task<Movie> GetById(int? id);
        Task<Movie> Add(Movie entity);
        Task<Movie> Update(Movie movie);
        Task<bool> Delete(int id);
        Task<List<Movie>> MoviePerPages(int page, int pageSize);
        Task<int> MovieCount();
    }
}