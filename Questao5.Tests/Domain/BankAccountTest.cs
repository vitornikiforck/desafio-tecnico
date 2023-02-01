using FluentAssertions;
using Moq;
using NUnit.Framework;
using Questao5.Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Questao5.Tests.Domain
{
    [TestFixture]
    [Category("Questao5.Domain.Tests")]
    public class BankAccountTest
    {
        private Mock<BankAccount> _bankAccount;
        private Mock<FinancialMovement> _financialMovement;

        [SetUp]
        public void Setup()
        {
            _bankAccount = new Mock<BankAccount>();
            _financialMovement = new Mock<FinancialMovement>();
        }

        [Test]
        public void GetBalance_ShouldReturnZeroForCMovementType()
        {
            //Arrange
            string movementType = "C";
            decimal expectedValue = 0;

            _financialMovement.Setup(e => e.MovementType).Returns(movementType);
            _bankAccount.Setup(e => e.FinancialMovements).Returns(() => new List<FinancialMovement> { _financialMovement.Object });

            //Action
            var balance = _bankAccount.Object.GetBalance();

            //Assert
            balance.Should().Be(expectedValue);
        }

        [Test]
        public void GetBalance_ShouldReturnExpectedValueForCMovementType()
        {
            //Arrange
            string movementType = "C";
            decimal movementValue = 10;
            decimal expectedValue = 10;

            _financialMovement.Setup(e => e.MovementType).Returns(movementType);
            _financialMovement.Setup(e => e.Value).Returns(movementValue);
            _bankAccount.Setup(e => e.FinancialMovements).Returns(() => new List<FinancialMovement> { _financialMovement.Object });

            //Action
            var balance = _bankAccount.Object.GetBalance();

            //Assert
            balance.Should().Be(expectedValue);
        }

        [Test]
        public void GetBalance_ShouldReturnZeroForDMovementType()
        {
            //Arrange
            string movementType = "D";
            decimal expectedValue = 0;

            _financialMovement.Setup(e => e.MovementType).Returns(movementType);
            _bankAccount.Setup(e => e.FinancialMovements).Returns(() => new List<FinancialMovement> { _financialMovement.Object });

            //Action
            var balance = _bankAccount.Object.GetBalance();

            //Assert
            balance.Should().Be(expectedValue);
        }

        [Test]
        public void GetBalance_ShouldReturnExpectedValueForDMovementType()
        {
            //Arrange
            string movementType = "D";
            decimal movementValue = 10;
            decimal expectedValue = -10;

            _financialMovement.Setup(e => e.MovementType).Returns(movementType);
            _financialMovement.Setup(e => e.Value).Returns(movementValue);
            _bankAccount.Setup(e => e.FinancialMovements).Returns(() => new List<FinancialMovement> { _financialMovement.Object });

            //Action
            var balance = _bankAccount.Object.GetBalance();

            //Assert
            balance.Should().Be(expectedValue);
        }

        [Test]
        public void GetBalance_ShouldReturnZeroForBankAccountWithoutFinancialMovements()
        {
            //Arrange
            decimal expectedValue = 0;

            //Action
            var balance = _bankAccount.Object.GetBalance();

            //Assert
            balance.Should().Be(expectedValue);
        }
    }
}
