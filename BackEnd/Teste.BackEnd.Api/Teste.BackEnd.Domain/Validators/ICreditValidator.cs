using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.BackEnd.Domain.Entitys;

namespace Teste.BackEnd.Domain.Validators
{
    public interface ICreditValidator
    {
        bool ValidateCredit(Credit credit);
    }
}
