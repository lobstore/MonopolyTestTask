namespace TestMonopoly
{
    public class Box : StorageItem
    {
        public DateOnly ExpirationDate { get; set; }
        public DateOnly ProductionDate { get; set; }


        public Box(int iD, float width, float height, float depth, float weight,
            DateOnly prodDate = default, DateOnly expDate = default)
        {
            if (expDate == default && prodDate == default)
            {
                throw new Exception("На коробке должна быть указана хотя бы одна из дат");
            }
            ProductionDate = prodDate;
            ExpirationDate = expDate;
            ID = iD;
            Width = width;
            Height = height;
            Depth = depth;
            Weight = weight;
            RecalculateExpirationDate();
            CalculateVolume();
        }
        /// <summary>
        /// Recalculates the expiration date it was not specified based on the date of creation of the product
        /// </summary>
        private void RecalculateExpirationDate()
        {
           ExpirationDate = ExpirationDate != default ? ExpirationDate : ProductionDate.AddDays(100);
        }

        /// <summary>
        /// Calculates the volume of the box
        /// </summary>
        protected override void CalculateVolume()
        {
            Volume = Width * Height * Depth;
        }
    }
}
