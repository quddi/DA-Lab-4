using System;
using System.Linq;
using System.Collections.Generic;

namespace DA_Lab_4
{
    public static class DependentDataContainer
    {
        private static int? _elementsCount;
        private static List<double>? _differences;
        private static double? _xMean;
        private static double? _yMean;
        private static double? _xVariance;
        private static double? _yVariance;
        private static double? _differencesMean;
        private static double? _differencesVariance;
        private static double? _differencesStandardDeviation;
        private static double? _differencesPairedTTest;
        private static double? _differencesStudentQuantile;
        private static double? _differencesFTest;
        private static double? _freedomDegree;
        private static double? _fisherQuantile;

        public static int ElementsCount
        {
            get
            {
                if (_elementsCount == null)
                    ComputeElementsCount();

                return _elementsCount!.Value;
            }
        }

        public static List<double> Differences
        {
            get
            {
                if (_differences == null)
                    ComputeDifferences();

                return _differences!;
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

        public static double DifferencesMean
        {
            get
            {
                if (_differencesMean == null)
                    ComputeDifferencesMean();

                return _differencesMean!.Value;
            }
        }

        public static double DifferencesVariance
        {
            get
            {
                if (_differencesVariance == null)
                    ComputeDifferencesVariance();

                return _differencesVariance!.Value;
            }
        }

        public static double DifferencesStandardDeviation
        {
            get
            {
                if (_differencesStandardDeviation == null)
                    ComputeDifferencesStandardDeviation();

                return _differencesStandardDeviation!.Value;
            }
        }

        public static double DifferencesPairedTTest
        {
            get
            {
                if (_differencesPairedTTest == null)
                    ComputeDifferencesPairedTTest();

                return _differencesPairedTTest!.Value;
            }
        }

        public static double DifferencesFTest
        {
            get
            {
                if (_differencesFTest == null)
                    ComputeDifferencesFTest();

                return _differencesFTest!.Value;
            }
        }

        public static double DifferencesStudentQuantile
        {
            get
            {
                if (_differencesStudentQuantile == null)
                    ComputeDifferencesStudentQuantile();

                return _differencesStudentQuantile!.Value;
            }
        }

        public static double FreedomDegree
        {
            get
            {
                if (_freedomDegree == null)
                    ComputeFreedomDegree();

                return _freedomDegree!.Value;
            }
        }

        public static double FisherQuantile
        {
            get
            {
                if (_fisherQuantile == null)
                    ComputeFisherQuantile();

                return _fisherQuantile!.Value;
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
            _elementsCount = null;
            _differences = null;
            _xMean = null;
            _yMean = null;
            _xVariance = null;
            _yVariance = null;
            _differencesMean = null;
            _differencesVariance = null;
            _differencesStandardDeviation = null;
            _differencesPairedTTest = null;
            _differencesStudentQuantile = null;
            _differencesFTest = null;
            _freedomDegree = null;
            _fisherQuantile = null;
        }

        #region Computing methods
        private static void ComputeElementsCount()
        {
            _elementsCount = Datas?.X.Count;
        }

        private static void ComputeDifferences()
        {
            _differences = new();

            for (int i = 0; i < ElementsCount; i++)
            {
                double? currentDifference = Datas?.X[i] - Datas?.Y[i];

                _differences.Add(currentDifference!.Value);
            }
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

        private static void ComputeDifferencesMean()
        {
            _differencesMean = Differences.Average();
        }

        private static void ComputeDifferencesVariance()
        {
            _differencesVariance = Compute.Variance(Differences, DifferencesMean);
        }

        private static void ComputeDifferencesStandardDeviation()
        {
            _differencesStandardDeviation = Compute.StandardDeviation(DifferencesVariance);
        }

        private static void ComputeDifferencesPairedTTest()
        {
            _differencesPairedTTest = DifferencesMean * Math.Sqrt(ElementsCount) / DifferencesStandardDeviation;
        }

        private static void ComputeDifferencesStudentQuantile()
        {
            _differencesStudentQuantile = Compute.StudentDistributionQuantile(1D - Constants.Alpha / 2D, ElementsCount - 1);
        }

        private static void ComputeDifferencesFTest()
        {
            _differencesFTest = XVariance > YVariance
                ? XVariance / YVariance 
                : YVariance / XVariance;
        }

        private static void ComputeFreedomDegree()
        {
            _freedomDegree = ElementsCount - 1;
        }

        private static void ComputeFisherQuantile()
        {
            _fisherQuantile = Compute.FisherDistributionQuantile(1D - Constants.Alpha, FreedomDegree, FreedomDegree);
        }
        #endregion
    }
}
