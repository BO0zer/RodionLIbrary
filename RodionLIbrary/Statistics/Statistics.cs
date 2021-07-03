using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Statistics
{
    public abstract class Statistics
    {
        public static double Mean(IEnumerable<double> data) => data.Average();

        public static double R(IEnumerable<double> data) => data.Max() - data.Min();

        public static double Var(IEnumerable<double> data)
        {
            double sqrMean = 0;
            foreach (var item in data) sqrMean += Math.Pow(item, 2);
            sqrMean /= data.Count();

            return sqrMean - Math.Pow(Mean(data), 2);
        }

        public static double CorrectVar(IEnumerable<double> data)
        {
            double mean = Mean(data);

            return data.Sum(x => Math.Pow(x - mean, 2)) / (data.Count() - 1);
        }

        public static double Sd(IEnumerable<double> data) => Math.Sqrt(Var(data));

        public static double VarCoefficient(IEnumerable<double> data) => Sd(data) / Mean(data) * 100;

        public static double Median(IEnumerable<double> data)
        {
            List<double> sortedData = data.ToList();
            sortedData.Sort();

            if (sortedData.Count % 2 == 0)
            {
                double i1 = sortedData[sortedData.Count / 2 - 1];
                double i2 = sortedData[sortedData.Count / 2];
                return (i1 + i2) / 2;
            }

            return sortedData[(sortedData.Count + 1) / 2 - 1];
        }

        public static Dictionary<double, int> Frequencies(IEnumerable<double> data)
        {
            Dictionary<double, int> result = new();

            foreach (double item in data)
            {
                if (result.ContainsKey(item)) result[item] += 1;
                else result.Add(item, 1);
            }

            return result;
        }

        public static IEnumerable<double> Mode(IEnumerable<double> data)
        {
            Dictionary<double, int> frequency = Frequencies(data);
            double maxFreq = frequency.Max(x => x.Value);

            List<double> result = new();
            if (maxFreq != 1) 
                foreach (var item in frequency) if (item.Value == maxFreq) result.Add(item.Key);

            return result;
        }

        public static double InitialMoment(IEnumerable<double> data, double k) => data.Sum(x => Math.Pow(x, k)) / data.Count();

        public static double CentralMoment(IEnumerable<double> data, double k)
        {
            double mean = Mean(data);

            return data.Sum(x => Math.Pow(x - mean, k)) / data.Count();
        }

        public static double Asymmetry(IEnumerable<double> data) => CentralMoment(data, 3) / Math.Pow(Sd(data), 3);

        public static double Excess(IEnumerable<double> data) => CentralMoment(data, 4) / Math.Pow(Var(data), 2) - 3;

        public static int K(int n) => (int)(1 + 3.322 * Math.Log10(n));

        public static double H(IEnumerable<double> data) => R(data) / K(data.Count());
    }
}
