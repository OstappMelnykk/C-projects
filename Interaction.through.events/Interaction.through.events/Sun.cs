using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaction.through.events
{
    public class Sun
    {
        public static DayOfWeek WhatDayToday { get; set; }
        private static Time currentTime;

        public static Time CurrentTime
        {
            get => Sun.currentTime;
            set
            {
                Sun.currentTime = value;

                if (Sun.currentTime == Time.Day)
                    Sunrise();
                else if (Sun.currentTime == Time.Night)
                    Sunset();
            }
        }

        static Sun()
        {
            Sun.currentTime = Time.Night;
            Sun.WhatDayToday = DayOfWeek.Monday;
        }

        public static event SunHandler? DayNotify;
        public static event SunHandler? NightNotify;
        public static event SunHandler? ChangingNotify;
        public static event SunHandler? DayOffNotify;
        public static event SunHandler? WorkdayNotify;


        public static void Sunrise()
        {

            Console.Write("\n\n\n\n\n" + "Sun is rising...." + "   Day: " + Sun.WhatDayToday.ToString());
            DayIsChanged();
            Sun.DayNotify?.Invoke();

            if (!(WhatDayToday == DayOfWeek.Saturday ||
                WhatDayToday == DayOfWeek.Sunday))
            {
                WorkdayNotify?.Invoke();
            }
        }

        public static void Sunset()
        {
            Console.WriteLine("\n\n" + "Sun is setting...." + "   Day: " + Sun.WhatDayToday.ToString() + "\n");

            Sun.NightNotify?.Invoke();

            if (WhatDayToday == DayOfWeek.Saturday ||
                WhatDayToday == DayOfWeek.Sunday)
            {
                DayOffNotify?.Invoke();
            }

            Sun.WhatDayToday = (DayOfWeek)(((int)Sun.WhatDayToday + 1) % 7);
        }

        public static void DayIsChanged()
        {
            Console.WriteLine("\t___DayIsChanged___\n");
            Sun.ChangingNotify?.Invoke();
        }

        public static void __START__()
        {
            for (int i = 0; i < 20; i++)
            {
                if (i % 2 == 0) Sun.CurrentTime = Time.Day;
                else if (i % 2 == 1) Sun.CurrentTime = Time.Night;

                Thread.Sleep(10);
            }
        }

        public override string ToString()
        {
            return $"{Sun.WhatDayToday} {Sun.currentTime}";
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
}
