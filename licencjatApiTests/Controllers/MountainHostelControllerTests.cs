using licencjatApi.Controllers;
using licencjatApi.Models;
using licencjatApi.Models.DTOs;
using licencjatApi.Services;
using licencjatApi.Services.Validators;
using licencjatApi.Validators;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace licencjataApiTests.Controllers
{
    [TestFixture]
    internal class MountainHostelControllerTests
    {
        private MountainHostelController _sut;
        private Mock<IMountainHostelService> _mountainHostelService;

        [SetUp]
        public void Setup()
        {
            _mountainHostelService = new Mock<IMountainHostelService>();
            _sut = new MountainHostelController(_mountainHostelService.Object);
        }

        [Test]
        public void GetAllTest()
        {
            //Arrange
            var hostels = new List<MountainHostel>();
            _mountainHostelService.Setup(x => x.GetAll()).Returns(hostels);

            //Act
            var result = _sut.GetAll();

            //Assert
            Assert.That(result, Is.EqualTo(hostels));
            //_mountainHostelService.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void GetTest()
        {
            //Arrange
            var hostel = new MountainHostel();
            var id = 1;
            _mountainHostelService.Setup(x => x.Get(id)).Returns(hostel);

            //Act
            var result = _sut.Get(id);

            //Assert
            Assert.That(result, Is.EqualTo(hostel));
        }

        [Test]
        public void Add_If_Valid_Data_Returns_Ok()
        {
            //Arrange
            var name = "name";
            var hostel = new MountainHostelDto()
            {
                Name = name
            };
            _mountainHostelService.Setup(x => x.Add(It.Is<MountainHostel>(h => h.Name == name)));

            //Act
            var result = _sut.Add(hostel);

            //Assert
            Assert.That(result, Is.TypeOf(typeof(OkResult)));
        }

        [Test]
        public void Add_Catch_NotValidObjectDataException_Returns_BadRequest()
        {
            //Arrange
            var message = "message";
            var exception = new NotValidObjectDataException(message);
            var hostel = new MountainHostelDto()
            {
                Name = "name"
            };
            _mountainHostelService.Setup(x => x.Add(It.IsAny<MountainHostel>())).Throws(exception);

            //Act
            var result = _sut.Add(hostel);

            //Assert
            Assert.That(result, Is.TypeOf(typeof(BadRequestObjectResult)));

            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult, Is.Not.Null);
            Assert.That(badRequestResult.Value, Is.EqualTo(message));
        }

        [Test]
        public void Update_If_Valid_Data_Returns_Ok()
        {
            //Arrange
            var name = "name";
            var hostel = new MountainHostelDto()
            {
                Name = name
            };
            _mountainHostelService.Setup(x => x.Update(It.Is<MountainHostel>(h => h.Name == name)));

            //Act
            var result = _sut.Update(hostel);

            //Assert
            Assert.That(result, Is.TypeOf(typeof(OkResult)));
        }

        [Test]
        public void Update_Catch_NotValidObjectDataException_Returns_BadRequest()
        {
            //Arrange
            var message = "message";
            var exception = new NotValidObjectDataException(message);
            var hostel = new MountainHostelDto()
            {
                Name = "name"
            };
            _mountainHostelService.Setup(x => x.Update(It.IsAny<MountainHostel>())).Throws(exception);

            //Act
            var result = _sut.Update(hostel);

            //Assert
            Assert.That(result, Is.TypeOf(typeof(BadRequestObjectResult)));

            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult, Is.Not.Null);
            Assert.That(badRequestResult.Value, Is.EqualTo(message));
        }

        [Test]
        public void DeleteTest()
        {
            // Arrange
            var id = 1;

            // Act
            _sut.Delete(id);

            // Assert
            _mountainHostelService.Verify(x => x.Delete(id), Times.Once);
        }
    }
}
