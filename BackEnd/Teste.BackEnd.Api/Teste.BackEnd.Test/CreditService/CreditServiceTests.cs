using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.BackEnd.Domain.Entitys;
using Teste.BackEnd.Domain.Repositorys;
using Teste.BackEnd.Domain.Validators;
using Teste.BackEnd.Domain.ValueObjects;

namespace Teste.BackEnd.Test.CreditService
{
    [TestFixture]
    public class CreditServiceTests
    {
        [Test]
        public void ProcessCredit_WithValidCredit_ReturnsApprovedStatus()
        {
            // Arrange
            var credit = new Credit
            {
                Amount = 50000,
                NumberOfInstallments = 12,
                Type = CreditType.Personal,
                FirstDueDate = DateTime.Today.AddDays(20)
            };

            var mockRepository = new Mock<IRepository<Credit>>();
            var mockValidator = new Mock<ICreditValidator>();
            mockValidator.Setup(v => v.ValidateCredit(credit)).Returns(true);

            var creditService = new Application.Services.CreditService(mockRepository.Object, mockValidator.Object);

            // Act
            var result = creditService.ProcessCredit(credit);

            // Assert
            Assert.AreEqual("Aprovado", result.Status);
        }

        [Test]
        public void ProcessCredit_WithInvalidCredit_ReturnsRejectedStatus()
        {
            // Arrange
            var credit = new Credit
            {
                Amount = 2000000,
                NumberOfInstallments = 12,
                Type = CreditType.Personal,
                FirstDueDate = DateTime.Today.AddDays(20)
            };

            var mockRepository = new Mock<IRepository<Credit>>();
            var mockValidator = new Mock<ICreditValidator>();
            mockValidator.Setup(v => v.ValidateCredit(credit)).Returns(false);

            var creditService = new Application.Services.CreditService(mockRepository.Object, mockValidator.Object);

            // Act
            var result = creditService.ProcessCredit(credit);

            // Assert
            Assert.AreEqual("Recusado", result.Status);
        }
    }
}
