using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Contexto: DbContext
    {
        public Contexto()
            : base("ProyectoDePrueba")
        {
                
        }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
