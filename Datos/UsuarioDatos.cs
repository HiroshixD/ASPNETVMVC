using System;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class UsuarioDatos
    {
        private Contexto db;
        public UsuarioDatos()
        {
            db = new Contexto();
        }
        public List<Usuario> ListarTodos()
        {
                return db.Usuarios.ToList();
        }

        public void Crear(Usuario usuario)
        {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
        }

        public void Actualizar(int id, Usuario usuario)
        {
                Usuario user = db.Usuarios.Find(id);
                if (user == null)
                {
                    return;
                }
                else
                {
                    user.Nombres = usuario.Nombres;
                    user.Apellidos = usuario.Apellidos;
                    user.Fecha_Nacimiento = usuario.Fecha_Nacimiento;
                    user.Username = usuario.Username;
                    db.SaveChanges();
                }

            }
      


        public object BuscarPorId(int? id)
        {
                var usuario = db.Usuarios.Find(id);
                return usuario;
        }


        public void Eliminar(int id)
        {
                var usuario = db.Usuarios.Find(id);
                db.Usuarios.Remove(usuario);
                db.SaveChanges();
        }
    }
}
