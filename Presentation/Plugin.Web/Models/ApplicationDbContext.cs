using Microsoft.EntityFrameworkCore;

namespace Plugin.web.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}