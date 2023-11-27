using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DA_Lab_4
{
    public class IndependentDataContainer
    {
        private double? _weightedAverage;
        private double? _twoSampleTTest;
        private double? _studentQuantile;
        private double? _fisherQuantile;
        private double? _greatestFreedomDegree;
        private double? _lowestFreedomDegree;
        private double? _fTest;
        private double? _welchTTest;
        private double? _welchStudentQuantile;
        private double? _welchFreedomDegreesCount;
        private double? _xRankedStrokeStatistics;
        private double? _xRankedStatistics;
        private double? _xDParameter;
        private double? _xUValue;
        private List<double>? _mergedOrderedValues;
        private Dictionary<double, double>? _mergedRanks;

        public double WeightedAverage
        {
            get
            {
                if (_weightedAverage == null)
                    ComputeWeightedAverage();

                return _weightedAverage!.Value;
            }
        }

        public double TwoSampleTTest
        {
            get
            {
                if (_twoSampleTTest == null)
                    ComputeTwoSampleTTest();

                return _twoSampleTTest!.Value;
            }
        }

        public double StudentQuantile
        {
            get
            {
                if (_studentQuantile == null)
                    ComputeStudentQuantile();

                return _studentQuantile!.Value;
            }
        }

        public double FisherQuantile
        {
            get
            {
                if (_fisherQuantile == null)
                    ComputeFisherQuantile();

                return _fisherQuantile!.Value;
            }
        }

        public double GreatestFreedomDegree
        {
            get
            {
                if (_greatestFreedomDegree == null)
                    ComputeGreatestFreedomDegree();

                return _greatestFreedomDegree!.Value;
            }
        }

        public double LowestFreedomDegree
        {
            get
            {
                if (_greatestFreedomDegree == null)
                    ComputeLowestFreedomDegree();

                return _greatestFreedomDegree!.Value;
            }
        }

        public double FTest
        {
            get
            {
                if (_fTest == null)
                    ComputeFTest();

                return _fTest!.Value;
            }
        }

        public double WelchTTest
        {
            get
            {
                if (_welchTTest == null)
                    ComputeWelchTTest();

                return _welchTTest!.Value;
            }
        }

        public double WelchStudentQuantile
        {
            get
            {
                if (_welchStudentQuantile == null)
                    ComputeWelchStudentQuantile();

                return _welchStudentQuantile!.Value;
            }
        }

        public double WelchFreedomDegreesCount
        {
            get
            {
                if (_welchFreedomDegreesCount == null)
                    ComputeWelchFreedomDegreesCount();

                return _welchFreedomDegreesCount!.Value;
            }
        }

        public double XRankedStrokeStatistics
        {
            get
            {
                if (_xRankedStrokeStatistics == null)
                    ComputeXRankedStrokeStatistics();

                return _xRankedStrokeStatistics!.Value;
            }
        }

        public double XRankedStatistics
        {
            get
            {
                if (_xRankedStatistics == null)
                    ComputeXRankedStatistics();

                return _xRankedStatistics!.Value;
            }
        }

        public double XDParameter
        {
            get
            {
                if (_xDParameter == null)
                    ComputeXDParameter();

                return _xDParameter!.Value;
            }
        }

        public double XUValue
        {
            get
            {
                if (_xUValue == null)
                    ComputeXUValue();

                return _xUValue!.Value;
            }
        }

        public List<double> MergedOrderedValues
        {
            get
            {
                if (_mergedOrderedValues == null)
                    ComputeMergedOrderedValues();

                return _mergedOrderedValues!;
            }
        }

        public Dictionary<double, double> MergedRanks
        {
            get
            {
                if (_mergedRanks == null)
                    ComputeMergedRanks();

                return _mergedRanks!;
            }
        }

        public int ElementsCount => XDataContainer.ElementsCount + YDataContainer.ElementsCount;

        public bool AreNormalDistributed => XDataContainer.IsNormalDistributed && YDataContainer.IsNormalDistributed;

        public DataContainer XDataContainer { get; private set; }
        public DataContainer YDataContainer { get; private set; }

        public IndependentDataContainer((List<double> X, List<double> Y) datas)
        {
            XDataContainer = new DataContainer() { Datas = datas.X };
            YDataContainer = new DataContainer() { Datas = datas.Y };
        }

        #region Computing methods
        private void ComputeWeightedAverage()
        {
            _weightedAverage = ((XDataContainer.ElementsCount - 1) * XDataContainer.Variance +
                (YDataContainer.ElementsCount - 1) * YDataContainer.Variance) / (XDataContainer.ElementsCount + YDataContainer.ElementsCount - 2);
        }

        private void ComputeTwoSampleTTest()
        {
            _twoSampleTTest = (XDataContainer.Mean - YDataContainer.Mean) / Math.Sqrt(WeightedAverage / XDataContainer.ElementsCount + WeightedAverage / YDataContainer.ElementsCount);
        }

        private void ComputeStudentQuantile()
        {
            _studentQuantile = Compute.StudentDistributionQuantile(1D - Constants.Alpha / 2, XDataContainer.ElementsCount + YDataContainer.ElementsCount - 2);
        }

        private void ComputeFisherQuantile()
        {
            _fisherQuantile = Compute.FisherDistributionQuantile(1D - Constants.Alpha, GreatestFreedomDegree, LowestFreedomDegree);
        }

        private void ComputeGreatestFreedomDegree()
        {
            _greatestFreedomDegree = Math.Max(XDataContainer.ElementsCount, YDataContainer.ElementsCount) - 1;
        }

        private void ComputeLowestFreedomDegree()
        {
            _lowestFreedomDegree = Math.Min(XDataContainer.ElementsCount, YDataContainer.ElementsCount) - 1;
        }

        private void ComputeFTest()
        {
            _fTest = XDataContainer.Variance > YDataContainer.Variance
                ? XDataContainer.Variance / YDataContainer.Variance
                : YDataContainer.Variance / XDataContainer.Variance;
        }

        private void ComputeWelchTTest()
        {
            _welchTTest = (XDataContainer.Mean - YDataContainer.Mean) / Math.Sqrt(XDataContainer.Variance / XDataContainer.ElementsCount + YDataContainer.Variance / YDataContainer.ElementsCount);
        }

        private void ComputeWelchStudentQuantile()
        {
            _welchStudentQuantile = Compute.StudentDistributionQuantile(1D - Constants.Alpha / 2, WelchFreedomDegreesCount);
        }

        private void ComputeWelchFreedomDegreesCount()
        {
            var firstParentheses = Math.Pow(XDataContainer.Variance / XDataContainer.ElementsCount + YDataContainer.Variance / XDataContainer.ElementsCount, 2);
            var secondParenthesesPart1 = Math.Pow(XDataContainer.Variance, 2) / ((XDataContainer.ElementsCount - 1) * XDataContainer.ElementsCount * XDataContainer.ElementsCount);
            var secondParenthesesPart2 = Math.Pow(YDataContainer.Variance, 2) / ((YDataContainer.ElementsCount - 1) * YDataContainer.ElementsCount * YDataContainer.ElementsCount);
            var secondParentheses = Math.Pow(secondParenthesesPart1 + secondParenthesesPart2, -1);

            _welchFreedomDegreesCount = firstParentheses * secondParentheses;
        }

        private void ComputeXRankedStrokeStatistics()
        {
            _xRankedStrokeStatistics = MergedRanks.Sum(valuePairRank =>
            {
                if (YDataContainer.Datas.Contains(valuePairRank.Key))
                    return 0;

                var quantile = Compute.NormalDistributionQuantile(valuePairRank.Value / (ElementsCount + 1));
                var times = MergedOrderedValues.Count(value => value.IsEqual(valuePairRank.Key));

                return quantile * times;
            });
        }

        private void ComputeXRankedStatistics()
        {
            var repeatedValues = MergedOrderedValues
            .Where(value => XDataContainer.Datas.Contains(value) && YDataContainer.Datas.Contains(value))
            .Distinct()
            .Order()
            .ToList();

            var qSum = 0D;

            if (repeatedValues.Count > 0) 
            {
                var groupedValuesIndexes = MergedOrderedValues.ElementsIndexes(repeatedValues);

                foreach (var valuePairIndexes in groupedValuesIndexes)
                {
                    var q = valuePairIndexes.Value.Sum(index =>
                        Compute.NormalDistributionQuantile(((double)index) / (ElementsCount + 1)));

                    qSum += q * XDataContainer.Datas.Count(value => value.IsEqual(valuePairIndexes.Key))
                           / valuePairIndexes.Value.Count;
                }
            }
            
            _xRankedStatistics = XRankedStrokeStatistics + qSum;
        }

        private void ComputeXDParameter()
        {
            var multiplier = ((double)XDataContainer.ElementsCount * YDataContainer.ElementsCount) / (ElementsCount * (ElementsCount - 1));

            var sum = 0D;

            for (int i = 0; i < ElementsCount; i++)
            {
                var quantile = Compute.NormalDistributionQuantile(((double)i + 1) / (ElementsCount + 1));

                sum += quantile * quantile;
            }

            _xDParameter = multiplier * sum;
        }

        private void ComputeXUValue()
        {
            _xUValue = XRankedStatistics / Math.Sqrt(XDParameter);
        }

        private void ComputeMergedOrderedValues()
        {
            _mergedOrderedValues = XDataContainer.Datas
                .Concat(YDataContainer.Datas)
                .Order()
                .ToList();
        }

        private void ComputeMergedRanks()
        {
            _mergedRanks = Compute.Ranks(MergedOrderedValues);
        }
        #endregion
    }
}
