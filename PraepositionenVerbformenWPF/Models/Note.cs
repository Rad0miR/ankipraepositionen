using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForEF.Models
{
    internal class Note
    {
        public int Id { get; set; }

        public string GermanShort { get; set; } = null!;

        public string GermanFull { get; set; } = null!;

        public string Definition { get; set; } = null!;

        public string? Example { get; set; }
    }
}
