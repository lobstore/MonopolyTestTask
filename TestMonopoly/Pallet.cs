namespace TestMonopoly
{
    public class Pallet : StorageItem
    {
        public DateOnly ExpirationDate { get; set; }
        public List<Box> Boxes { get; set; } = new();

        public Pallet(int iD, float width, float height, float depth, List<Box> boxes)
        {
            ID = iD;
            Width = width;
            Height = height;
            Depth = depth;
            foreach (var box in boxes)
            {
                try
                {
                    if (box.Width > Width || box.Depth > Depth)
                    {
                        throw new Exception("Размер коробки не может превышать размер паллеты, коробка будет отброшена");
                    }
                    Boxes.Add(box);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

            }


            CalculateWeight();
            CalculateVolume();
            CalculateMinExpirationDate();
        }
        /// <summary>
        /// Calculates the weight of a pallet based on the weight of all the boxes on it
        /// </summary>
        protected void CalculateWeight()
        {
                Weight = Boxes.Count > 0 ? 30f + Boxes.Sum(x => x.Weight) : 30f;
        }
        /// <summary>
        /// Calculates the volume of a pallet based on the volumes of all the boxes on it
        /// </summary>
        override protected void CalculateVolume() { Volume = Boxes.Count>0 ? Boxes.Sum(x => x.Volume) + Width * Height * Depth : Width * Height * Depth; }
        /// <summary>
        /// Calculates the minimum expiration date from all the boxes that are on the pallet
        /// </summary>
        protected void CalculateMinExpirationDate() { ExpirationDate = Boxes.Count > 0 ? Boxes.Min(x => x.ExpirationDate): default; }
        /// <summary>
        /// Adds new box on the pallet
        /// </summary>
        /// <param name="nexBox">Box instance</param>
        public void Add(Box nexBox)
        {
            try
            {
                if (nexBox.Width > Width || nexBox.Depth > Depth)
                {
                    throw new Exception("Размер коробки не может превышать размер паллеты, коробка будет отброшена");
                }
                Boxes.Add(nexBox);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Removes the box with the specified ID 
        /// </summary>
        /// <param name="boxID">specified ID</param>
        public void Remove(int boxID)
        {
            if (Boxes.Count > 0)
            {
                Boxes.Remove(Boxes.FirstOrDefault(b => b.ID == boxID));
            }
        }
    }
}
