using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.BackEnd.Domain.Dtos;
using Teste.BackEnd.Domain.Entitys;

namespace Teste.BackEnd.Domain.Services
{
    public interface ICreditService
    {
        CreditResult ProcessCredit(Credit credit);
    }
}
