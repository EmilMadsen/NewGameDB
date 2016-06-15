using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameDB.Models
{
    public class GameWithChars
    {
        public Game Game { get; set; }
        public IEnumerable<Character> Characters { get; set; }
    }
}