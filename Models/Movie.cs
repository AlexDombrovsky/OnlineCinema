using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace OnlineCinema.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ReleaseYear { get; set; }
        public string Producer { get; set; }
        public string User { get; set; }
        public string Image { get; set; }
    }

    public class MovieViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [DisplayName("Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(400)]
        [DisplayName("Описание (не более 400 символов")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [DisplayName("Год выпуска")]
        public string ReleaseYear { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [DisplayName("Режиссер")]
        public string Producer { get; set; }

        public string User { get; set; }

        [DisplayName("Постер")] public string Image { get; set; }

        public IFormFile File { get; set; }
    }
}