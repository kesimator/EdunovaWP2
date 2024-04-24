﻿using F1TimoviAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace F1TimoviAPP.Data
{
    /// <summary>
    /// Ovo mi je datoteka gdje ću navoditi datasetove i načine spajanja u bazi
    /// </summary>
    public class EdunovaContext : DbContext
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="options"></param>
        public EdunovaContext(DbContextOptions<EdunovaContext> options)
            : base(options)
        {

        }
        /// <summary>
        /// Timovi u bazi
        /// </summary>
        public DbSet<Tim> Timovi { get; set; }
    }
}
