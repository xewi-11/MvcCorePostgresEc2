using Microsoft.EntityFrameworkCore;
using MvcCorePostgresEc2.Models;

namespace MvcCorePostgresEc2.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamentos { get; set; }
    }
}
