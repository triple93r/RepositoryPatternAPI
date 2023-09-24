using Microsoft.EntityFrameworkCore;
using RepositoryPatternApi.Models;

namespace RepositoryPatternApi.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public virtual DbSet<Patient> Patients { get; set; }
    }

}
