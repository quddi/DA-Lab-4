using System;
using System.Collections.Generic;
using System.Linq;

namespace DA_Lab_4
{
    public class DataContainer
    {
        private int? _elementsCount;

        private double? _mean;
        private double? _meanSigma;
        private (double LeftEdge, double RightEdge)? _meanTrustInterval;

        private double? _median;
        private (double LeftEdge, double RightEdge)? _medianTrustInterval;

        private double? _standardDeviation;
        private double? _standardDeviationSigma;
        private (double LeftEdge, double RightEdge)? _standardDeviationTrustInterval;

        private double? _secondSkewnessCoefficient;
        private double? _secondSkewnessCoefficientSigma;
        private (double LeftEdge, double RightEdge)? _secondSkewnessCoefficientTrustInterval;

        private double? _secondKurtosisCoefficient;
        private double? _secondKurtosisCoefficientSigma;
        private (double LeftEdge, double RightEdge)? _secondKurtosisCoefficientTrustInterval;

        private double? _variance;
        private double? _studentQuantile;
        private double? _firstSkewnessCoefficient;
        private double? _firstKurtosisCoefficient;
        private double? _shiftedVariance;
        private double? _skewnessStatistics;
        private double? _kurtosisStatistics;
        private double? _rankingStatistics;
        private bool? _isNormalDistributed;
        private Dictionary<double, double>? _ranks;

        public int ElementsCount
        {
            get
            {
                if (_elementsCount == null)
                    ComputeElementsCount();

                return _elementsCount!.Value;
            }
        }

        public double Mean
        {
            get
            {
                if (_mean == null) ComputeMean();

                return _mean.Value;
            }
        }
        public double MeanSigma
        {
            get
            {
                if (_meanSigma == null) ComputeMean();

                return _meanSigma.Value;
            }
        }
        public (double LeftEdge, double RightEdge) MeanTrustInterval
        {
            get
            {
                if (_meanTrustInterval == null) ComputeMean();

                return _meanTrustInterval.Value;
            }
        }

        public double Median
        {
            get
            {
                if (_median == null) ComputeMedian();

                return _median.Value;
            }
        }
        public (double LeftEdge, double RightEdge) MedianTrustInterval
        {
            get
            {
                if (_medianTrustInterval == null) ComputeMedian();

                return _medianTrustInterval.Value;
            }
        }

        public double StandardDeviation
        {
            get
            {
                if (_standardDeviation == null) ComputeStandardDeviation();

                return _standardDeviation.Value;
            }
        }
        public double StandardDeviationSigma
        {
            get
            {
                if (_standardDeviationSigma == null) ComputeStandardDeviation();

                return _standardDeviationSigma.Value;
            }
        }
        public (double LeftEdge, double RightEdge) StandardDeviationTrustInterval
        {
            get
            {
                if (_standardDeviationTrustInterval == null) ComputeStandardDeviation();

                return _standardDeviationTrustInterval.Value;
            }
        }

        public double SecondSkewnessCoefficient
        {
            get
            {
                if (_secondSkewnessCoefficient == null) ComputeSecondSkewnessCoefficient();

                return _secondSkewnessCoefficient.Value;
            }
        }
        public double SecondSkewnessCoefficientSigma
        {
            get
            {
                if (_secondSkewnessCoefficientSigma == null) ComputeSecondSkewnessCoefficient();

                return _secondSkewnessCoefficientSigma.Value;
            }
        }
        public (double LeftEdge, double RightEdge) SecondSkewnessCoefficientTrustInterval
        {
            get
            {
                if (_secondSkewnessCoefficientTrustInterval == null) ComputeSecondSkewnessCoefficient();

                return _secondSkewnessCoefficientTrustInterval.Value;
            }
        }

        public double SecondKurtosisCoefficient
        {
            get
            {
                if (_secondKurtosisCoefficient == null) ComputeSecondKurtosisCoefficient();

                return _secondKurtosisCoefficient.Value;
            }
        }
        public double SecondKurtosisCoefficientSigma
        {
            get
            {
                if (_secondKurtosisCoefficientSigma == null) ComputeSecondKurtosisCoefficient();

                return _secondKurtosisCoefficientSigma.Value;
            }
        }
        public (double LeftEdge, double RightEdge) SecondKurtosisCoefficientTrustInterval
        {
            get
            {
                if (_secondKurtosisCoefficientTrustInterval == null) ComputeSecondKurtosisCoefficient();

                return _secondKurtosisCoefficientTrustInterval.Value;
            }
        }

        public double Variance
        {
            get
            {
                if (_variance == null) ComputeVariance();

                return _variance!.Value;
            }
        }

        public double StudentQuantile
        {
            get
            {
                if (_studentQuantile == null) ComputeStudentQuantile();

                return _studentQuantile.Value;
            }
        }

        public double FirstSkewnessCoefficient
        {
            get
            {
                if (_firstSkewnessCoefficient == null) ComputeFirstSkewnessCoefficient();

                return _firstSkewnessCoefficient.Value;
            }
        }

        public double FirstKurtosisCoefficient
        {
            get
            {
                if (_firstKurtosisCoefficient == null) ComputeFirstKurtosisCoefficient();

                return _firstKurtosisCoefficient.Value;
            }
        }

        public double ShiftedVariance
        {
            get
            {
                if (_shiftedVariance == null) ComputeShiftedVariance();

                return _shiftedVariance.Value;
            }
        }

        public double SkewnessStatistics
        {
            get
            {
                if (_skewnessStatistics == null)
                    ComputeSkewnessStatistics();

                return _skewnessStatistics!.Value;
            }
        }

