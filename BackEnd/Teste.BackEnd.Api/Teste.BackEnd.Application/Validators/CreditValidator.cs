using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.BackEnd.Domain.Entitys;
using Teste.BackEnd.Domain.Validators;
using Teste.BackEnd.Domain.ValueObjects;

namespace Teste.BackEnd.Application.Validators
{
    public class CreditValidator : ICreditValidator
    {
        public bool ValidateCredit(Credit credit)
        {
            return ValidateAmount(credit) &&
                   ValidateNumberOfInstallments(credit) &&
                   ValidateBusinessCredit(credit) &&
                   ValidateFirstDueDate(credit);
        }

        private bool ValidateAmount(Credit credit)
        {
            return credit.Amount > 0 && credit.Amount <= 1000000;
        }

        private bool ValidateNumberOfInstallments(Credit credit)
        {
            return credit.NumberOfInstallments >= 5 && credit.NumberOfInstallments <= 72;
        }

        private bool ValidateBusinessCredit(Credit credit)
        {
            return credit.Type != CreditType.Business || credit.Amount >= 15000;
        }

        private bool ValidateFirstDueDate(Credit credit)
        {
            var minDueDate = DateTime.Today.AddDays(15);
            var maxDueDate = DateTime.Today.AddDays(40);
            return credit.FirstDueDate >= minDueDate && credit.FirstDueDate <= maxDueDate;
        }
    }
}
