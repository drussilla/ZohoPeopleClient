using System;

namespace ZohoPeopleClient.Model
{
    public struct Time
    {
        public static Time Zero = new Time(0, 0);

        private readonly int hours;
        private readonly int minutes;

        public Time(int hours, int minutes)
        {
            if (hours < 0)
            {
                throw new ArgumentException("Hourse cannot be more than 59 or less than 0", "minutes");
            }

            if (minutes < 0 || minutes > 59)
            {
                throw new ArgumentException("Minutes cannot be more than 59 or less than 0", "minutes");
            }

            this.hours = hours;
            this.minutes = minutes;
        }

        public int Hours { get { return hours; }}

        public int Minutes { get { return minutes; } }

        public override string ToString()
        {
            return string.Format("{0}:{1}", Hours, Minutes.ToString("D2"));
        }
    }
}