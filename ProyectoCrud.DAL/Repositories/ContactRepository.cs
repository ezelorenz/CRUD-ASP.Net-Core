using ProyectoCrud.DAL.DataContext;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Repositories
{
    public class ContactRepository : IGenericRepository<Contacto>
    {
        private readonly DbCRUDcapasContext dbcontext;
        public ContactRepository(DbCRUDcapasContext context)
        {
            dbcontext = context;
        }
        public async Task<bool> Actualizar(Contacto modelo)
        {
            dbcontext.Contactos.Update(modelo);
            await dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Contacto modelo = dbcontext.Contactos.First(c => c.IdContacto == id);
            dbcontext.Contactos.Remove(modelo);
            await dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Contacto modelo)
        {
            dbcontext.Contactos.Add(modelo);
            await dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<Contacto> Obtener(int id)
        {
            return await dbcontext.Contactos.FindAsync(id);
        }

        public async Task<IQueryable<Contacto>> ObtenerTodos()
        {
            IQueryable<Contacto> queryContactoSQL = dbcontext.Contactos;
            return queryContactoSQL;
        }
    }
}
