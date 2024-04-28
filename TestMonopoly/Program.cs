namespace TestMonopoly
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            List<Box> todayBoxes = new List<Box>(n);
            List<Box> yesterdayBoxes = new List<Box>(n);
            List<Box> tomorrowBoxes = new List<Box>(n);
            int boxID = 0;
            for (int i =0; i<n; i++)
            {
                todayBoxes.Add( new Box(boxID, new Random().Next(1, 10), new Random().Next(1,10),new Random().Next(1,10),new Random().Next(1,10),DateOnly.FromDateTime(DateTime.Today)));
                boxID++;
                yesterdayBoxes.Add(new Box(boxID, new Random().Next(1, 10), new Random().Next(1, 10), new Random().Next(1, 10), new Random().Next(1, 10), DateOnly.FromDateTime(DateTime.Today.AddDays(-1))));
                boxID++;
                tomorrowBoxes.Add(new Box(boxID, new Random().Next(1, 10), new Random().Next(1, 10), new Random().Next(1, 10), new Random().Next(1, 10), DateOnly.FromDateTime(DateTime.Today.AddDays(1))));
                boxID++;
            }

            List<Pallet> pallets = new List<Pallet>()
            {
                new Pallet(1,10,1,10,todayBoxes),
                new Pallet(2,10,1,10,todayBoxes),
                new Pallet(3,10,1,10,yesterdayBoxes),
                new Pallet(4,10,1,10,tomorrowBoxes),
                new Pallet(5,10,1,10,yesterdayBoxes),
                new Pallet(6,10,1,10,tomorrowBoxes),
                new Pallet(7,10,1,10,yesterdayBoxes),

            };

            var groupedPallets = pallets
                .OrderBy(p => p.ExpirationDate)
                .GroupBy(p => p.ExpirationDate)
                .Select(group => new
                {
                    ExpirationDate = group.Key,
                    Pallets = group.OrderBy(p => p.Weight)
                })
                .ToList();



            foreach (var group in groupedPallets)
            {
                Console.WriteLine($"Срок годности: {group.ExpirationDate}");

                foreach (var pallet in group.Pallets)
                {
                    Console.WriteLine($"   ID паллеты: {pallet.ID}, Вес: {pallet.Weight}");
                }
            }

            var top3Pallets = pallets
            .OrderByDescending(p => p.ExpirationDate)
            .Take(3)
            .OrderBy(p => p.Volume)
            .ToList();

            foreach (var pallet in top3Pallets)
            {
                Console.WriteLine($"ID паллеты: {pallet.ID}, Срок годности: {pallet.ExpirationDate}, Объем: {pallet.Volume}");
            }

        }
    }
}
