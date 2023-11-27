using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DA_Lab_4
{
    internal static class ExtensionsMethods
    {
        private static readonly Color[] RandomColorsPool = new Color[]
        {
            Color.Red,
            Color.Green,
            Color.Magenta,
            Color.Cyan,
            Color.Bisque,
            Color.Fuchsia,
            Color.Firebrick,
            Color.Coral,
            Color.IndianRed,
            Color.HotPink
        };

        private static readonly Random Random = new();

        public static Color GetRandomColor()
        {
            return RandomColorsPool[Random.Next(0, RandomColorsPool.Length)];
        }

        public static T2 GetValue<T1, T2>(this IDictionary<T1, T2> dictionary, T1 key)
        {
            if (!dictionary.ContainsKey(key)) return default!;

            return dictionary[key];
        }

        public static void AddPair<T1, T2>(this IDictionary<T1, T2> dictionary, T1 key, T2 value)
        {
            if (dictionary.ContainsKey(key)) dictionary[key] = value;
            else dictionary.Add(key, value);
        }

        public static string ToFormattedString(this double value)
        {
            return value.ToString("0.000000");
        }

        public static string ToFormattedString(this (double LeftEdge, double RightEdge) pair)
        {
            return $"[{pair.LeftEdge.ToFormattedString()}; {pair.RightEdge.ToFormattedString()}]";
        }

        public static bool IsEqual(this double a, double b) => Math.Abs(a - b) < Constants.Tolerance;

        public static bool IsLessOrEqual(this double a, double b) => a < b || a.IsEqual(b);

        public static bool HasRepetitiveElement<T>(this IEnumerable<T> values, T value) where T : IComparable
        {
            return values.Count(x => x.CompareTo(value) == 0) > 1;
        }

        public static Dictionary<T, List<int>> ElementsIndexes<T>(this IList<T> sortedList, IList<T> values) where T : IComparable
        {
            var result = new Dictionary<T, List<int>>();
            var list = new List<int>();

            var valuesIndex = 0;

            for (var i = 0; i < sortedList.Count; i++)
            {
                var currentElement = sortedList[i];

                if (currentElement.CompareTo(values[valuesIndex]) == 0)
                    list.Add(i + 1);

                if (currentElement.CompareTo(values[valuesIndex]) > 0 || i + 1 == sortedList.Count)
                {
                    result.Add(values[valuesIndex], list);
                    list = new List<int>();

                    valuesIndex++;

                    if (valuesIndex == values.Count)
                        return result;

                    i--;
                }
            }

            return result;
        }
    }
}
