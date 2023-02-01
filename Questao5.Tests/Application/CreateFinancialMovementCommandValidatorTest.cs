using FluentValidation.TestHelper;
using NUnit.Framework;
using Questao5.Application.Commands.Requests;

namespace Questao5.Tests.Application
{
    [TestFixture]
    [Category("Questao5.Application.Tests")]
    public class CreateFinancialMovementCommandValidatorTest
    {
        private CreateFinancialMovementCommand _createFinancialMovementCommand;
        private CreateFinancialMovementCommandValidator _validator;

        [SetUp]
        public void Setup()
        {
            _createFinancialMovementCommand = new CreateFinancialMovementCommand
            {
            };

            _validator = new CreateFinancialMovementCommandValidator();
        }

        [Test]
        public void RequestId_ShouldNotHaveError_WhenInformedValueIsNotNullOrEmptyAndNotBiggerThanAllowed()
        {
            //Arrange
            _createFinancialMovementCommand.RequestId = "a-b-c-d-e";

            //Action
            var result = _validator.TestValidate(_createFinancialMovementCommand);

            //Assert
            result.ShouldNotHaveValidationErrorFor(e => e.RequestId);
        }

        [Test]
        public void RequestId_ShouldHaveError_WhenInformedValueIsNull()
        {
            //Action
            var result = _validator.TestValidate(_createFinancialMovementCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.RequestId).WithErrorMessage("Identificador da requisição deve ser informado.");
        }

        [Test]
        public void RequestId_ShouldHaveError_WhenInformedValueIsEmpty()
        {
            //Arrange
            _createFinancialMovementCommand.BankAccountId = "";

            //Action
            var result = _validator.TestValidate(_createFinancialMovementCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.RequestId).WithErrorMessage("Identificador da requisição deve ser informado.");
        }

        [Test]
        public void RequestId_ShouldHaveError_WhenInformedValueIsBiggerThanAllowed()
        {
            //Arrange
            _createFinancialMovementCommand.BankAccountId = new string('f', 38);

            //Action
            var result = _validator.TestValidate(_createFinancialMovementCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.RequestId).WithErrorMessage("Identificador da requisição não deve ultrapassar 37 caracteres.");
        }

        [Test]
        public void BankAccountId_ShouldNotHaveError_WhenInformedValueIsNotNullOrEmptyAndNotBiggerThanAllowed()
        {
            //Arrange
            _createFinancialMovementCommand.BankAccountId = "a-b-c-d-e";

            //Action
            var result = _validator.TestValidate(_createFinancialMovementCommand);

            //Assert
            result.ShouldNotHaveValidationErrorFor(e => e.BankAccountId);
        }

        [Test]
        public void BankAccountId_ShouldHaveError_WhenInformedValueIsNull()
        {
            //Action
            var result = _validator.TestValidate(_createFinancialMovementCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.BankAccountId).WithErrorMessage("Identificador da conta corrente deve ser informado.");
        }

        [Test]
        public void BankAccountId_ShouldHaveError_WhenInformedValueIsEmpty()
        {
            //Arrange
            _createFinancialMovementCommand.BankAccountId = "";

            //Action
            var result = _validator.TestValidate(_createFinancialMovementCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.BankAccountId).WithErrorMessage("Identificador da conta corrente deve ser informado.");
        }

        [Test]
        public void BankAccountId_ShouldHaveError_WhenInformedValueIsBiggerThanAllowed()
        {
            //Arrange
            _createFinancialMovementCommand.BankAccountId = new string('f', 38);

            //Action
            var result = _validator.TestValidate(_createFinancialMovementCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.BankAccountId).WithErrorMessage("Identificador da conta corrente não deve ultrapassar 37 caracteres.");
        }

        [Test]
        public void MovementType_ShouldNotHaveError_WhenCValueIsInformed()
        {
            //Arrange
            _createFinancialMovementCommand.MovementType = "C";

            //Action
            var result = _validator.TestValidate(_createFinancialMovementCommand);

            //Assert
            result.ShouldNotHaveValidationErrorFor(e => e.MovementType);
        }

        [Test]
        public void MovementType_ShouldNotHaveError_WhenDValueIsInformed()
        {
            //Arrange
            _createFinancialMovementCommand.MovementType = "D";

            //Action
            var result = _validator.TestValidate(_createFinancialMovementCommand);

            //Assert
            result.ShouldNotHaveValidationErrorFor(e => e.MovementType);
        }

        [Test]
        public void MovementType_ShouldHaveError_WhenInformedValueIsDifferentThanAllowed()
        {
            //Arrange
            _createFinancialMovementCommand.MovementType = "A";

            //Action
            var result = _validator.TestValidate(_createFinancialMovementCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.MovementType).WithErrorMessage("Tipo da movimentação deve ser 'C' para crédito e 'D' para débito.");
        }

        [Test]
        public void MovementType_ShouldNotHaveError_WhenInformedValueIsPositive()
        {
            //Arrange
            _createFinancialMovementCommand.Value = 1;

            //Action
            var result = _validator.TestValidate(_createFinancialMovementCommand);

            //Assert
            result.ShouldNotHaveValidationErrorFor(e => e.Value);
        }

        [Test]
        public void Value_ShouldHaveError_WhenInformedValueIsNegative()
        {
            //Arrange
            _createFinancialMovementCommand.Value = -1;

            //Action
            var result = _validator.TestValidate(_createFinancialMovementCommand);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.Value).WithErrorMessage("Valor informado não deve ser negativo.");
        }
    }
}
