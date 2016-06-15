using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameDB.Models
{
    public class Game
    {
        public int GameID { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public String Author { get; set; }

        public String ImageMimeType { get; set; }
        public byte[] ImageData { get; set; }
    }
}