using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.BackEnd.Domain.ValueObjects;

namespace Teste.BackEnd.Domain.Entitys
{
    public class Credit
    {
        public decimal Amount { get; set; }
        public CreditType Type { get; set; }
        public int NumberOfInstallments { get; set; }
        public DateTime FirstDueDate { get; set; }
    }
}
