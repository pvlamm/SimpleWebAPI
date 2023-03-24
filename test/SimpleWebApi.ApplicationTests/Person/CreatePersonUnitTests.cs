namespace SimpleWebApi.ApplicationTests.Person
{
    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using SimpleWebAPI.Application.Common.Interfaces;
    using SimpleWebAPI.Application.Common.Messages;
    using SimpleWebAPI.Application.Person.Commands;

    [TestClass]
    public class CreatePersonUnitTests
    {
        private Mock<IPersonService> _personService;

        public CreatePersonUnitTests()
        {
            _personService = new Mock<IPersonService>();
        }

        [TestMethod]
        [DataRow("Alpha", "100 Main St.")]
        public void CreatePerson_DoubleEntry(string name, string address)
        {
            // Arrange
            var command = new CreatePersonCommand { Name = name, Address = address };

            // PersonExists being true would make this a double entry attempt
            _personService.Setup(x => x.PersonExists(It.IsAny<string>())).Returns(true);

            var validator = new CreatePersonValidation(_personService.Object);

            // Act and Assert
            var result = validator.Validate(command);
            result.Errors.Should().HaveCount(1);
            result.Errors.Should().OnlyContain(x => x.ErrorMessage == ValidationErrorMessages.ERROR_NAME_EXISTS);
        }

        [TestMethod]
        [DataRow("", "100 Main St.")]
        public void CreatePerson_Name_Cannot_Be_Empty(string name, string address)
        {
            // Arrange
            var command = new CreatePersonCommand { Name = name, Address = address };

            // PersonExists being true would make this a double entry attempt
            _personService.Setup(x => x.PersonExists(It.IsAny<string>())).Returns(false);

            var validator = new CreatePersonValidation(_personService.Object);

            // Act and Assert
            var result = validator.Validate(command);
            result.Errors.Should().HaveCount(1);
            result.Errors.Should().OnlyContain(x => x.ErrorMessage == ValidationErrorMessages.ERROR_NAME_CANNOT_BE_EMPTY);
        }

        [TestMethod]
        [DataRow("1234567890123456789012345678901234567890123456789012345678901234567890123456", "100 Main St.")]
        public void CreatePerson_Name_Too_Long(string name, string address)
        {
            // Arrange
            var command = new CreatePersonCommand { Name = name, Address = address };

            // PersonExists being true would make this a double entry attempt
            _personService.Setup(x => x.PersonExists(It.IsAny<string>())).Returns(false);

            var validator = new CreatePersonValidation(_personService.Object);

            // Act and Assert
            var result = validator.Validate(command);
            result.Errors.Should().HaveCount(1);
            result.Errors.Should().OnlyContain(x => x.ErrorMessage == ValidationErrorMessages.ERROR_NAME_TOO_LONG);
        }

        [TestMethod]
        [DataRow("Steve", "")]
        public void CreatePerson_Address_Cannot_Be_Empty(string name, string address)
        {
            // Arrange
            var command = new CreatePersonCommand { Name = name, Address = address };

            // PersonExists being true would make this a double entry attempt
            _personService.Setup(x => x.PersonExists(It.IsAny<string>())).Returns(false);

            var validator = new CreatePersonValidation(_personService.Object);

            // Act and Assert
            var result = validator.Validate(command);
            result.Errors.Should().HaveCount(1);
            result.Errors.Should().OnlyContain(x => x.ErrorMessage == ValidationErrorMessages.ERROR_ADDRESS_CANNOT_BE_EMPTY);
        }

        [TestMethod]
        [DataRow("Steve", "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901")]
        public void CreatePerson_Address_Too_Long(string name, string address)
        {
            // Arrange
            var command = new CreatePersonCommand { Name = name, Address = address };

            // PersonExists being true would make this a double entry attempt
            _personService.Setup(x => x.PersonExists(It.IsAny<string>())).Returns(false);

            var validator = new CreatePersonValidation(_personService.Object);

            // Act and Assert
            var result = validator.Validate(command);
            result.Errors.Should().HaveCount(1);
            result.Errors.Should().OnlyContain(x => x.ErrorMessage == ValidationErrorMessages.ERROR_ADDRESS_TOO_LONG);
        }
    }
}
