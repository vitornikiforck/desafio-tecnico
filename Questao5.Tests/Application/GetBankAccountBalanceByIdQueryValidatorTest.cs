
using FluentValidation.TestHelper;
using NUnit.Framework;
using Questao5.Application.Queries.Requests;

namespace Questao5.Tests.Application
{
    [TestFixture]
    [Category("Questao5.Application.Tests")]
    public class GetBankAccountBalanceByIdQueryValidatorTest
    {
        private GetBankAccountBalanceByIdQuery _getBankAccountBalanceByIdQuery;
        private GetBankAccountBalanceByIdQueryValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new GetBankAccountBalanceByIdQueryValidator();
        }

        [Test]
        public void Id_ShouldNotHaveError_WhenInformedValueIsNotNullOrEmptyAndNotBiggerThanAllowed()
        {
            //Arrange
            _getBankAccountBalanceByIdQuery = new GetBankAccountBalanceByIdQuery("a-b-c-d-e")
            {
            };

            //Action
            var result = _validator.TestValidate(_getBankAccountBalanceByIdQuery);

            //Assert
            result.ShouldNotHaveValidationErrorFor(e => e.Id);
        }

        [Test]
        public void Id_ShouldHaveError_WhenInformedValueIsNull()
        {
            //Assert
            _getBankAccountBalanceByIdQuery = new GetBankAccountBalanceByIdQuery(null)
            {
            };

            //Action
            var result = _validator.TestValidate(_getBankAccountBalanceByIdQuery);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.Id).WithErrorMessage("Identificador da conta corrente deve ser informado.");
        }

        [Test]
        public void Id_ShouldHaveError_WhenInformedValueIsEmpty()
        {
            //Arrange
            _getBankAccountBalanceByIdQuery = new GetBankAccountBalanceByIdQuery("")
            {
            };

            //Action
            var result = _validator.TestValidate(_getBankAccountBalanceByIdQuery);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.Id).WithErrorMessage("Identificador da conta corrente deve ser informado.");
        }

        [Test]
        public void Id_ShouldHaveError_WhenInformedValueIsBiggerThanAllowed()
        {
            //Arrange
            _getBankAccountBalanceByIdQuery = new GetBankAccountBalanceByIdQuery(new string('f', 38))
            {
            };

            //Action
            var result = _validator.TestValidate(_getBankAccountBalanceByIdQuery);

            //Assert
            result.ShouldHaveValidationErrorFor(e => e.Id).WithErrorMessage("Identificador da conta corrente não deve ultrapassar 37 caracteres.");
        }
    }
}
