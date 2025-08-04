using licencjatApi.MulticriteriaSelectionMethods;
using licencjatApi.Models;

namespace licencjatApiTests.MulticriteriaSelectionMethods
{
    [TestFixture]
    public class SAWMulticriteriaSelectionMethodServiceTests
    {
        private SAWMulticriteriaSelectionMethod _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new SAWMulticriteriaSelectionMethod();
        }

        [Test]
        public void CalculateRanking_ShouldReturnCorrectResult_ForValidInput()
        {
            // Arrange
            var hostels = new List<MountainHostel>
            {
                new() { Id = 1, Name = "Schronisko A" },
                new() { Id = 2, Name = "Schronisko B" },
                new() { Id = 3, Name = "Schronisko C" }
            };

            var criteria = new List<Criterion>
            {
                new() { Id = 1, Name = "Cena", IsStimulant = false }
            };

            var hostelCriterionValues = new List<HostelCriterionValue>
            {
                new() { MountainHostelId = 1, CriterionId = 1, Value = 100 },
                new() { MountainHostelId = 2, CriterionId = 1, Value = 200 },
                new() { MountainHostelId = 3, CriterionId = 1, Value = 150 }
            };

            var criterionWeights = new List<CriterionWeight>
            {
                new() { CriterionId = 1, Weight = 1 }
            };

            // Act
            var result = _sut.CalculateRanking(hostels, criteria, hostelCriterionValues, criterionWeights);

            // Assert
            var hostelsWithResult = result.HostelsWithResult.ToList();

            Assert.That(hostelsWithResult, Has.Count.EqualTo(3));
            Assert.That(hostelsWithResult[0].Hostel.Name, Is.EqualTo("Schronisko A"));
            Assert.That(hostelsWithResult[0].Result, Is.EqualTo(1m));
            Assert.That(hostelsWithResult[1].Result, Is.EqualTo(0.5m));
            Assert.That(hostelsWithResult[2].Result, Is.EqualTo(0m));
        }

        [Test]
        public void CalculateRanking_ShouldReturnEmptyList_WhenHostelsIsEmpty()
        {
            // Arrange
            var hostels = new List<MountainHostel>();
            var criteria = new List<Criterion>
            {
                new() { Id = 1, Name = "Cena", IsStimulant = false }
            };
            var hostelCriterionValues = new List<HostelCriterionValue>
            {
                new() { MountainHostelId = 1, CriterionId = 1, Value = 100 }
            };
            var criterionWeights = new List<CriterionWeight>
            {
                new() { CriterionId = 1, Weight = 1 }
            };

            // Act
            var result = _sut.CalculateRanking(hostels, criteria, hostelCriterionValues, criterionWeights);

            // Assert
            Assert.That(result.HostelsWithResult, Is.Empty);
        }
    }
}
