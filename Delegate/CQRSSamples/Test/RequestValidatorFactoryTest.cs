using NUnit.Framework;
using WebApplication.Application.Commands;
using WebApplication.Application.Validator;

namespace Test
{
    [TestFixture]
    public class RequestValidatorFactoryTest
    {
        [Test]
        public void GetValidatorShouldHaveInstance()
        {
            var createStudentCmd = new CreateStudentCommand();
            var validatorFactory = new RequestValidatorFactory(typeof(RequestValidatorFactory).Assembly);
            var validator = validatorFactory.GetRequestValidator<CreateStudentCommand>();
            Assert.True(validator != null);
        }
    }
}