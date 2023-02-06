using AgendaBlue.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaBlue.Data
{
    public class AGDDbContext : DbContext
    {
        public AGDDbContext(DbContextOptions<AGDDbContext> options) : base(options) { }

        public DbSet<AgendaEntity> AGD_BLUE { get; set; }

        internal Task FirstOrDefaltAsync(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
