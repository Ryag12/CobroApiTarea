using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CobroApiP2.Models;

namespace CobroApiP2.DAL
{
    public class CobrosDB : DbContext
    {
        public CobrosDB(DbContextOptions<CobrosDB> options) : base(options)
        {

        }

        public DbSet<Cobros> Cobros { get; set; }
    }
}
