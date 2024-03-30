using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.BackEnd.Domain.Dtos
{
    public class CreditResult
    {
        public string Status { get; set; }
        public decimal TotalAmountWithInterest { get; set; }
        public decimal InterestAmount { get; set; }
    }
}
