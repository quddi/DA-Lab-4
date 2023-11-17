using System;
using System.Collections.Generic;

namespace DA_Lab_4
{
    public static class IndependentDataContainer
    {
        public static (List<double> X, List<double> Y)? Datas;
        
        public static void SetDatas((List<double> X, List<double> Y) datas)
        {
            if (datas.X.Count != datas.Y.Count)
                throw new ArgumentException($"Element counts does not match! X: {datas.X.Count}, Y: {datas.Y.Count}");

            Reset();

            Datas = datas;
        }

        private static void Reset()
        {
            Datas = null;
        }
    }
}
