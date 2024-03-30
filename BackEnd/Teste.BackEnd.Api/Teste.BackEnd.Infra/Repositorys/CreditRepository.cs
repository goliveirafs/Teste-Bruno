using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.BackEnd.Domain.Entitys;
using Teste.BackEnd.Domain.Repositorys;
using Teste.BackEnd.Infra.DbContext;

namespace Teste.BackEnd.Infra.Repositorys
{
    public class CreditRepository : Repository<Credit>, ICreditRepository
    {
        public CreditRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public Credit Add(Credit credit)
        {
            // Implementação fictícia para adicionar crédito a um banco de dados
            return credit;
        }

        
    }
}
