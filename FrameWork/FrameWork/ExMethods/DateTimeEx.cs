namespace FrameWork.ExMethods
{
    public static class DateTimeEx
    {
        public static string GetTxtTimeSpan(this DateTime dateTime)
        {
            TimeSpan dt = new TimeSpan(); ;
            dt = DateTime.Now - dateTime;

            if (dt.Days >= 365)
            {
                double years = dt.Days / 365;
                return Math.Round(years) + " " + "سال پیش";
            }
            else
            {
                if (dt.Days >= 30)
                {
                    double months = dt.Days / 30;
                    return Math.Round(months) + " " + "ماه پیش";
                }
                else
                {
                    if (dt.Days >= 7)
                    {
                        double week = dt.Days / 7;
                        return Math.Round(week) + " " + "هفته پیش";
                    }
                    else
                    {
                        if (dt.Days >= 2)
                        {
                            double days = dt.Days;
                            return Math.Round(days) + " " + "روز پیش";
                        }
                        else
                        {
                            if (dt.Days == 1)
                            {
                                //double Days = dt.Days / 1;
                                return "دیروز";
                            }
                            else
                            {

                                if (dt.Hours>0)
                                    return dt.Hours + " " + "ساعت پیش";
                                else
                                {
                                    if (dt.Minutes>0)
                                        return dt.Minutes + " " + "دقیقه پیش";
                                    else
                                    {
                                        if (dt.Seconds>0)
                                            return dt.Seconds + " " + "ثانیه پیش";
                                        else
                                            return "همین الان";
                                    }
                                }
                            }

                        }
                    }

                }
            }


        }
    }
}
