using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CobroApiP2.Models
{
    public class CobroApiP2Context : DbContext
    {
        public CobroApiP2Context (DbContextOptions<CobroApiP2Context> options)
            : base(options)
        {
        }

        public DbSet<CobroApiP2.Models.Cobros> Cobros { get; set; }
    }
}
