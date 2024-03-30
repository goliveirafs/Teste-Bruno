using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.BackEnd.Domain.Entitys;

namespace Teste.BackEnd.Domain.Repositorys
{
    public interface ICreditRepository : IRepository<Credit>
    {
        Credit Add(Credit credit);
    }
}
