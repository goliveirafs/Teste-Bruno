using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.BackEnd.Domain.Dtos;
using Teste.BackEnd.Domain.Entitys;
using Teste.BackEnd.Domain.Repositorys;
using Teste.BackEnd.Domain.Services;
using Teste.BackEnd.Domain.Validators;
using Teste.BackEnd.Domain.ValueObjects;

namespace Teste.BackEnd.Application.Services
{
    public class CreditService : ICreditService
    {
        private readonly IRepository<Credit> _creditRepository;
        private readonly ICreditValidator _creditValidator;

        public CreditService(IRepository<Credit> creditRepository, ICreditValidator creditValidator)
        {
            _creditRepository = creditRepository;
            _creditValidator = creditValidator;
        }

        public CreditResult ProcessCredit(Credit credit)
        {
            // Realiza as validações das entradas
            if (!_creditValidator.ValidateCredit(credit))
                return new CreditResult { Status = "Recusado", TotalAmountWithInterest = 0, InterestAmount = 0 };

            // Calcula a taxa de juros com base no tipo de crédito
            decimal interestRate = GetInterestRate(credit.Type);

            // Calcula o valor total com juros e o valor dos juros
            decimal totalAmountWithInterest = credit.Amount * (1 + interestRate);
            decimal interestAmount = totalAmountWithInterest - credit.Amount;

            // Salva o crédito no banco de dados
            _creditRepository.Add(credit);

            return new CreditResult
            {
                Status = "Aprovado",
                TotalAmountWithInterest = totalAmountWithInterest,
                InterestAmount = interestAmount
            };
        }

        private decimal GetInterestRate(CreditType type)
        {
            // Implementação fictícia para obter a taxa de juros com base no tipo de crédito
            switch (type)
            {
                case CreditType.Direct:
                    return 0.02m;
                case CreditType.Payroll:
                    return 0.01m;
                case CreditType.Business:
                    return 0.05m;
                case CreditType.Personal:
                    return 0.03m;
                case CreditType.RealEstate:
                    return 0.09m;
                default:
                    throw new ArgumentException("Tipo de crédito inválido.");
            }
        }
    }

}
