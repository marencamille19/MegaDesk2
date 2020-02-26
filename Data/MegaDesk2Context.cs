using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDesk2.Models;

namespace MegaDesk2.Data
{
    public class MegaDesk2Context : DbContext
    {
        public MegaDesk2Context (DbContextOptions<MegaDesk2Context> options)
            : base(options)
        {
        }

        public DbSet<MegaDesk2.Models.Desk> Desk { get; set; }
    }
}
