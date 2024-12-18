namespace Interaction.through.events;

public class Bee
{
    public Bee(List<Flower> list)
    {
        foreach (Flower f in list)
        {
            if (f is DayFlower)
            {
                f.ImOpening += this.BeeGo;
                f.ImClosing += this.BeegetBack;
                f.ImDead += this.OkWillUnsubscribe;
            }
        }
    }

    public void BeeGo(Flower flower) => Console.WriteLine($"\t\t\tBee go to Flower: ID: {flower.Id} || {flower.Title} !");

    public void BeegetBack(Flower flower) => Console.WriteLine($"\t\t\tBee get back!");

    public void OkWillUnsubscribe(Flower flower)
    {
        flower.ImOpening -= this.BeeGo;
        flower.ImClosing -= this.BeegetBack;
    }

    public override string ToString()
    {
        return $"Im Bee!!!";
    }
    public override int GetHashCode()
    {
        return this.ToString().GetHashCode();
    }
    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }
}

