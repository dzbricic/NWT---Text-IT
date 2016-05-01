using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ServisTextIT.Models
{
    public class TextITDbContext : DbContext
    {
        public TextITDbContext()
             : base(@"Server=tcp:textit.database.windows.net,1433;Database=TextIT;User ID=saudin@textit;Password=Ademovic123!;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
    {
        // Find out the connection string being used
        Debug.Write(Database.Connection.ConnectionString);
    }
        public DbSet<Korisnik> korisnici { get; set; }
        public DbSet<Komentar> komentari { get; set; }
        public DbSet<Tekst> tekstovi { get; set; }
        public DbSet<Grupa> grupe { get; set; }
        public DbSet<HashTag> hashtags { get; set; }

        public System.Data.Entity.DbSet<ServisTextIT.Models.Ocjena> Ocjenas { get; set; }

       
    
    }
}