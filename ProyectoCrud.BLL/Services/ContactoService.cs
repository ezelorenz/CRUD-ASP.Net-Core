using ProyectoCrud.DAL.Repositories;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Services
{
    public class ContactoService : IContactoService
    {
        public readonly IGenericRepository<Contacto> _contactoRepo;
        public ContactoService(IGenericRepository<Contacto> contactoRepo)
        {
            _contactoRepo = contactoRepo;
        }
        public async Task<bool> Actualizar(Contacto modelo)
        {
            return await _contactoRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _contactoRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Contacto modelo)
        {
            return await _contactoRepo.Insertar(modelo);
        }

        public async Task<Contacto> Obtener(int id)
        {
            return await _contactoRepo.Obtener(id);
        }

        public async Task<Contacto>ObtenerPorNombre(string nombre)
        {
            IQueryable<Contacto> queryContactoSQL = await _contactoRepo.ObtenerTodos();
            Contacto contacto = queryContactoSQL.Where(c => c.Nombre == nombre).FirstOrDefault();
            return contacto;
        }

        public async Task<IQueryable<Contacto>> ObtenerTodos()
        {
            return await _contactoRepo.ObtenerTodos();
        }
    }
}
