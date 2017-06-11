using _2013215462_ENT;
using _2013215462_ENT.lRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013215462_PER.Repositories
{
    public class ContratoRepository : Repository<Contrato>, IContratoRepository
    {
        
        public ContratoRepository(DiazDbContext _Context)
            : base(_Context)
        {
       
        }
        private ContratoRepository()
        {

        }
    }
}
