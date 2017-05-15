using _2013215462_ENT;
using _2013215462_ENT.lRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_PER.Repositories
{
    class DepartamentoRepository : Repository<Departamento>, IDepartamentoRepository
    {
        private DiazDbContext _Context;

        public DepartamentoRepository(DiazDbContext _Context)
        {
            // TODO: Complete member initialization
            this._Context = _Context;
        }
        private DepartamentoRepository()
        {

        }
    }
}
