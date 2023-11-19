using System;
using System.Collections.Generic;
using System.Linq;

namespace DA_Lab_4
{
    public class IndependentDataContainer
    {
        private double? _weightedAverage;
        private double? _twoSampleTTest;
        private double? _studentQuantile;
        private double? _witchelTTest;
        private double? _witchelStudentQuantile;
        private double? _witchelFreedomDegreesCount;

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

        public double WitchelTTest
        {
            get
            {
                if (_witchelTTest == null)
                    ComputeWitchelTTest();

                return _witchelTTest!.Value;
            }
        }

        public double WitchelStudentQuantile
        {
            get
            {
                if (_witchelStudentQuantile == null)
                    ComputeWitchelStudentQuantile();

                return _witchelStudentQuantile!.Value;
            }
        }

        private double WitchelFreedomDegreesCount
        {
            get
            {
                if (_witchelFreedomDegreesCount == null)
                    ComputeWitchelFreedomDegreesCount();

                return _witchelFreedomDegreesCount!.Value;
            }
        }

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

        private void ComputeWitchelTTest()
        {
            _witchelTTest = (XDataContainer.Mean - YDataContainer.Mean) / Math.Sqrt(XDataContainer.Variance / XDataContainer.ElementsCount + YDataContainer.Variance / YDataContainer.ElementsCount);
        }

        private void ComputeWitchelStudentQuantile()
        {
            _witchelStudentQuantile = Compute.StudentDistributionQuantile(1D - Constants.Alpha / 2, WitchelFreedomDegreesCount);
        }

        private void ComputeWitchelFreedomDegreesCount()
        {
            var firstParentheses = Math.Pow(XDataContainer.Variance / XDataContainer.ElementsCount + YDataContainer.Variance / XDataContainer.ElementsCount, 2);
            var secondParenthesesPart1 = Math.Pow(XDataContainer.Variance, 2) / ((XDataContainer.ElementsCount - 1) * XDataContainer.ElementsCount * XDataContainer.ElementsCount);
            var secondParenthesesPart2 = Math.Pow(YDataContainer.Variance, 2) / ((YDataContainer.ElementsCount - 1) * YDataContainer.ElementsCount * YDataContainer.ElementsCount);
            var secondParentheses = Math.Pow(secondParenthesesPart1 + secondParenthesesPart2, -1);

            _witchelFreedomDegreesCount = firstParentheses * secondParentheses;
        }
        #endregion
    }
}
