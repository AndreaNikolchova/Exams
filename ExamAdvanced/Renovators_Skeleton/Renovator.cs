using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Renovator
    {
        //•	Name: string
        //•	Type: string
        //•	Rate: double
        //•	Days: int
        //•	Hired: boolean - false by default
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private double rate;

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }
        private int days;

        public int Days
        {
            get { return days; }
            set { days = value; }
        }
        public bool Hired = false;
        //The class constructor should receive(name, type, rate, days). 
        public Renovator(string name,string type, double rate, int days)
        {
            this.Name = name;
            this.Type = type;
            this.Rate = rate;
            this.Days = days;
        }

        public override string ToString()
        {
            return $"-Renovator: {this.Name}{Environment.NewLine}" +
                $"--Specialty: {this.Type}{Environment.NewLine}" +
                $"--Rate per day: {this.Rate} BGN";
        }

    }
}
