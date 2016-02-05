using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP
{
    class Pre_Processing
    {
        public List<double> Normalize(List<double> L)
        {
            double mean = 0;
            for (int i = 0; i < L.Count; i++)
            {
                mean += L[i];
            }
            mean /= L.Count;
            double maxFeat = double.MinValue;
            for (int i = 0; i < L.Count; i++)
            {
                if (Math.Abs(L[i]) > maxFeat)
                {
                    maxFeat = Math.Abs(L[i]);
                }
            }
            for (int i = 0; i < L.Count; i++)
            {
                L[i] = (L[i] - mean) / maxFeat;
            }
            return L;
        }
    }
}
