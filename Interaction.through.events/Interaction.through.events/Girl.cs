using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaction.through.events
{
    public class Girl
    {
        public string Name { get; set; }
        public List<Flower> refToList;

        public Girl(string name, List<Flower> list)
        {
            Sun.DayOffNotify += GotToNightFlowers;
            Sun.WorkdayNotify += GotToDayFlowers;

            refToList = list;

            this.Name = name;
        }


        public void GotToNightFlowers()
        {
            var Flowwers = this.refToList.Where(x => !x.IsDead && x is NightFlower);

            if (Flowwers.Count() > 0)
            {
                Console.WriteLine($"\n____{this.Name} Go TO {Flowwers.Count()} alive night flowers");

                foreach (var item in Flowwers)
                    Console.WriteLine($"\t____{this.Name} Go TO Flower: ID: {item.Id} || {item.Title}");
            }

        }
        public void GotToDayFlowers()
        {
            var Flowwers = this.refToList.Where(x => !x.IsDead && x is DayFlower);

            if (Flowwers.Count() > 0)
            {
                Console.WriteLine($"\n____{this.Name} Go TO {Flowwers.Count()} alive day flowers");

                foreach (var item in Flowwers)
                    Console.WriteLine($"\t____{this.Name} Go TO Flower: ID: {item.Id} || {item.Title}");
            }
        }

        public override string ToString()
        {
            return $"My Name s {this.Name}";
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj is Girl girl)
            {
                return this.Name == girl.Name & this.refToList == girl.refToList;
            }
            else { return false; }

        }
    }
}
