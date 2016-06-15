using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameDB.Models
{
    public class Character
    {
        public int CharacterID { get; set; }
        public int ParentGameID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public String ImageMimeType { get; set; }
        public byte[] ImageData { get; set; }


    }
}