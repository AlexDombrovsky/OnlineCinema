using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineCinema.Data;
using OnlineCinema.Interfaces;
using OnlineCinema.Models;

namespace OnlineCinema.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Movie>> GetAll()
        {
            var result = await _dbContext.Movies.OrderBy(_ => _.Id).ToListAsync();
            return result;
        }

        public async Task<Movie> GetById(int? id)
        {
            var result = await _dbContext.Movies.FindAsync(id);
            return result;
        }

        public async Task<Movie> Add(Movie entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Movie> Update(Movie movie)
        {
            _dbContext.Movies.Update(movie);
            await _dbContext.SaveChangesAsync();
            return movie;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _dbContext.Movies.FindAsync(id);
            _dbContext.Movies.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Movie>> MoviePerPages(int page, int pageSize)
        {
            var result = await _dbContext.Movies.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return result;
        }

        public async Task<int> MovieCount()
        {
            var count = await _dbContext.Movies.CountAsync();
            return count;
        }
    }
}