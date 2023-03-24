namespace SimpleWebApi.ApplicationTests.Person
{
    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using SimpleWebAPI.Application.Common.Interfaces;
    using SimpleWebAPI.Application.Common.Messages;
    using SimpleWebAPI.Application.Person.Commands;

    [TestClass]
    public class DeletePersonUnitTests
    {
        private Mock<IPersonService> _personService;

        public DeletePersonUnitTests()
        {
            _personService = new Mock<IPersonService>();
        }

        [TestMethod]
        [DataRow("")]
        public void DeletePerson_Name_Is_Empty(string name)
        {
            // Arrange
            var command = new DeletePersonCommand { Name = name };

            // PersonExists being true would make this a double entry attempt
            _personService.Setup(x => x.PersonExists(It.IsAny<string>())).Returns(true);

            var validator = new DeletePersonValidation(_personService.Object);

            // Act and Assert
            var result = validator.Validate(command);
            result.Errors.Should().HaveCount(1);
            result.Errors.Should().OnlyContain(x => x.ErrorMessage == ValidationErrorMessages.ERROR_NAME_CANNOT_BE_EMPTY);
        }

        [TestMethod]
        [DataRow("Jack")]
        public void DeletePerson_Name_Does_Not_Exist(string name)
        {
            // Arrange
            var command = new DeletePersonCommand { Name = name };

            // PersonExists being true would make this a double entry attempt
            _personService.Setup(x => x.PersonExists(It.IsAny<string>())).Returns(false);

            var validator = new DeletePersonValidation(_personService.Object);

            // Act and Assert
            var result = validator.Validate(command);
            result.Errors.Should().HaveCount(1);
            result.Errors.Should().OnlyContain(x => x.ErrorMessage == ValidationErrorMessages.ERROR_NAME_DOES_NOT_EXIST);
        }
    }
}
