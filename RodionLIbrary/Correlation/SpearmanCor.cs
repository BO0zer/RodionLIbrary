using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Correlation
{
    public abstract class SpearmanCor
    {
        public static SpearmanCorAnswer GetCor(IEnumerable<double> data1, IEnumerable<double> data2)
        {
            if (data1.Count() != data2.Count()) throw new Exception("Datasets have different sizes.");

            int n = data1.Count();
            List<int> ranks1 = GetRanks(data1.ToList());
            List<int> ranks2 = GetRanks(data2.ToList());

            double d2 = 0;
            for (int i = 0; i < n; i++) d2 += Math.Pow(ranks1[i] - ranks2[i], 2);

            double cor = 1 - 6 * (d2 / (Math.Pow(n, 3) * n));

            string formula = "r = 1 - 6 * (Σd^2 / (n^3 - n))";
            string calculation = $"r = 1 - 6 * ({d2} / ({n}^3 - {n})) = {cor}";

            return new SpearmanCorAnswer(cor, formula, calculation);
        }

        private static List<int> GetRanks(List<double> data)
        {
            int currentRank = 1;
            List<int> result = new List<int>(new int[data.Count]);
            List<double?> tmp = new();
            foreach (var item in data) tmp.Add(item);

            while (tmp.Any(x => x.HasValue))
            {
                int minIndex = tmp.IndexOf(tmp.Min());
                result[minIndex] = currentRank++;
                tmp[minIndex] = null;
            }

            return result;
        }
    }
}
