using System;
using System.Linq;
using System.Collections.Generic;

namespace DA_Lab_4
{
    public class DependentDataContainer
    {
        private double? _pairedTTest;
        private double? _fTest;
        private double? _freedomDegree;
        private double? _fisherQuantile;

        public double PairedTTest
        {
            get
            {
                if (_pairedTTest == null)
                    ComputePairedTTest();

                return _pairedTTest!.Value;
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

        public double FreedomDegree
        {
            get
            {
                if (_freedomDegree == null)
                    ComputeFreedomDegree();

                return _freedomDegree!.Value;
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

        public double ElementsCount => XDataContainer.ElementsCount;

        public DataContainer XDataContainer { get; private set; }
        public DataContainer YDataContainer { get; private set; }
        public DataContainer DifferencesDataContainer { get; private set; }

        public DependentDataContainer((List<double> X, List<double> Y) datas)
        {
            if (datas.X.Count != datas.Y.Count)
                throw new ArgumentException($"Element counts does not match! X: {datas.X.Count}, Y: {datas.Y.Count}");

            XDataContainer = new DataContainer() { Datas = datas.X };
            YDataContainer = new DataContainer() { Datas = datas.Y };

            var differences = new List<double>();

            for (int i = 0; i < XDataContainer.ElementsCount; i++)
            {
                double? currentDifference = datas.X[i] - datas.Y[i];

                differences.Add(currentDifference!.Value);
            }

            DifferencesDataContainer = new DataContainer() { Datas = differences };
        }

        #region Computing methods

        private void ComputePairedTTest()
        {
            _pairedTTest = DifferencesDataContainer.Mean * Math.Sqrt(ElementsCount) / DifferencesDataContainer.StandardDeviation;
        }

        private void ComputeFTest()
        {
            _fTest = XDataContainer.Variance > YDataContainer.Variance
                ? XDataContainer.Variance / YDataContainer.Variance 
                : YDataContainer.Variance / XDataContainer.Variance;
        }

        private void ComputeFreedomDegree()
        {
            _freedomDegree = ElementsCount - 1;
        }

        private void ComputeFisherQuantile()
        {
            _fisherQuantile = Compute.FisherDistributionQuantile(1D - Constants.Alpha, FreedomDegree, FreedomDegree);
        }
        #endregion
    }
}
