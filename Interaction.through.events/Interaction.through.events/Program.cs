namespace Interaction.through.events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Flower> list = new List<Flower> {
                new DayFlower(1, "Day flower1", 2, true),
                new NightFlower(2, "Night flower1", 3, true),
                new DayFlower(3, "Day flower2", 4, true),
                new NightFlower(4, "Night flower2", 5, true),
                new DayFlower(5, "Day flower3", 6, true),
                new NightFlower(6, "Night flower3", 7, true),
            };

            Bee bee = new Bee(list);
            Girl girl = new Girl("Alo", list);

            Sun.__START__();
        }
    }
}
