using TestMonopoly;

namespace StorageTests
{
    [Order(2)]
    public class BoxTests
    {
        [TestCase(1, 1, 1, 1, 1)]
        public void UsingCostructorWithDataOnlyProductionDate(int testID, float width, float height, float depth, float weight)
        {
            DateOnly productionDate = DateOnly.FromDateTime(DateTime.Today);
            Box testbox = new Box(testID, width, height, depth, weight, prodDate: productionDate);
            Assert.That(testbox.ProductionDate == productionDate);
        }
        [TestCase(1, 1, 1, 1, 1)]
        public void UsingCostructorWithDataOnlyExpirationDate(int testID, float width, float height, float depth, float weight)
        {
            DateOnly expirationDate = DateOnly.FromDateTime(DateTime.Today);
            Box testbox = new Box(testID, width, height, depth, weight, expDate: expirationDate);
            Assert.That(testbox.ExpirationDate == expirationDate);
        }
        [TestCase(1,1,1,1,1)]
        public void VolumeOnCreatingCalculatingTest(int testID,float width, float height, float depth, float weight)
        {
            Box testbox = new Box(testID, width, height, depth, weight, DateOnly.FromDateTime(DateTime.Today));
            Assert.That(testbox.Volume == width * height * depth);
        }
        [TestCase(1, 1, 1, 1, 1)]
        public void ExpirationDataOnCreatingOnlyWithProductionDateArgumentCalculatingTest(int testID, float width, float height, float depth, float weight)
        {
            DateOnly productionDate = DateOnly.FromDateTime(DateTime.Today);
            Box testbox = new Box(testID, width, height, depth, weight, productionDate);
            Assert.That(testbox.ExpirationDate == productionDate.AddDays(100));
        }
    }
}