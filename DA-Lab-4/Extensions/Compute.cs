using System;
using System.Linq;
using System.Collections.Generic;

namespace DA_Lab_4
{
    public static class Compute
    {
        public static double Variance(IReadOnlyCollection<double> values, double mean)
        {
            var sum = values.Select(z =>
            {
                var difference = z - mean;

                return difference * difference;
            }).Sum();

            return sum / (values.Count - 1);
        }

        public static double StandardDeviation(double variance)
        {
            return Math.Sqrt(variance);
        }

        public static double StudentDistributionQuantile(double p, double v)
        {
            var uP = NormalDistributionQuantile(p);

            var g1 = Compute.G1(uP);
            var g2 = Compute.G2(uP);
            var g3 = Compute.G3(uP);
            var g4 = Compute.G4(uP);

            return uP + (g1 / v) + (g2 / Math.Pow(v, 2)) + (g3 / Math.Pow(v, 3)) + (g4 / Math.Pow(v, 4));
        }

        public static double NormalDistributionQuantile(double p)
        {
            return p.IsLessOrEqual(0.5)
                ? -1.0 * QuantilePhi(p)
                : QuantilePhi(1.0 - p);
        }

        public static double QuantilePhi(double a)
        {
            var t = Compute.QuantileT(a);

            var numerator =
                Constants.C0 +
                Constants.C1 * t +
                Constants.C2 * t * t;

            var denominator =
                1 +
                Constants.D1 * t +
                Constants.D2 * t * t +
                Constants.D3 * t * t * t;

            return t - (numerator / denominator);
        }

        public static double FisherDistributionQuantile(double p, double v1, double v2)
        {
            var delta = (1 / v1) - (1 / v2);
            var delta2 = delta * delta;
            var delta3 = delta2 * delta;
            var delta4 = delta3 * delta;
            var sigma = (1 / v1) + (1 / v2);
            var sigmaHalfSqrt = Math.Sqrt(sigma / 2);
            var normalQuantile = Compute.NormalDistributionQuantile(p);
            var normalQuantile2 = normalQuantile * normalQuantile;
            var normalQuantile3 = normalQuantile2 * normalQuantile;
            var normalQuantile4 = normalQuantile3 * normalQuantile;
            var normalQuantile5 = normalQuantile4 * normalQuantile;

            var s1 = normalQuantile * sigmaHalfSqrt;
            var s2 = -1 * delta * (normalQuantile2 + 2) / 6;
            var s3 = sigmaHalfSqrt *
                    (sigma * (normalQuantile2 + 3 * normalQuantile) / 24 +
                    (delta2 * (normalQuantile3 + 11 * normalQuantile)) / (72 * sigma));
            var s4 = -1 * delta * sigma * (normalQuantile4 + 9 * normalQuantile2 + 8) / 120;
            var s5 = delta3 * (3 * normalQuantile4 + 7 * normalQuantile2 - 16) / (3240 * sigma);

            var s6_1 = sigma * sigma * (normalQuantile5 + 20 * normalQuantile3 + 15 * normalQuantile) / 1920;
            var s6_2 = delta4 * (normalQuantile5 + 44 * normalQuantile3 + 183 * normalQuantile) / 2880;
            var s6_3 = delta4 * (9 * normalQuantile5 - 284 * normalQuantile3 - 1513 * normalQuantile) / (155520 * sigma * sigma);
            var s6 = sigmaHalfSqrt * (s6_1 + s6_2 + s6_3);

            return Math.Exp((s1 + s2 + s3 + s4 + s5 + s6) * 2);
        }

        private static double QuantileT(double a)
        {
            return Math.Sqrt(-2 * Math.Log(a));
        }

        public static double MeanSquaredStandardDeviation(double S, int N)
        {
            return S / Math.Sqrt(N);
        }

        public static double SampleMeanSquaredStandardDeviation(double S, int N)
        {
            return S / Math.Sqrt(2.0 * N);
        }

        public static double SkewnessCoefficientRootMeanSquareDeviation(int N)
        {
            return Math.Sqrt(
            (6.0 * N * (N - 1))
            /
            (((double)N - 2) * (N + 1) * (N + 3))
            );
        }

        public static double KurtosisCoefficientRootMeanSquareDeviation(int N)
        {
            return Math.Sqrt(
            (24.0 * N * (N - 1) * (N - 1))
            /
            (N - 3D)
            /
            (N - 2D)
            /
            (N + 3D)
            /
            (N + 5D));
        }

        public static double G1(double uP)
        {
            return (uP * uP * uP + uP) / 4;
        }

        public static double G2(double uP)
        {
            return (5 * Math.Pow(uP, 5) + 16 * Math.Pow(uP, 3) + 3 * uP) / 96;
        }

        public static double G3(double uP)
        {
            return (3 * Math.Pow(uP, 7) + 19 * Math.Pow(uP, 5) + 17 * Math.Pow(uP, 3) - 15 * uP) / 384;
        }

        public static double G4(double uP)
        {
            return (79 * Math.Pow(uP, 9) + 779 * Math.Pow(uP, 7) + 1482 * Math.Pow(uP, 5) - 1920 * Math.Pow(uP, 3) - 945 * uP) / 92160;
        }

        public static Dictionary<double, double> Ranks(List<double> values)
        {
            var orderedValues = values.Order().ToList();

            var previous = orderedValues[0];
            var positions = new List<int>();

            var result = new Dictionary<double, double>();

            for (int i = 0; i < orderedValues.Count; i++)
            {
                var current = orderedValues[i];

                if (i == 0 || current == previous)
                {
                    positions.Add(i + 1);
                    continue;
                }

                result.Add(previous, positions.Average());
                positions.Clear();
                positions.Add(i + 1);

                previous = current;

                if (i + 1 == orderedValues.Count)
                    result.Add(previous, positions.Average());
            }

            return result;
        }
    }
}
