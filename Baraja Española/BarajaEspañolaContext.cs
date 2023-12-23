using Baraja_Española.Models;
using Microsoft.EntityFrameworkCore;

namespace Baraja_Española
{
    public class BarajaEspañolaContext: DbContext
    {
        public DbSet<NaipeModel> Naipes { get; set; }

        public BarajaEspañolaContext(DbContextOptions<BarajaEspañolaContext> options) : base(options) { }
    }
}
