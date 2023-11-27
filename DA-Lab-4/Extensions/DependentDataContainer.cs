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
        private List<double>? _vilcocsonDifferences;
        private double? _vilcocsonSignedRankTest;
        private double? _vilcocsonStatistics;

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

        public List<double> VilcocsonDifferences 
        {
            get
            {
                if (_vilcocsonDifferences == null)
                    ComputeVilcocsonDifferences();

                return _vilcocsonDifferences!;
            }
        }

        public double VilcocsonSignedRankTest
        {
            get
            {
                if (_vilcocsonSignedRankTest == null)
                    ComputeVilcocsonSignedRankTest();

                return _vilcocsonSignedRankTest!.Value;
            }
        }

        public double VilcocsonStatistics
        {
            get
            {
                if (_vilcocsonStatistics == null)
                    ComputeVilcocsonStatistics();

                return _vilcocsonStatistics!.Value;
            }
        }

        public double ElementsCount => XDataContainer.ElementsCount;

        public bool AreNormalDistributed => XDataContainer.IsNormalDistributed && YDataContainer.IsNormalDistributed;

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
            _pairedTTest = DifferencesDataContainer.Datas.All(value => value.IsEqual(0)) 
                ? 0 
                : DifferencesDataContainer.Mean * Math.Sqrt(ElementsCount) / 
                    DifferencesDataContainer.StandardDeviation;
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

        private void ComputeVilcocsonDifferences()
        {
            _vilcocsonDifferences = DifferencesDataContainer.Datas
                .Except(new List<double> { 0D })
                .ToList();
        }

        private void ComputeVilcocsonSignedRankTest()
        {
            if (VilcocsonDifferences.Count == 0)
            {
                _vilcocsonSignedRankTest = 0;
                return;
            }

            var fixedDifferencesAbs = VilcocsonDifferences
                .Select(Math.Abs)
                .ToList();

            var ranks = Compute.Ranks(fixedDifferencesAbs);

            var sum = 0D;

            for (int i = 0; i < VilcocsonDifferences.Count; i++)
                if (VilcocsonDifferences[i] > 0D)
                    sum += ranks[fixedDifferencesAbs[i]];
        
            _vilcocsonSignedRankTest = sum;
        }

        private void ComputeVilcocsonStatistics()
        {
            var n = VilcocsonDifferences.Count;

            var e = n * (n + 1) / 4D;

            var d = n * (n + 1) * (2 * n + 1) / 24D;

            _vilcocsonStatistics = (VilcocsonSignedRankTest - e) / Math.Sqrt(d);
        }
        #endregion
    }
}
