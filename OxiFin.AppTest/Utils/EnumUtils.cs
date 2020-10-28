using System;

namespace OxiFin.AppTest.Utils
{
    static class EnumsUtil
    {
        public static T Random<T>()
        {
            Array values = Enum.GetValues(typeof(T));
            Random random = new Random();
            return (T) values.GetValue(random.Next(values.Length));
        }
    }
}
