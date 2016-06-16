using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }
        // comment showing nothing

        public string Description { get; set; }

        [Required]
        public String Author { get; set; }

        public String ImageMimeType { get; set; }
        public byte[] ImageData { get; set; }
    }
}