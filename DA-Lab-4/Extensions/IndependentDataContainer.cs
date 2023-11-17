using System;
using System.Collections.Generic;
using System.Linq;

namespace DA_Lab_4
{
    public static class IndependentDataContainer
    {
        private static int? _xElementsCount;
        private static int? _yElementsCount;
        private static double? _xMean;
        private static double? _yMean;
        private static double? _xVariance;
        private static double? _yVariance;
        private static double? _weightedAverage;
        private static double? _twoSampleTTest;
        private static double? _studentQuantile;
        private static double? _witchelTTest;
        private static double? _witchelStudentQuantile;
        private static double? _witchelFreedomDegreesCount;

        public static int XElementsCount
        {
            get
            {
                if (_xElementsCount == null)
                    ComputeXElementsCount();

                return _xElementsCount!.Value;
            }
        }

        public static int YElementsCount
        {
            get
            {
                if (_yElementsCount == null)
                    ComputeYElementsCount();

                return _yElementsCount!.Value;
            }
        }

        public static double XMean
        {
            get
            {
                if (_xMean == null)
                    ComputeXMean();

                return _xMean!.Value;
            }
        }

        public static double YMean
        {
            get
            {
                if (_yMean == null)
                    ComputeYMean();

                return _yMean!.Value;
            }
        }

        public static double XVariance
        {
            get
            {
                if (_xVariance == null)
                    ComputeXVariance();

                return _xVariance!.Value;
            }
        }

        public static double YVariance
        {
            get
            {
                if (_yVariance == null)
                    ComputeYVariance();

                return _yVariance!.Value;
            }
        }

        public static double WeightedAverage
        {
            get
            {
                if (_weightedAverage == null)
                    ComputeWeightedAverage();

                return _weightedAverage!.Value;
            }
        }

        public static double TwoSampleTTest
        {
            get
            {
                if (_twoSampleTTest == null)
                    ComputeTwoSampleTTest();

                return _twoSampleTTest!.Value;
            }
        }

        public static double StudentQuantile
        {
            get
            {
                if (_studentQuantile == null)
                    ComputeStudentQuantile();

                return _studentQuantile!.Value;
            }
        }

        public static double WitchelTTest
        {
            get
            {
                if (_witchelTTest == null)
                    ComputeWitchelTTest();

                return _witchelTTest!.Value;
            }
        }

        public static double WitchelStudentQuantile
        {
            get
            {
                if (_witchelStudentQuantile == null)
                    ComputeWitchelStudentQuantile();

                return _witchelStudentQuantile!.Value;
            }
        }

        private static double WitchelFreedomDegreesCount
        {
            get
            {
                if (_witchelFreedomDegreesCount == null)
                    ComputeWitchelFreedomDegreesCount();

                return _witchelFreedomDegreesCount!.Value;
            }
        }

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

        #region Computing methods
        private static void ComputeXElementsCount()
        {
            _xElementsCount = Datas?.X.Count;
        }

        private static void ComputeYElementsCount()
        {
            _yElementsCount = Datas?.Y.Count;
        }

        private static void ComputeXMean()
        {
            _xMean = Datas?.X.Average()!;
        }

        private static void ComputeYMean()
        {
            _yMean = Datas?.Y.Average()!;
        }

        private static void ComputeXVariance()
        {
            _xVariance = Compute.Variance(Datas?.X!, XMean);
        }

        private static void ComputeYVariance()
        {
            _yVariance = Compute.Variance(Datas?.Y!, YMean);
        }

        private static void ComputeWeightedAverage()
        {
            _weightedAverage = ((XElementsCount - 1) * XVariance + (YElementsCount - 1) * YVariance) / (XElementsCount + YElementsCount - 2);
        }

        private static void ComputeTwoSampleTTest() 
        {
            _twoSampleTTest = (XMean - YMean) / Math.Sqrt(WeightedAverage / XElementsCount + WeightedAverage / YElementsCount);
        }

        private static void ComputeStudentQuantile()
        {
            _studentQuantile = Compute.StudentDistributionQuantile(1D - Constants.Alpha / 2, XElementsCount + YElementsCount - 2);
        }

        private static void ComputeWitchelTTest()
        {
            _witchelTTest = (XMean - YMean) / Math.Sqrt(XVariance / XElementsCount + YVariance / YElementsCount);
        }

        private static void ComputeWitchelStudentQuantile()
        {
            _witchelStudentQuantile = Compute.StudentDistributionQuantile(1D - Constants.Alpha / 2, WitchelFreedomDegreesCount);
        }

        private static void ComputeWitchelFreedomDegreesCount()
        {
            var firstParentheses = Math.Pow(XVariance / XElementsCount + YVariance / XElementsCount, 2);
            var secondParenthesesPart1 = Math.Pow(XVariance, 2) / ((XElementsCount - 1) * XElementsCount * XElementsCount);
            var secondParenthesesPart2 = Math.Pow(YVariance, 2) / ((YElementsCount - 1) * YElementsCount * YElementsCount);
            var secondParentheses = Math.Pow(secondParenthesesPart1 + secondParenthesesPart2, -1);

            _witchelFreedomDegreesCount = firstParentheses * secondParentheses;
        }
        #endregion
    }
}
