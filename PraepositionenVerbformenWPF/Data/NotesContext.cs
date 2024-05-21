using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestForEF.Models;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace PraepositionenVerbformenWPF.Data
{
    internal class NotesContext : DbContext
    {
        public DbSet<Note> Notes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DBforPrepositions"].ConnectionString);
        }
    }
}
