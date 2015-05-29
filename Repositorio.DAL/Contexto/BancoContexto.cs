using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Repositorio.Entidades;

namespace Repositorio.DAL.Contexto
{
    public class BancoContexto : DbContext
    {
        public BancoContexto() : base("ConnDB") { }

        public DbSet<Cliente> Cliente { get; set; }
    }
}
