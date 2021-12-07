namespace _57BlocksApiRest.Entities
{
    using System.Collections.Generic;

    public class MoviesModel
    {
        public int id { get; set; }

        /// <summary>
        /// nombre de la pelicula
        /// </summary>
        public string MovieName { get; set; }

        /// <summary>
        /// genero
        /// </summary>
        public int GenderId { get; set; }

        /// <summary>
        /// duracion
        /// </summary>
        public double Duration { get; set; }

        /// <summary>
        /// usuario que inserta el dato
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Movies gender
        /// </summary>
        public List<GenderEntity> Gender { get; set; }

        public List<Movies> DataShow { get; set; }
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
