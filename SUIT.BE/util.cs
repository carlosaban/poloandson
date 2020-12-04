using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.BE.n
{
    public class util
    {
        public RangeOfDate GetWeekOfMonth(DateTime date)
        {
            RangeOfDate range = new RangeOfDate();

            switch (date.Day)
            {
                case 1:
                    {

                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 1, 3, 4, 5, 6, 7, 1, 2);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 1, 2, 3, 4, 5, 6, 0, 1);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 1, 1, 2, 3, 4, 5, 0, 0);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 1, 0, 1, 2, 3, 4, 0, 0);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 1, 0, 0, 1, 2, 3, 0, 0);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 1, 0, 0, 0, 1, 2, 0, 0);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 1, 0, 0, 0, 0, 1, 0, 0);
                                break;
                        }; break;
                    };
                case 2:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 2, 4, 5, 6, 7, 8, 2, 3);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 1, 3, 4, 5, 6, 7, 1, 2);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 1, 2, 3, 4, 5, 6, 0, 1);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 1, 1, 2, 3, 4, 5, 0, 0);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 1, 0, 1, 2, 3, 4, 0, 0);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 1, 0, 0, 1, 2, 3, 0, 0);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 1, 0, 0, 0, 1, 2, 0, 0);
                                break;
                        }; break;
                    };
                case 3:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 2, 5, 6, 7, 8, 9, 3, 4);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 2, 4, 5, 6, 7, 8, 2, 3);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 1, 3, 4, 5, 6, 7, 1, 2);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 1, 2, 3, 4, 5, 6, 0, 1);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 1, 1, 2, 3, 4, 5, 0, 0);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 1, 0, 1, 2, 3, 4, 0, 0);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 1, 0, 0, 1, 2, 3, 0, 0);
                                break;
                        }; break;
                    };
                case 4:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 2, 6, 7, 8, 9, 10, 4, 5);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 2, 5, 6, 7, 8, 9, 3, 4);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 2, 4, 5, 6, 7, 8, 2, 3);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 1, 3, 4, 5, 6, 7, 1, 2);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 1, 2, 3, 4, 5, 6, 0, 1);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 1, 1, 2, 3, 4, 5, 0, 0);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 1, 0, 1, 2, 3, 4, 0, 0);
                                break;
                        }; break;
                    };
                case 5:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 2, 7, 8, 9, 10, 11, 5, 6);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 2, 6, 7, 8, 9, 10, 4, 5);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 2, 5, 6, 7, 8, 9, 3, 4);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 2, 4, 5, 6, 7, 8, 2, 3);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 1, 3, 4, 5, 6, 7, 1, 2);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 1, 2, 3, 4, 5, 6, 0, 1);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 1, 1, 2, 3, 4, 5, 0, 0);
                                break;
                        }; break;
                    };
                case 6:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 2, 8, 9, 10, 11, 12, 6, 7);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 2, 7, 8, 9, 10, 11, 5, 6);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 2, 6, 7, 8, 9, 10, 4, 5);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 2, 5, 6, 7, 8, 9, 3, 4);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 2, 4, 5, 6, 7, 8, 2, 3);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 1, 3, 4, 5, 6, 7, 1, 2);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 1, 2, 3, 4, 5, 6, 0, 1);
                                break;
                        }; break;
                    };
                case 7:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 2, 9, 10, 11, 12, 13, 7, 8);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 2, 8, 9, 10, 11, 12, 6, 7);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 2, 7, 8, 9, 10, 11, 5, 6);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 2, 6, 7, 8, 9, 10, 4, 5);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 2, 5, 6, 7, 8, 9, 3, 4);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 2, 4, 5, 6, 7, 8, 2, 3);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 1, 3, 4, 5, 6, 7, 1, 2);
                                break;
                        }; break;
                    };
                case 8:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 2, 10, 11, 12, 13, 14, 8, 9);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 2, 9, 10, 11, 12, 13, 7, 8);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 2, 8, 9, 10, 11, 12, 6, 7);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 2, 7, 8, 9, 10, 11, 5, 6);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 2, 6, 7, 8, 9, 10, 4, 5);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 2, 5, 6, 7, 8, 9, 3, 4);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 2, 4, 5, 6, 7, 8, 2, 3);
                                break;
                        }; break;
                    };
                case 9:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 3, 11, 12, 13, 14, 15, 9, 10);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 2, 10, 11, 12, 13, 14, 8, 9);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 2, 9, 10, 11, 12, 13, 7, 8);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 2, 8, 9, 10, 11, 12, 6, 7);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 2, 7, 8, 9, 10, 11, 5, 6);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 2, 6, 7, 8, 9, 10, 4, 5);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 2, 5, 6, 7, 8, 9, 3, 4);
                                break;
                        }; break;
                    };
                case 10:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 3, 12, 13, 14, 15, 16, 10, 11);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 3, 11, 12, 13, 14, 15, 9, 10);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 2, 10, 11, 12, 13, 14, 8, 9);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 2, 9, 10, 11, 12, 13, 7, 8);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 2, 8, 9, 10, 11, 12, 6, 7);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 2, 7, 8, 9, 10, 11, 5, 6);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 2, 6, 7, 8, 9, 10, 4, 5);
                                break;
                        }; break;
                    };
                case 11:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 3, 13, 14, 15, 16, 17, 11, 12);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 3, 12, 13, 14, 15, 16, 10, 11);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 3, 11, 12, 13, 14, 15, 9, 10);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 2, 10, 11, 12, 13, 14, 8, 9);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 2, 9, 10, 11, 12, 13, 7, 8);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 2, 8, 9, 10, 11, 12, 6, 7);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 2, 7, 8, 9, 10, 11, 5, 6);
                                break;
                        }; break;
                    };
                case 12:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 3, 14, 15, 16, 17, 18, 12, 13);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 3, 13, 14, 15, 16, 17, 11, 12);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 3, 12, 13, 14, 15, 16, 10, 11);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 3, 11, 12, 13, 14, 15, 9, 10);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 2, 10, 11, 12, 13, 14, 8, 9);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 2, 9, 10, 11, 12, 13, 7, 8);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 2, 8, 9, 10, 11, 12, 6, 7);
                                break;
                        }; break;
                    };
                case 13:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 3, 15, 16, 17, 18, 19, 13, 14);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 3, 14, 15, 16, 17, 18, 12, 13);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 3, 13, 14, 15, 16, 17, 11, 12);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 3, 12, 13, 14, 15, 16, 10, 11);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 3, 11, 12, 13, 14, 15, 9, 10);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 2, 10, 11, 12, 13, 14, 8, 9);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 2, 9, 10, 11, 12, 13, 7, 8);
                                break;
                        }; break;
                    };
                case 14:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 3, 16, 17, 18, 19, 20, 14, 15);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 3, 15, 16, 17, 18, 19, 13, 14);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 3, 14, 15, 16, 17, 18, 12, 13);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 3, 13, 14, 15, 16, 17, 11, 12);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 3, 12, 13, 14, 15, 16, 10, 11);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 3, 11, 12, 13, 14, 15, 9, 10);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 2, 10, 11, 12, 13, 14, 8, 9);
                                break;
                        }; break;
                    };
                case 15:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 3, 17, 18, 19, 20, 21, 15, 16);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 3, 16, 17, 18, 19, 20, 14, 15);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 3, 15, 16, 17, 18, 19, 13, 14);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 3, 14, 15, 16, 17, 18, 12, 13);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 3, 13, 14, 15, 16, 17, 11, 12);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 3, 12, 13, 14, 15, 16, 10, 11);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 3, 11, 12, 13, 14, 15, 9, 10);
                                break;
                        }; break;
                    };
                case 16:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 4, 18, 19, 20, 21, 22, 16, 17);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 3, 17, 18, 19, 20, 21, 15, 16);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 3, 16, 17, 18, 19, 20, 14, 15);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 3, 15, 16, 17, 18, 19, 13, 14);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 3, 14, 15, 16, 17, 18, 12, 13);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 3, 13, 14, 15, 16, 17, 11, 12);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 3, 12, 13, 14, 15, 16, 10, 11);
                                break;
                        }; break;
                    };
                case 17:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 4, 19, 20, 21, 22, 23, 17, 18);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 4, 18, 19, 20, 21, 22, 16, 17);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 3, 17, 18, 19, 20, 21, 15, 16);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 3, 16, 17, 18, 19, 20, 14, 15);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 3, 15, 16, 17, 18, 19, 13, 14);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 3, 14, 15, 16, 17, 18, 12, 13);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 3, 13, 14, 15, 16, 17, 11, 12);
                                break;
                        }; break;
                    };
                case 18:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 4, 20, 21, 22, 23, 24, 18, 19);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 4, 19, 20, 21, 22, 23, 17, 18);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 4, 18, 19, 20, 21, 22, 16, 17);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 3, 17, 18, 19, 20, 21, 15, 16);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 3, 16, 17, 18, 19, 20, 14, 15);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 3, 15, 16, 17, 18, 19, 13, 14);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 3, 14, 15, 16, 17, 18, 12, 13);
                                break;
                        }; break;
                    };
                case 19:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 4, 21, 22, 23, 24, 25, 19, 20);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 4, 20, 21, 22, 23, 24, 18, 19);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 4, 19, 20, 21, 22, 23, 17, 18);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 4, 18, 19, 20, 21, 22, 16, 17);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 3, 17, 18, 19, 20, 21, 15, 16);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 3, 16, 17, 18, 19, 20, 14, 15);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 3, 15, 16, 17, 18, 19, 13, 14);
                                break;
                        }; break;
                    };
                case 20:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 4, 22, 23, 24, 25, 26, 20, 21);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 4, 21, 22, 23, 24, 25, 19, 20);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 4, 20, 21, 22, 23, 24, 18, 19);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 4, 19, 20, 21, 22, 23, 17, 18);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 4, 18, 19, 20, 21, 22, 16, 17);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 3, 17, 18, 19, 20, 21, 15, 16);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 3, 16, 17, 18, 19, 20, 14, 15);
                                break;
                        }; break;
                    };
                case 21:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 4, 23, 24, 25, 26, 27, 21, 22);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 4, 22, 23, 24, 25, 26, 20, 21);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 4, 21, 22, 23, 24, 25, 19, 20);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 4, 20, 21, 22, 23, 24, 18, 19);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 4, 19, 20, 21, 22, 23, 17, 18);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 4, 18, 19, 20, 21, 22, 16, 17);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 3, 17, 18, 19, 20, 21, 15, 16);
                                break;
                        }; break;
                    };
                case 22:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 4, 24, 25, 26, 27, 28, 22, 23);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 4, 23, 24, 25, 26, 27, 21, 22);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 4, 22, 23, 24, 25, 26, 20, 21);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 4, 21, 22, 23, 24, 25, 19, 20);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 4, 20, 21, 22, 23, 24, 18, 19);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 4, 19, 20, 21, 22, 23, 17, 18);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 4, 18, 19, 20, 21, 22, 16, 17);
                                break;
                        }; break;
                    };
                case 23:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 5, 25, 26, 27, 28, 29, 23, 24);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 4, 24, 25, 26, 27, 28, 22, 23);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 4, 23, 24, 25, 26, 27, 21, 22);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 4, 22, 23, 24, 25, 26, 20, 21);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 4, 21, 22, 23, 24, 25, 19, 20);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 4, 20, 21, 22, 23, 24, 18, 19);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 4, 19, 20, 21, 22, 23, 17, 18);
                                break;
                        }; break;
                    };
                case 24:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 5, 26, 27, 28, 29, 30, 24, 25);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 5, 25, 26, 27, 28, 29, 23, 24);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 4, 24, 25, 26, 27, 28, 22, 23);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 4, 23, 24, 25, 26, 27, 21, 22);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 4, 22, 23, 24, 25, 26, 20, 21);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 4, 21, 22, 23, 24, 25, 19, 20);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 4, 20, 21, 22, 23, 24, 18, 19);
                                break;
                        }; break;
                    };
                case 25:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 5, 27, 28, 29, 30, 31, 25, 26);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 5, 26, 27, 28, 29, 30, 24, 25);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 5, 25, 26, 27, 28, 29, 23, 24);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 4, 24, 25, 26, 27, 28, 22, 23);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 4, 23, 24, 25, 26, 27, 21, 22);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 4, 22, 23, 24, 25, 26, 20, 21);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 4, 21, 22, 23, 24, 25, 19, 20);
                                break;
                        }; break;
                    };
                case 26:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 5, 28, 29, 30, 31, 0, 26, 27);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 5, 27, 28, 29, 30, 31, 25, 26);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 5, 26, 27, 28, 29, 30, 24, 25);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 5, 25, 26, 27, 28, 29, 23, 24);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 4, 24, 25, 26, 27, 28, 22, 23);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 4, 23, 24, 25, 26, 27, 21, 22);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 4, 22, 23, 24, 25, 26, 20, 21);
                                break;
                        }; break;
                    };
                case 27:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 5, 29, 30, 31, 0, 0, 27, 28);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 5, 28, 29, 30, 31, 0, 26, 27);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 5, 27, 28, 29, 30, 31, 25, 26);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 5, 26, 27, 28, 29, 30, 24, 25);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 5, 25, 26, 27, 28, 29, 23, 24);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 4, 24, 25, 26, 27, 28, 22, 23);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 4, 23, 24, 25, 26, 27, 21, 22);
                                break;
                        }; break;
                    };
                case 28:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 5, 30, 31, 0, 0, 0, 28, 29);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 5, 29, 30, 31, 0, 0, 27, 28);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 5, 28, 29, 30, 31, 0, 26, 27);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 5, 27, 28, 29, 30, 31, 25, 26);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 5, 26, 27, 28, 29, 30, 24, 25);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 5, 25, 26, 27, 28, 29, 23, 24);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 4, 24, 25, 26, 27, 28, 22, 23);
                                break;
                        }; break;
                    };
                case 29:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 5, 31, 0, 0, 0, 0, 29, 30);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 5, 30, 31, 0, 0, 0, 28, 29);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 5, 29, 30, 31, 0, 0, 27, 28);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 5, 28, 29, 30, 31, 0, 26, 27);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 5, 27, 28, 29, 30, 31, 25, 26);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 5, 26, 27, 28, 29, 30, 24, 25);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 5, 25, 26, 27, 28, 29, 23, 24);
                                break;
                        }; break;
                    };
                case 30:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 6, 0, 0, 0, 0, 0, 30, 31);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 5, 31, 0, 0, 0, 0, 29, 30);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 5, 30, 31, 0, 0, 0, 28, 29);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 5, 29, 30, 31, 0, 0, 27, 28);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 5, 28, 29, 30, 31, 0, 26, 27);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 5, 27, 28, 29, 30, 31, 25, 26);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 5, 26, 27, 28, 29, 30, 24, 25);
                                break;
                        }; break;
                    };
                case 31:
                    {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Saturday:
                                range = ChargueRange(date.Year, date.Month, 6, 0, 0, 0, 0, 0, 31, 0);
                                break;
                            case DayOfWeek.Sunday:
                                range = ChargueRange(date.Year, date.Month, 6, 0, 0, 0, 0, 0, 30, 31);
                                break;
                            case DayOfWeek.Monday:
                                range = ChargueRange(date.Year, date.Month, 5, 31, 0, 0, 0, 0, 29, 30);
                                break;
                            case DayOfWeek.Tuesday:
                                range = ChargueRange(date.Year, date.Month, 5, 30, 31, 0, 0, 0, 28, 29);
                                break;
                            case DayOfWeek.Wednesday:
                                range = ChargueRange(date.Year, date.Month, 5, 29, 30, 31, 0, 0, 27, 28);
                                break;
                            case DayOfWeek.Thursday:
                                range = ChargueRange(date.Year, date.Month, 5, 28, 29, 30, 31, 0, 26, 27);
                                break;
                            case DayOfWeek.Friday:
                                range = ChargueRange(date.Year, date.Month, 5, 27, 28, 29, 30, 31, 25, 26);
                                break;
                        }; break;
                    };
            }

            return range;
        }
        /*
        public RangeOfDate ChargueWeek(int Year, int Month, int weekOfMonth, DayOfWeek day, int date)
        {
            RangeOfDate range = new RangeOfDate();

            switch (day)
            {
                case DayOfWeek.Saturday:
                    range = ChargueRange(
                        Year, Month, weekOfMonth, 
                        validateWeekDay(weekOfMonth, date + 2), 
                        validateWeekDay(weekOfMonth, date + 3), 
                        validateWeekDay(weekOfMonth, date + 4), 
                        validateWeekDay(weekOfMonth, date + 5), 
                        validateWeekDay(weekOfMonth, date + 6), 
                        validateWeekDay(weekOfMonth, date), 
                        validateWeekDay(weekOfMonth, date + 1));
                    break;
                case DayOfWeek.Sunday:
                    range = ChargueRange(
                        Year, Month, weekOfMonth,
                        validateWeekDay(weekOfMonth, date + 1),
                        validateWeekDay(weekOfMonth, date + 2),
                        validateWeekDay(weekOfMonth, date + 3),
                        validateWeekDay(weekOfMonth, date + 4),
                        validateWeekDay(weekOfMonth, date + 5),
                        validateWeekDay(weekOfMonth, date + 6),
                        validateWeekDay(weekOfMonth, date));
                    break;
                case DayOfWeek.Monday:
                    range = ChargueRange(
                        Year, Month, weekOfMonth,
                        validateWeekDay(weekOfMonth, date),
                        validateWeekDay(weekOfMonth, date + 1),
                        validateWeekDay(weekOfMonth, date + 2),
                        validateWeekDay(weekOfMonth, date + 3),
                        validateWeekDay(weekOfMonth, date + 4),
                        validateWeekDay(weekOfMonth, date + 5),
                        validateWeekDay(weekOfMonth, date + 6));
                    break;
                case DayOfWeek.Tuesday:
                    range = ChargueRange(
                        Year, Month, weekOfMonth,
                        validateWeekDay(weekOfMonth, date + 6),
                        validateWeekDay(weekOfMonth, date),
                        validateWeekDay(weekOfMonth, date + 1),
                        validateWeekDay(weekOfMonth, date + 2),
                        validateWeekDay(weekOfMonth, date + 3),
                        validateWeekDay(weekOfMonth, date + 4),
                        validateWeekDay(weekOfMonth, date + 5));
                    break;
                case DayOfWeek.Wednesday:
                    range = ChargueRange(
                        Year, Month, weekOfMonth,
                        validateWeekDay(weekOfMonth, date + 5),
                        validateWeekDay(weekOfMonth, date + 6),
                        validateWeekDay(weekOfMonth, date),
                        validateWeekDay(weekOfMonth, date + 1),
                        validateWeekDay(weekOfMonth, date + 2),
                        validateWeekDay(weekOfMonth, date + 3),
                        validateWeekDay(weekOfMonth, date + 4));
                    break;
                case DayOfWeek.Thursday:
                    
                case DayOfWeek.Friday:
                    range = ChargueRange(
                         Year, Month, weekOfMonth,
                         validateWeekDay(weekOfMonth, date + 3),
                         validateWeekDay(weekOfMonth, date + 4),
                         validateWeekDay(weekOfMonth, date + 5),
                         validateWeekDay(weekOfMonth, date + 6),
                         validateWeekDay(weekOfMonth, date),
                         validateWeekDay(weekOfMonth, date + 1),
                         validateWeekDay(weekOfMonth, date + 2));
                    break;
            }

            return range;
        }

        public int validateWeekDay(int weekOfMonth, int date)
        {
            int response = date;
            switch (weekOfMonth)
            {
                case 1:
                    if (date > 7) response = 0;
                    break;
                case 2:
                    if (date > 14) response = 0;
                    break;
                case 3:
                    if (date > 21) response = 0;
                    break;
                case 4:
                    if (date > 28) response = 0;
                    break;
                case 5:
                    if (date > 31) response = 0;
                    break;
                case 6:
                    if (date > 31) response = 0;
                    break;
            }

            return response;
        }
        */
        public RangeOfDate ChargueRange(int Year, int Month, int weekOfMonth,int Monday, int Tuesday, int Wednesday, int Thursday, int Friday, int Saturday, int Sunday)
        {
            RangeOfDate range = new RangeOfDate();
            var max = DateTime.DaysInMonth(Year,Month);

            
            range.WeekOfMonth = weekOfMonth;
            if (Monday != 0&&Monday<=max)
            {
                range.MondayDate = new DateTime(Year, Month, Monday);
                range.MondayDateFormat = range.MondayDate.ToString(BE.n.util.CustomeDateFormat());

            }
            if (Tuesday != 0 && Tuesday <= max)
            {

                range.TuesdayDate = new DateTime(Year, Month, Tuesday);
                range.TuesdayDateFormat = range.TuesdayDate.ToString(BE.n.util.CustomeDateFormat());
            }
            if (Wednesday != 0 && Wednesday <= max)
            {

                range.WednesdayDate = new DateTime(Year, Month, Wednesday);
                range.WednesdayDateFormat = range.WednesdayDate.ToString(BE.n.util.CustomeDateFormat());
            }
            if (Thursday != 0 && Thursday <= max)
            {

                range.ThursdayDate = new DateTime(Year, Month, Thursday);
                range.ThursdayDateFormat = range.ThursdayDate.ToString(BE.n.util.CustomeDateFormat());
            }
            if (Friday != 0 && Friday <= max)
            {

                range.FridayDate = new DateTime(Year, Month, Friday);
                range.FridayDateFormat = range.FridayDate.ToString(BE.n.util.CustomeDateFormat());
            }
            if (Saturday != 0 && Saturday <= max)
            {

                range.SaturdayDate = new DateTime(Year, Month, Saturday);
                range.SaturdayDateFormat = range.SaturdayDate.ToString(BE.n.util.CustomeDateFormat());
            }
            if (Sunday != 0 && Sunday <= max)
            {

                range.SundayDate = new DateTime(Year, Month, Sunday);
                range.SundayDateFormat = range.SundayDate.ToString(BE.n.util.CustomeDateFormat());
            }

            return range;
        }

        public static string CustomeDateFormat() {

            return "dd/MM/yyyy";
        }
    }



    public class RangeOfDate
    {
        public int WeekOfMonth { get; set; }
        public DateTime MondayDate { get; set; }
        public string MondayDateFormat { get; set; }
        public DateTime TuesdayDate { get; set; }
        public string TuesdayDateFormat { get; set; }
        public DateTime WednesdayDate { get; set; }
        public string WednesdayDateFormat { get; set; }
        public DateTime ThursdayDate { get; set; }
        public string ThursdayDateFormat { get; set; }
        public DateTime FridayDate { get; set; }
        public string FridayDateFormat { get; set; }
        public DateTime SaturdayDate { get; set; }
        public string SaturdayDateFormat { get; set; }
        public DateTime SundayDate { get; set; }
        public string SundayDateFormat { get; set; }
    }
}
