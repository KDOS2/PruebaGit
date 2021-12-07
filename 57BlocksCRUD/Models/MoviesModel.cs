namespace _57BlocksCRUD.Models
{
    using _57BlocksCRUD.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class MoviesModel
    {

        public int id { get; set; }

        /// <summary>
        /// nombre de la pelicula
        /// </summary>
        [Required]
        [StringLength(500)]
        [Display(Name = "Movie name")]
        public string MovieName { get; set; }

        /// <summary>
        /// genero
        /// </summary>
        [Required]
        [Display(Name = "Gender")]
        public int GenderId { get; set; }

        /// <summary>
        /// duracion
        /// </summary>
        [Required]
        [Display(Name = "Duration")]
        public double Duration { get; set; }

        /// <summary>
        /// usuario que inserta el dato
        /// </summary>
        [Required]
        [Display(Name = "UserId")]
        public int UserId { get; set; }

        /// <summary>
        /// Movies gender
        /// </summary>
        public List<GenderEntity> Gender { get; set; }

        /// <summary>
        /// Movies gender
        /// </summary>
        public List<Movies> DataShow { get; set; }

        /// <summary>
        /// indica que vista es la que se va a trabajar
        /// </summary>
        public bool likes { get; set; }

    }

    public class Movies
    {
        public int id { get; set; }

        public string MovieName { get; set; }

        public int GenderId { get; set; }

        public double Duration { get; set; }

        public int UserId { get; set; }

        public List<GenderEntity> Gender { get; set; }

        public bool likeIt { get; set; }
    }
}
