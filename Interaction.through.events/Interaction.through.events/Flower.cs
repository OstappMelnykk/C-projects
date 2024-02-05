using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaction.through.events
{
    public abstract class Flower : ICloneable
    {
        public uint Id { get; set; }
        public string Title { get; set; }
        protected ushort daysTolive;
        public bool IsDead { get; set; }

        public virtual ushort DaysTolive
        {
            get { return daysTolive; }
            protected set { daysTolive = value; }
        }
        public abstract event FlowerHandler? ImOpening;
        public abstract event FlowerHandler? ImClosing;
        public abstract event FlowerHandler? ImDead;

        public Flower(uint Id, string Title, ushort daysTolive)
        {
            this.Id = Id;
            this.Title = Title;
            this.DaysTolive = daysTolive;
        }

        public abstract void flowerBlooms();
        public abstract void flowerCloses();
        public abstract void dayPassed();
        public abstract object Clone();
        public abstract void Subscribe();

        public override string ToString()
        {
            return $"Flower ID: {this.Id}, Flower Name: {this.Title}, Flower DaysTolive: {this.daysTolive}, IsDead: {this.IsDead}";
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj is Flower flower)
            {
                return this.Id == flower.Id &&
                    this.Title == flower.Title &&
                    this.DaysTolive == flower.DaysTolive &&
                    this.IsDead == flower.IsDead;
            }
            else
            {
                return false;
            }
        }
    }


    public class DayFlower : Flower
    {

        public DayFlower(uint Id, string Title, ushort daysTolive, bool subscribe) : base(Id, Title, daysTolive)
        {
            if (subscribe) this.Subscribe();
        }

        public override ushort DaysTolive
        {
            get { return daysTolive; }
            protected set { daysTolive = value; }
        }

        public override event FlowerHandler? ImOpening;
        public override event FlowerHandler? ImClosing;
        public override event FlowerHandler? ImDead;

        public override void flowerBlooms()
        {
            Console.WriteLine($"\t\tFlower: ID: {this.Id} || {this.Title} blooms. 7:00  -- {this.daysTolive}");
            this.ImOpening?.Invoke(this);
        }

        public override void flowerCloses()
        {
            Console.WriteLine($"\t\tFlower: ID: {this.Id} || {this.Title} closes. 19:00  -- {this.daysTolive}");
            this.ImClosing?.Invoke(this);
        }

        public override object Clone() => new DayFlower(this.Id, this.Title, this.daysTolive, false);

        public override void Subscribe()
        {
            Sun.DayNotify += flowerBlooms;
            Sun.NightNotify += flowerCloses;
            Sun.ChangingNotify += dayPassed;
        }

        public override void dayPassed()
        {
            this.daysTolive--;

            if (this.daysTolive == 0)
            {
                this.IsDead = true;
                Sun.DayNotify -= flowerBlooms;
                Sun.NightNotify -= flowerCloses;

                Console.WriteLine($"\t\t\tFlower: ID: {this.Id} || {this.Title} \t___DIED___...");
                this.ImDead?.Invoke(this);
            }
        }
    }


    public class NightFlower : Flower
    {
        public override ushort DaysTolive
        {
            get { return daysTolive; }
            protected set { daysTolive = value; }
        }

        public NightFlower(uint Id, string Title, ushort daysTolive, bool subscribe) : base(Id, Title, daysTolive)
        {
            if (subscribe)
            {
                this.Subscribe();
            }
        }

        public override event FlowerHandler? ImOpening;
        public override event FlowerHandler? ImClosing;
        public override event FlowerHandler? ImDead;

        public override void flowerBlooms()
        {
            Console.WriteLine($"\t\tFlower: ID: {this.Id} || {this.Title} blooms. 19:00  -- {this.daysTolive}");
            this.ImOpening?.Invoke(this);
        }

        public override void flowerCloses()
        {
            Console.WriteLine($"\t\tFlower: ID: {this.Id} || {this.Title} closes. 7:00  -- {this.daysTolive}");
            this.ImClosing?.Invoke(this);
        }

        public override object Clone() => new DayFlower(this.Id, this.Title, this.daysTolive, false);

        public override void Subscribe()
        {
            Sun.DayNotify += flowerCloses;
            Sun.NightNotify += flowerBlooms;
            Sun.ChangingNotify += dayPassed;
        }

        public override void dayPassed()
        {
            this.daysTolive--;

            if (this.daysTolive == 0)
            {
                this.IsDead = true;
                Sun.DayNotify -= flowerCloses;
                Sun.NightNotify -= flowerBlooms;
                Console.WriteLine($"\t\t\tFlower: ID: {this.Id} || {this.Title} \t___DIED___...");
                ImDead?.Invoke(this);
            }
        }
    }
}
