using System;

namespace YTPPlus
{
    public class TimeStamp
    {
        public int HOURS;
        public int MINUTES;
        public double SECONDS;
        public TimeStamp(object time)
        {
            char[] id = { ':' };
            string[] d = time.ToString().Split(id);
            Console.WriteLine("D: " + time.ToString());
            if (d.Length == 3)
            {
                this.HOURS = Convert.ToInt32(d[0].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                this.MINUTES = Convert.ToInt32(d[1].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                this.SECONDS = Convert.ToDouble(d[2].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (d.Length == 2)
            {
                this.HOURS = 0;
                this.MINUTES = Convert.ToInt32(d[0].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                this.SECONDS = Convert.ToDouble(d[1].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (d.Length == 1)
            {
                this.HOURS = 0;
                this.MINUTES = 0;
                this.SECONDS = Convert.ToDouble(d[0].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                this.HOURS = 0;
                this.MINUTES = 0;
                this.SECONDS = 0;
            }
        }

        public double getLengthSec()
        {
            return this.SECONDS + (this.MINUTES * 60) + (this.HOURS * 60 * 60);
        }

        public double getLengthMilliseconds()
        {
            return (this.SECONDS + (this.MINUTES * 60) + (this.HOURS * 60 * 60)) * 1000;
        }

        public int getHours()
        {
            return this.HOURS;
        }
        public int getMinutes()
        {
            return this.MINUTES;
        }
        public double getSeconds()
        {
            return this.SECONDS;
        }

        /*public void getDeets() {
            Console.WriteLine("HOURS: " + HOURS);
            Console.WriteLine("MIN: " + MINUTES);
            Console.WriteLine("SEC: " + SECONDS);
        }*/

        public string getTimeStamp()
        {
            return this.SECONDS.ToString(); //works better
                                            //this.HOURS + ":" + this.MINUTES + ":" + this.SECONDS;
        }
    }
}
