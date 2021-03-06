﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ServisTextIT.Models
{
    public class TextITDbContext : DbContext
    {
        public DbSet<Korisnik> korisnici { get; set; }
        public DbSet<Komentar> komentari { get; set; }
        public DbSet<Tekst> tekstovi { get; set; }
        public DbSet<Grupa> grupe { get; set; }
        public DbSet<HashTag> hashtags { get; set; }
    }
}