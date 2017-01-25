using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio.Repositorios
{
    public class UsuarioRepositorio
    {
        private UsuarioDatos usuario = new UsuarioDatos();


        public List<Usuario> ListarUsuarios()
        {
            return usuario.ListarTodos();
        }

        public void Crear(Usuario model)
        {
            usuario.Crear(model);
        }

        public void Actualizar(int id, Usuario model)
        {
            usuario.Actualizar(id, model);
        }

        public object BuscarPorId(int? id)
        {
           return usuario.BuscarPorId(id);
        }

        public void Eliminar(int id) {
            usuario.Eliminar(id);
        }
    }
}
