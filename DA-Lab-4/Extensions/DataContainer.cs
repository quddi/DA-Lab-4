using System;
using System.Collections.Generic;

namespace DA_Lab_4
{
    public static class DataContainer
    {
        public static Dictionary<Type, List<IData>> Datas = new();

        public const double Tolerance = 0.00001;

        public static void Reset()
        {
            Datas.Clear();
        }
    }
}