        public double KurtosisStatistics
        {
            get
            {
                if (_kurtosisStatistics == null)
                    ComputeKurtosisStatistics();

                return _kurtosisStatistics!.Value;
            }
        }

        public bool IsNormalDistributed
        {
            get
            {
                if (_isNormalDistributed == null)
                    ComputeIsNormalDistributed();

                return _isNormalDistributed!.Value;
            }
        }

        public double? RankingStatistics
        {
            get => _rankingStatistics;
            set => _rankingStatistics = value;
        }

        public Dictionary<double, double> Ranks
        {
            get
            {
                if (_ranks == null)
                    ComputeRanks();

                return _ranks!;
            }
        }

        public required List<double> Datas { get; init; }

        public DataContainer() { }

        #region Computing methods
        private void ComputeElementsCount()
        {
            _elementsCount = Datas.Count;
        }

        private void ComputeMean()
        {
            _mean = Datas.Average();

            _meanSigma = Compute.MeanSquaredStandardDeviation(StandardDeviation, ElementsCount);

            _meanTrustInterval = (Mean - StudentQuantile * MeanSigma, Mean + StudentQuantile * MeanSigma);
        }

        private void ComputeMedian()
        {
            var orderedValues = Datas?.Order()?.ToList()!;

            _median = ElementsCount % 2 == 0
                ? (orderedValues[ElementsCount / 2] + orderedValues[ElementsCount / 2 - 1]) / 2f
                : orderedValues[ElementsCount / 2];

            var j = (int)(ElementsCount / 2 - Constants.NormalDistributionQuantile * Math.Sqrt(ElementsCount) / 2);
            var k = (int)(ElementsCount / 2 + 1 + Constants.NormalDistributionQuantile * Math.Sqrt(ElementsCount) / 2);

            _medianTrustInterval = (orderedValues[j], orderedValues[k]);
        }

        private void ComputeStandardDeviation()
        {
            _standardDeviation = Math.Sqrt(Variance);

            _standardDeviationSigma = Compute.SampleMeanSquaredStandardDeviation(StandardDeviation, ElementsCount);

            _standardDeviationTrustInterval = (
                StandardDeviation - StudentQuantile * StandardDeviationSigma,
                StandardDeviation + StudentQuantile * StandardDeviationSigma);
        }

        private void ComputeFirstSkewnessCoefficient()
        {
            var sum = Datas.Sum(value =>
            {
                var delta = value - Mean;

                return delta * delta * delta;
            });

            var shiftedVarianceSqrt = Math.Sqrt(ShiftedVariance);

            _firstSkewnessCoefficient = sum / (ElementsCount * shiftedVarianceSqrt * shiftedVarianceSqrt * shiftedVarianceSqrt);
        }

        private void ComputeSecondSkewnessCoefficient()
        {
            _secondSkewnessCoefficient = (FirstSkewnessCoefficient * Math.Sqrt(ElementsCount * (ElementsCount - 1)) / (ElementsCount - 2));

            _secondSkewnessCoefficientSigma = Compute.SkewnessCoefficientRootMeanSquareDeviation(ElementsCount);

            _secondSkewnessCoefficientTrustInterval = (
                SecondSkewnessCoefficient - StudentQuantile * SecondSkewnessCoefficientSigma,
                SecondSkewnessCoefficient + StudentQuantile * SecondSkewnessCoefficientSigma);
        }

        private void ComputeFirstKurtosisCoefficient()
        {
            var sum = Datas.Sum(value =>
            {
                var delta = value - Mean;
                return delta * delta * delta * delta;
            });

            _firstKurtosisCoefficient = (sum / (ElementsCount * ShiftedVariance * ShiftedVariance)) - 3;
        }

        private void ComputeSecondKurtosisCoefficient()
        {
            _secondKurtosisCoefficient = (FirstKurtosisCoefficient + 6.0 / (ElementsCount + 1)) 
                * ((ElementsCount * ElementsCount - 1) / ((ElementsCount - 2) * (ElementsCount - 3)));

            _secondKurtosisCoefficientSigma = Compute.KurtosisCoefficientRootMeanSquareDeviation(ElementsCount);

            _secondKurtosisCoefficientTrustInterval = (
                SecondKurtosisCoefficient - StudentQuantile * SecondKurtosisCoefficientSigma,
                SecondKurtosisCoefficient + StudentQuantile * SecondKurtosisCoefficientSigma);
        }

        private void ComputeVariance()
        {
            var sum = Datas.Sum(value =>
            {
                var delta = value - _mean;
                return delta * delta;
            });

            _variance = sum / (ElementsCount - 1); //S^2
        }

        private void ComputeStudentQuantile()
        {
            _studentQuantile = Compute.StudentDistributionQuantile(1D - Constants.Alpha / 2, ElementsCount - 1);
        }

        private void ComputeShiftedVariance()
        {
            _shiftedVariance = Variance * (ElementsCount - 1) / ElementsCount;
        }

        private void ComputeSkewnessStatistics()
        {
            _skewnessStatistics = SecondSkewnessCoefficient / SecondKurtosisCoefficientSigma;
        }

        private void ComputeKurtosisStatistics()
        {
            _kurtosisStatistics = SecondKurtosisCoefficient / SecondKurtosisCoefficientSigma;
        }

        private void ComputeRanks()
        {
            _ranks = Compute.Ranks(Datas);
        }

        private void ComputeIsNormalDistributed()
        {
            _isNormalDistributed =
                Math.Abs(SkewnessStatistics) < Constants.NormalDistributionQuantile &&
                Math.Abs(KurtosisStatistics) < Constants.NormalDistributionQuantile;
        }
        #endregion
    }
}
