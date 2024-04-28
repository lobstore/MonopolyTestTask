using TestMonopoly;
namespace StorageTests
{
    [Order(3)]
    public class PalletTests
    {
        [Test]
        public void CalculateWeightTest()
        {
            #region PalletArguments
            int palletID = 1;
            float palletWidth = 10;
            float palletHeight = 1;
            float palletDepth = 10;
            #endregion
            #region BoxArguments
            int boxBoxID = 1;
            float boxWidth = 2;
            float boxHeight = 2;
            float boxDepth = 2;
            float boxWeight = 4;
            DateOnly boxProductionDate = DateOnly.FromDateTime(DateTime.Today);
            DateOnly boxExpirationDate = DateOnly.FromDateTime(DateTime.Today.AddDays(10));
            #endregion
            Box testbox1 = new Box(boxBoxID, boxWidth, boxHeight, boxDepth, boxWeight, boxProductionDate, boxExpirationDate);
            Box testbox2 = new Box(boxBoxID, boxWidth, boxHeight, boxDepth, boxWeight, boxProductionDate, boxExpirationDate);
            Box testbox3 = new Box(boxBoxID, boxWidth, boxHeight, boxDepth, boxWeight, boxProductionDate, boxExpirationDate);
            Pallet testpallet = new Pallet(palletID, palletWidth, palletHeight, palletDepth, new List<Box>() { testbox1,testbox2,testbox3 });
            Assert.That(
                testpallet.Weight == boxWeight * 3 + 30
            );
        }
        [Test]
        public void CalculateVolumeTest()
        {
            #region PalletArguments
            int palletID = 1;
            float palletWidth = 10;
            float palletHeight = 1;
            float palletDepth = 10;
            #endregion
            #region BoxArguments
            int boxBoxID = 1;
            float boxWidth = 2;
            float boxHeight = 2;
            float boxDepth = 2;
            float boxWeight = 4;
            DateOnly boxProductionDate = DateOnly.FromDateTime(DateTime.Today);
            DateOnly boxExpirationDate = DateOnly.FromDateTime(DateTime.Today.AddDays(10));
            #endregion
            Box testbox1 = new Box(boxBoxID, boxWidth, boxHeight, boxDepth, boxWeight, boxProductionDate, boxExpirationDate);
            Box testbox2 = new Box(boxBoxID, boxWidth, boxHeight, boxDepth, boxWeight, boxProductionDate, boxExpirationDate);
            Box testbox3 = new Box(boxBoxID, boxWidth, boxHeight, boxDepth, boxWeight, boxProductionDate, boxExpirationDate);
            Pallet testpallet = new Pallet(palletID, palletWidth, palletHeight, palletDepth, new List<Box>() { testbox1, testbox2, testbox3 });
            Assert.That(
                testpallet.Volume == (boxWidth * boxHeight * boxDepth * 3) + (palletWidth * palletDepth * palletHeight)
            ); 
        }
        [TestCase]
        public void CalculateMinExpirationDateTest()
        {
            #region PalletArguments
            int palletID = 1;
            float palletWidth = 10;
            float palletHeight = 1;
            float palletDepth = 10;
            #endregion
            #region BoxArguments
            int boxBoxID = 1;
            float boxWidth = 2;
            float boxHeight = 2;
            float boxDepth = 2;
            float boxWeight = 4;
            DateOnly boxProductionDate = DateOnly.FromDateTime(DateTime.Today);
            DateOnly boxExpirationDate1 = DateOnly.FromDateTime(DateTime.Today.AddDays(10));
            DateOnly boxExpirationDate2 = DateOnly.FromDateTime(DateTime.Today.AddDays(11));
            DateOnly boxExpirationDate3 = DateOnly.FromDateTime(DateTime.Today.AddDays(12));
            #endregion
            Box testbox1 = new Box(boxBoxID, boxWidth, boxHeight, boxDepth, boxWeight, boxProductionDate, boxExpirationDate1);
            Box testbox2 = new Box(boxBoxID, boxWidth, boxHeight, boxDepth, boxWeight, boxProductionDate, boxExpirationDate2);
            Box testbox3 = new Box(boxBoxID, boxWidth, boxHeight, boxDepth, boxWeight, boxProductionDate, boxExpirationDate3);
            Pallet testpallet = new Pallet(palletID, palletWidth, palletHeight, palletDepth, new List<Box>() { testbox1, testbox2, testbox3 });
            Assert.That(
                testpallet.ExpirationDate == boxExpirationDate1
            ) ; 
        }
    }
}
