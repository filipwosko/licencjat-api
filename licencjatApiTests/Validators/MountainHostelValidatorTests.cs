using licencjatApi.Models;
using licencjatApi.Repository;
using licencjatApi.Services.Validators;
using Moq;

namespace licencjatApi.Validators
{
    [TestFixture]
    public class MountainHostelValidatorTests 
    {
        private MountainHostelValidator _sut;
        private Mock<IMountainHostelRepository> _mountainHostelRepository;

        [SetUp]
        public void Setup()
        {
            _mountainHostelRepository = new Mock<IMountainHostelRepository>();  
            _sut = new MountainHostelValidator(_mountainHostelRepository.Object);
        }

        [TestCase("")]
        [TestCase(null)]
        public void ValidateTest(string? name)
        {
            //Arrange
            var hostel = new MountainHostel()
            {
                Name = name
            };

            //Act & Assert
            Assert.Throws<NotValidObjectDataException>(() => _sut.Validate(hostel, false), "Nazwa schroniska nie może być pusta");       
        }
    }
}
