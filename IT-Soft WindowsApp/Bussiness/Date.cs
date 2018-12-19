using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Soft_WindowsApp.Bussiness
{
    public class Date
    {
        private int day;
        private int month;
        private int year;

        public int Day
        {
            get
            {
                return day;
            }

            set
            {
                day = value;
            }
        }

        public int Month
        {
            get
            {
                return month;
            }

            set
            {
                month = value;
            }
        }

        public int Year
        {
            get
            {
                return year;
            }

            set
            {
                year = value;
            }
        }

        public Date()
        {
            this.day = 00;
            this.month = 00;
            this.year = 00;
        }

        public Date(int day, int year, int month)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public override String ToString()
        {
            String state;
            state = this.month + "/" + this.day + "/" + this.year;
            return state;
        }

    }
}
