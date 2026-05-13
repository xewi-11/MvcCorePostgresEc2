using Microsoft.EntityFrameworkCore;
using MvcCorePostgresEc2.Data;
using MvcCorePostgresEc2.Models;

namespace MvcCorePostgresEc2.Repositories
{
    public class RepositoryDepartamento
    {
        private HospitalContext context;

        public RepositoryDepartamento(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await context.Departamentos.ToListAsync();
        }
        public async Task<Departamento> FindDepartamentoAsync(int id)
        {
            return await context.Departamentos.FirstOrDefaultAsync(d => d.DeptNo == id);
        }

        public async Task CreateDepartamentoAsync(int id, string nombre, string localidad)
        {
            Departamento dept = new Departamento
            {
                DeptNo = id,
                Nombre = nombre,
                Localidad = localidad
            };
            await context.Departamentos.AddAsync(dept);
            await context.SaveChangesAsync();
        }
    }
}
