using TestMonopoly;

namespace StorageTests
{
    [Order(1)]
    public class SmokeTests
    {
        [Test]
        public void BoxCreatingSmokeTest()
        {
            int boxID = 1;
            float width = 2;
            float height = 2;
            float depth = 2;
            float weight = 4;
            DateOnly productionDate = DateOnly.FromDateTime(DateTime.Today);
            DateOnly expirationDate = DateOnly.FromDateTime(DateTime.Today.AddDays(10));
            Box testbox = new Box(boxID, width, height, depth, weight, productionDate, expirationDate);
            Assert.That(
                testbox.ID == boxID &&
                testbox.Width == width &&
                testbox.Height == height &&
                testbox.Depth == depth &&
                testbox.Weight == weight &&
                testbox.ProductionDate == productionDate &&
                testbox.ExpirationDate == expirationDate
                );
        }
        [Test]
        public void PalletCreatingSmokeTest()
        {
            int palletID = 1;
            float width = 10;
            float height = 1;
            float depth = 10;
            Pallet testpallet = new Pallet(palletID, width, height, depth, new List<Box>() );
            Assert.That(
                testpallet.ID == palletID &&
                testpallet.Width == width &&
                testpallet.Height == height &&
                testpallet.Depth == depth
                );
        }
    }
}
