using System.Collections.Generic;

namespace OnlineCinema.Models
{
    public class PageMovieViewModel
    {
        public PageMovieViewModel()
        {
            Items = new List<MovieViewModel>();
        }

        public List<MovieViewModel> Items { get; set; }
        public Pager Pager { get; set; }
    }
}